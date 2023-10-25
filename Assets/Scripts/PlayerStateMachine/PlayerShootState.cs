using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : PlayerBaseState
{
    public PlayerShootState(PlayerStateMachine currentContex, PlayerStateFactory playerStateFactory) : base(currentContex, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx._aimTarget.SetActive(true);
        _ctx._Rigging.weight = 1;
        _ctx._Sigth.SetActive(true);
        _ctx._animatorController.SetBool(_ctx._isShoothingParameter, true);
        _ctx._MoveCamera.gameObject.SetActive(false);
        _ctx._ShootCamera.gameObject.SetActive(true);
        _ctx._BowHand.SetActive(true);
        _ctx._BowBack.SetActive(false);
        _ctx.PackEquipment();
        _ctx._BowHand.GetComponent<Animator>().SetBool("IsLoading", true);
    }
    public override void UpdateState() { CheckSwitchState(); BasicMovement(); }
    public override void ExitState()
    {
        _ctx._aimTarget.SetActive(false);
        _ctx._Rigging.weight = 0;
        _ctx._Sigth.SetActive(false);
        _ctx._MoveCamera.gameObject.SetActive(true);
        _ctx._ShootCamera.gameObject.SetActive(false);
        _ctx._BowHand.SetActive(false);
        _ctx._BowBack.SetActive(true);
        _ctx._animatorController.SetBool(_ctx._isShoothingParameter, false);
    }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if (_ctx.IsFocused)
        {
            _ctx.FocusCamera.SetActive(true);
            SwitchState(_factory.Focus());
        }
        if (_ctx._playerInputMap.actions["TouchExit"].WasPressedThisFrame())
        {
            SwitchState(_factory.Grounded());
        }
        if (_ctx._playerInputMap.actions["Sprint"].WasPressedThisFrame())
        {
            SwitchState(_factory.Run());
        }
        if (_ctx._playerInputMap.actions["Jump"].WasPressedThisFrame())
        {
            SwitchState(_factory.Jump());
        }
    }
    private void BasicMovement()
    {
        Animations();
        Shoot();
        TouchInput();
        // Get input
        Vector3 movementInput3D = new Vector3(_ctx._movemenInput.x, 0, _ctx._movemenInput.y);
        // Set y Rotation
        Quaternion desiredRotation = Quaternion.Euler(0, _ctx._followCamera.transform.rotation.eulerAngles.y, 0);
        // Apply rotation
        Quaternion smoothedRotation = SmoothDampQuaternion(_ctx.transform.rotation, desiredRotation, ref _ctx._rotationVelocity, _ctx._rotationSmoothTime);
        _ctx.transform.rotation = smoothedRotation;
        // Apply movement to rotation
        Vector3 globalMovement = _ctx.transform.rotation * movementInput3D;
        // Apply movement
        _ctx._controller.Move(globalMovement * _ctx._playerSpeed * Time.deltaTime);
        if (_ctx._Player.Stamina < 100) _ctx._Player.Stamina += _ctx._staminaDecrease * 2 * Time.deltaTime;
        if (_ctx._Player.Stamina >= 99) _ctx._staminaContainer.SetActive(false);
    }

    private Quaternion SmoothDampQuaternion(Quaternion current, Quaternion target, ref Quaternion currentVelocity, float smoothTime)
    {
        float maxDegreesDelta = smoothTime * Quaternion.Angle(current, target);
        return Quaternion.RotateTowards(current, target, maxDegreesDelta);
    }
    private void Shoot()
    {
        if (_ctx._playerInputMap.actions["Attack"].WasPressedThisFrame())
        {
            _ctx._animatorController.SetTrigger("Shoot");
            _ctx._BowHand.GetComponent<Animator>().SetTrigger("Shoot");
        }
    }
    void Animations()
    {
        float movementSpeed = GetMovementSpeed();
        _ctx._animatorController.SetFloat(_ctx._movementSpeedParameter, movementSpeed);
    }

    float GetMovementSpeed()
    {
        _ctx._movemenInput = _ctx._playerInputMap.actions["Move"].ReadValue<Vector2>();
        float MovementSpeed;
        MovementSpeed = Mathf.Abs(_ctx._movemenInput.x) + Mathf.Abs(_ctx._movemenInput.y);
        return MovementSpeed;
    }
    private void TouchInput()
    {
        if (_ctx.FocuseEnemy != null && _ctx.IsFocused == true) _ctx.FocusSigth.transform.position = _ctx.FocuseEnemy.transform.position;
        if (_ctx._playerInputMap.actions["TouchExit"].WasPressedThisFrame()) _ctx.IsFocused = false;
        if (_ctx._playerInputMap.actions["TouchPress"].WasPressedThisFrame())
        {
            RaycastHit hit;
            Ray ray = _ctx._followCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Vector3 posicion = hit.point;
                    _ctx.IsFocused = true;
                    _ctx.FocusSigth.transform.position = posicion;
                    _ctx.FocuseEnemy = hit.collider.gameObject;
                }
            }
        }
    }
}



