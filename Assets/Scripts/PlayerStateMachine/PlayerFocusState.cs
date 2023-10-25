using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFocusState : PlayerBaseState
{

    public PlayerFocusState(PlayerStateMachine currentContex, PlayerStateFactory playerStateFactory) : base(currentContex, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx._animatorController.SetBool("IsInGuard", true);
        _ctx.UnpackEquipment();
    }
    public override void UpdateState() { CheckSwitchState(); BasicMovement(); }
    public override void ExitState()
    {
        _ctx._animatorController.SetBool("IsInGuard", false);
        _ctx.PackEquipment();
        _ctx.FocusSigth.transform.GetChild(0).gameObject.SetActive(false);
    }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if (_ctx._playerInputMap.actions["Attack"].WasPressedThisFrame() && _ctx._Player.Stamina > 0)
        {
            SwitchState(_factory.Attack());
        }

        if (!_ctx.IsFocused)
        {
            _ctx.FocusCamera.SetActive(false);
            _ctx.FocusSigth.transform.GetChild(0).gameObject.SetActive(false);
            SwitchState(_factory.Grounded());
        }
        if (_ctx.FocuseEnemy == null)
        {
            _ctx.IsFocused = false;
            _ctx.FocusCamera.SetActive(false);
            SwitchState(_factory.Grounded());
        }
    }
    private void BasicMovement()
    {
        GetMovementSpeed();
        Animations();
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
        _ctx._controller.Move(globalMovement * _ctx._playerSpeed  * Time.deltaTime);
        if (_ctx._Player.Stamina < 100) _ctx._Player.Stamina += _ctx._staminaDecrease * 2 * Time.deltaTime;
        if (_ctx._Player.Stamina >= 99) _ctx._staminaContainer.SetActive(false);
        TouchInput();
    }
    private Quaternion SmoothDampQuaternion(Quaternion current, Quaternion target, ref Quaternion currentVelocity, float smoothTime)
    {
        float maxDegreesDelta = smoothTime * Quaternion.Angle(current, target);
        return Quaternion.RotateTowards(current, target, maxDegreesDelta);
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
        if (_ctx.FocuseEnemy != null && _ctx.IsFocused == true)
        {
            _ctx.FocusSigth.transform.position = _ctx.FocuseEnemy.transform.position;
            _ctx.FocusSigth.transform.GetChild(0).gameObject.SetActive(true);
        }
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
    void Animations()
    {
        _ctx.transform.LookAt(_ctx.FocusSigth.transform);
        float movementSpeed = GetMovementSpeed();
        _ctx._animatorController.SetFloat(_ctx._movementSpeedParameter, movementSpeed);
        _ctx._animatorController.SetFloat("Direction X", _ctx._playerInputMap.actions["Move"].ReadValue<Vector2>().x);
        _ctx._animatorController.SetFloat("Direction Y", _ctx._playerInputMap.actions["Move"].ReadValue<Vector2>().y);
    }

}
