using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine currentContex, PlayerStateFactory playerStateFactory) : base(currentContex, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx.PackEquipment();
        _ctx._animatorController.SetBool(_ctx._isGroundedParameter, true);
        _ctx._animatorController.SetFloat(_ctx._sprintSpeedParameter, 1f);
        _ctx._animatorController.SetBool(_ctx._isClimbingParameter, false);
        _ctx._playervelocity.y = 0f;
    }
    public override void UpdateState() { CheckSwitchState(); BasicMovement(); WallDetection(); }
    public override void ExitState() { }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if (_ctx._playerInputMap.actions["Jump"].WasPressedThisFrame())
        {
            _ctx._playervelocity.y = Mathf.Sqrt(_ctx._jumpForce * -2f * _ctx._gravityValue);
            SwitchState(_factory.Jump());
        }
        if (!_ctx._playerInputMap.actions["Sprint"].IsPressed())
        {
            SwitchState(_factory.Grounded());
        }
    }

    private void BasicMovement()
    {
        // Add Player animations
        Animations();
        // Manage player input
        Vector3 _movemenInput3D = new Vector3(_ctx._movemenInput.x, 0, _ctx._movemenInput.y);
        Vector3 _movemenInputWorldSpace = Quaternion.Euler(0, _ctx._followCamera.transform.eulerAngles.y, 0) * _movemenInput3D;
        Vector3 movementDirection = _movemenInputWorldSpace;
        // Stamina Container
        _ctx._staminaContainer.SetActive(true);
        if (_ctx._Player.Stamina > 5) _ctx._Player.Stamina -= _ctx._staminaDecrease * Time.deltaTime;
        else
        {
            if (_ctx._Player.Stamina < 100) _ctx._Player.Stamina += _ctx._staminaDecrease * 2 * Time.deltaTime;
            if (_ctx._Player.Stamina >= 99) _ctx._staminaContainer.SetActive(false);
        }
        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            _ctx.transform.rotation = Quaternion.Slerp(_ctx.transform.rotation, desiredRotation, _ctx._rotationSpeed * Time.deltaTime);
        }
        _ctx._controller.Move(movementDirection * _ctx._sprintSpeed * Time.deltaTime);
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
    private void WallDetection()
    {
        // Cast a ray forward to detect walls
        Ray ray = new Ray(_ctx.transform.position + _ctx._climbOffset, _ctx.transform.forward);
        RaycastHit hit;
        // Detecd ray collision value and asigned
        _ctx._canClimb = Physics.Raycast(ray, out hit, _ctx._raycastClimDistance);
        Debug.DrawRay(ray.origin, ray.direction * _ctx._raycastClimDistance, Color.red);
        // Draw Ray in Editor
    }
}
