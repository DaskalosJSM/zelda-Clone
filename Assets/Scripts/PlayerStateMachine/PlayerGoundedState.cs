using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoundedState : PlayerBaseState
{
    public PlayerGoundedState(PlayerStateMachine currentContex, PlayerStateFactory playerStateFactory) : base(currentContex, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx._animatorController.SetBool(_ctx._isGlidingParameter, false);
        _ctx._animatorController.SetBool(_ctx._isGroundedParameter, true);
        _ctx._animatorController.SetFloat(_ctx._sprintSpeedParameter, 0f);
        _ctx._animatorController.SetBool(_ctx._isClimbingParameter, false);
        _ctx._canGlide = false;
    }
    public override void UpdateState() { CheckSwitchState(); BasicMovement(); GroundDetection(); }
    public override void ExitState() { }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if (_ctx.IsFocused)
        {
            _ctx.FocusCamera.SetActive(true);
            SwitchState(_factory.Focus());
        }
        if (_ctx._playerInputMap.actions["Jump"].WasPressedThisFrame() && _ctx._Player.Stamina > 0)
        {
            _ctx._playervelocity.y = Mathf.Sqrt(_ctx._jumpForce * -2f * _ctx._gravityValue);
            SwitchState(_factory.Jump());
        }
        if (_ctx._playerInputMap.actions["Sprint"].WasPressedThisFrame() && _ctx._Player.Stamina > 0 && _ctx._playerInputMap.actions["Move"].ReadValue<Vector2>() != Vector2.zero)
        {
            SwitchState(_factory.Run());
        }
        if (_ctx._playerInputMap.actions["Attack"].WasPressedThisFrame() && _ctx._Player.Stamina > 0)
        {
            SwitchState(_factory.Attack());
        }
        if (_ctx._playerInputMap.actions["Glide"].WasPressedThisFrame() && _ctx._canGlide && _ctx._Player.Stamina > 0 && !_ctx._controller.isGrounded)
        {
            SwitchState(_factory.Glide());
        }
        if (_ctx._playerInputMap.actions["Loading"].WasPressedThisFrame())
        {
            SwitchState(_factory.Shoot());
        }
    }

    private void BasicMovement()
    {
        // Add Player animations
        Animations();
        WallDetection();
        // Manage player input
        Vector3 _movemenInput3D = new Vector3(_ctx._movemenInput.x, 0, _ctx._movemenInput.y);
        Vector3 _movemenInputWorldSpace = Quaternion.Euler(0, _ctx._followCamera.transform.eulerAngles.y, 0) * _movemenInput3D;
        Vector3 movementDirection = _movemenInputWorldSpace;
        //Manage Stamina container
        if (_ctx._Player.Stamina < 100) _ctx._Player.Stamina += _ctx._staminaDecrease * 2 * Time.deltaTime;
        if (_ctx._Player.Stamina >= 99) _ctx._staminaContainer.SetActive(false);
        // Rotate player towards movement direction
        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            _ctx.transform.rotation = Quaternion.Slerp(_ctx.transform.rotation, desiredRotation, _ctx._rotationSpeed * Time.deltaTime);
        }
        _ctx._controller.Move(movementDirection * _ctx._playerSpeed * Time.deltaTime);
        TouchInput();
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
    private void GroundDetection()
    {

        RaycastHit hit;
        Ray downRay = new Ray(_ctx.transform.position, -Vector3.up);

        // Cast a ray straight downwards.
        if (Physics.Raycast(downRay, out hit))
        {
            if (hit.distance > _ctx._checkGlideDistance)
            {
                _ctx._canGlide = true;
            }
        }
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
    private void WallDetection()
    {
        RaycastHit hit;
        Vector3 rayOrigin = _ctx.transform.position + _ctx.transform.TransformVector(_ctx._climbOffset);
        Vector3 rayDirection = _ctx.transform.forward;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, _ctx._raycastClimDistance))
        {
            _ctx._canClimb = true;
        }
        else
        {
            _ctx._canClimb = false;
        }

        Debug.DrawRay(rayOrigin, rayDirection * (hit.distance == 0 ? _ctx._raycastClimDistance : hit.distance), Color.red);
    }

}
