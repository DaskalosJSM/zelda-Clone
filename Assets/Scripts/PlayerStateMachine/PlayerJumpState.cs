using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine currentContex, PlayerStateFactory playerStateFactory) : base(currentContex, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx._jumpCount = 1f;
        // Add Player animations
        _ctx._animatorController.SetBool(_ctx._isGroundedParameter, false);
        _ctx._animatorController.SetBool(_ctx._isClimbingParameter, false);
        _ctx._animatorController.SetBool(_ctx._isGlidingParameter, false);
        _ctx._animatorController.SetFloat(_ctx._sprintSpeedParameter, 0f);
    }
    public override void UpdateState() { CheckSwitchState(); handleDoubleJump(); WallDetection(); GroundDetection(); }
    public override void ExitState() { }
    public override void CheckSwitchState()
    {
        if (_ctx._controller.isGrounded)
        {
            SwitchState(_factory.Grounded());
        }
        if (_ctx._canClimb && _ctx._Player.Stamina > 0)
        {
            SwitchState(_factory.Climb());
        }
        if (_ctx._playerInputMap.actions["Glide"].WasPressedThisFrame() && _ctx._canGlide && _ctx._Player.Stamina > 0)
        {
            SwitchState(_factory.Glide());
        }
    }
    public override void InitializeSubState() { }
    void handleDoubleJump()
    {
        BasicMovement();
        if (_ctx._playerInputMap.actions["Jump"].WasPressedThisFrame() && _ctx._jumpCount > 0 && _ctx._Player.Stamina > 0)
        {
            Jump();
            _ctx._jumpCount--;
        }
    }
    private void Jump()
    {
        _ctx._playervelocity.y = Mathf.Sqrt(_ctx._jumpForce * -2f * _ctx._gravityValue);
        _ctx._Player.Stamina -= _ctx._staminaDecrease;
        _ctx._staminaContainer.SetActive(true);
    }
    private void BasicMovement()
    {
        // Manage player input
        Vector3 _movemenInput3D = new Vector3(_ctx._movemenInput.x, 0, _ctx._movemenInput.y);
        Vector3 _movemenInputWorldSpace = Quaternion.Euler(0, _ctx._followCamera.transform.eulerAngles.y, 0) * _movemenInput3D;
        Vector3 movementDirection = _movemenInputWorldSpace;

        // Rotate player towards movement direction
        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            _ctx.transform.rotation = Quaternion.Slerp(_ctx.transform.rotation, desiredRotation, _ctx._rotationSpeed * Time.deltaTime);
        }
        _ctx._controller.Move(movementDirection * Time.deltaTime);
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

}
