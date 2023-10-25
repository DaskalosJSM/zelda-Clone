using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;

public class PlayerStateMachine : MonoBehaviour
{
    [Header("Input")]
    public PlayerInput _playerInputMap;

    public Vector2 _movemenInput;

    [Header("Animation")]
    public Animator _animatorController;
    public string _movementSpeedParameter = "PlayerSpeed";
    public string _sprintSpeedParameter = "SprintSpeed";
    public string _isGroundedParameter = "IsGrounded";
    public string _isClimbingParameter = "IsClimbing";
    public string _isGlidingParameter = "IsGliding";
    public string _isShoothingParameter = "IsShootMove";

    [Header("Movement")]
    public float _playerSpeed;
    public float _rotationSpeed;

    [Header("Running")]
    public float _sprintSpeed;
    public Vector3 _playervelocity;

    [Header("Jumping")]
    public float _jumpForce;
    public float _gravityValue = -9.81f;
    public float _jumpCount = 1f;
    public bool _canJump = true;
    public bool _isJumpPressed;
    public float _staminaDecrease;

    [Header("Climb")]
    public bool _canClimb = false;
    public Vector3 _climbOffset;
    public float _raycastClimDistance = 1.0f;

    [Header("Cameras")]
    public Camera _followCamera;
    public GameObject _ShootCamera;
    public GameObject _MoveCamera;

    [Header("GameObjects")]
    public CharacterController _controller;
    public GameObject _staminaContainer;
    public playerStatistics _Player;
    public GameObject _Sword;
    public GameObject _backSword;
    public GameObject _Shied;
    public GameObject _backShield;

    [Header("Bow")]

    public GameObject _BowHand;
    public GameObject _Sigth;
    public GameObject _BowBack;
    public Rig _Rigging;
    public GameObject _aimTarget;
    public GameObject _HeadRotation;
    public GameObject _objectToInstantiate;
    public Vector3 ArrowOffset;
    public float ArrowRotationOffset;


    [Header("Attacking")]
    public float _comboSpaceFrame;
    public GameObject _Effect1;
    public GameObject _Effect2;
    public GameObject FocusSigth;
    public GameObject FocusCamera;
    public GameObject _Hitbox;
    public GameObject FocuseEnemy;
    public bool IsFocused;

    // Variables para el suavizado de rotación

    [Header("Shooting")]
    public Quaternion _rotationVelocity;
    public float _rotationSmoothTime = 0.1f;


    [Header("Gliding")]
    public GameObject _UIElements;
    public GameObject _button;
    public bool _canGlide;
    public int _checkGlideDistance;
    public float _GlideGravity;
    public GameObject _Paraglider;
    //States variables
    PlayerBaseState _currentState;
    PlayerStateFactory _States;
    // getters and setter
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

    //[SerializeField] private  LayerMask whatIsEnemy;
    //[SerializeField] private  float attackRange;
    //public bool enemyInAttackRange;
    public bool _comboIndex;

    private void Awake()
    {
        _States = new PlayerStateFactory(this);
        _currentState = _States.Focus();
        _currentState.EnterState();
        _playerInputMap = GetComponent<PlayerInput>();
        _controller = GetComponent<CharacterController>();
        _animatorController = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        UpdatingUIElements();
        _currentState.UpdateState();
        GettingInput();
        Gravity();
       Debug.Log(_currentState);
    }
    public void GettingInput()
    {
        _movemenInput = _playerInputMap.actions["Move"].ReadValue<Vector2>();
    }
    public void Gravity()
    {
        // Apply gravity
        _playervelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playervelocity * Time.deltaTime);
        if (_controller.isGrounded && _playervelocity.y < 0)
        {
            _playervelocity.y = _gravityValue;
        }
    }
    public void StartMeeleeAttack()
    {
        StartCoroutine(MeleeAttack(_comboSpaceFrame));
    }
    IEnumerator MeleeAttack(float TimeIndex)
    {
        float counter = TimeIndex;
        while (counter > 0)
        {
            yield return new WaitForSeconds(0.1f);
            counter -= 0.1f;
            _comboIndex = true;
        }
        ResetComboIndex();
    }

    void ResetComboIndex()
    {
        _comboIndex = false;
    }
    void activeEffect1()
    {
        _Effect1.SetActive(true);
    }
    void activeEffect2()
    {
        _Effect2.SetActive(true);
    }
    void deactiveEffect1()
    {
        _Effect1.SetActive(false);
    }
    void deactiveEffect2()
    {
        _Effect2.SetActive(false);

    }
    public void PackEquipment()
    {
        _Sword.SetActive(false);
        _backSword.SetActive(true);
        _backShield.SetActive(true);
        _Shied.SetActive(false);
    }
    public void UnpackEquipment()
    {
        _backSword.SetActive(false);
        _Sword.SetActive(true);
        _backShield.SetActive(false);
        _Shied.SetActive(true);
    }
    public void PackParaglider()
    {
        _Paraglider.SetActive(false);
    }
    public void UnpackParaglider()
    {
        _Paraglider.SetActive(true);
    }
    private void UpdatingUIElements()
    {
        if (_canGlide == true)
        {
            _button.SetActive(true);
            _UIElements.SetActive(false);
        }

        if (_canGlide == false)
        {
            _button.SetActive(false);
            _UIElements.SetActive(true);
        }
        if (_controller.isGrounded)
        {
            _button.SetActive(false);
            _UIElements.SetActive(true);
        }


    }
    private void InstantiateArrow()
    {
        // Crear una rotación de offset en el eje X local
        Quaternion xRotationOffset = Quaternion.Euler(ArrowRotationOffset, 0f, 0f);

        // Combinar la rotación existente con el offset de rotación
        Quaternion combinedRotation = _followCamera.transform.rotation * xRotationOffset;

        // Instanciar el objeto con el offset de posición y rotación
        Instantiate(_objectToInstantiate, _HeadRotation.transform.position + ArrowOffset, combinedRotation);
    }
    public void HideHitBox()
    {
        _Hitbox.SetActive(false);
    }

}