using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimState : PlayerBaseState
{
    public PlayerClimState(PlayerStateMachine currentContex, PlayerStateFactory playerStateFactory) : base(currentContex, playerStateFactory) { }
    public override void EnterState()
    {
        //Animations
        _ctx._animatorController.SetBool(_ctx._isClimbingParameter, true);
        _ctx._animatorController.SetBool(_ctx._isGlidingParameter, false);
        _ctx._animatorController.SetBool(_ctx._isGroundedParameter, false);
        _ctx._animatorController.SetFloat(_ctx._sprintSpeedParameter, 0f);
        _ctx._gravityValue = 0;
        _ctx._playervelocity.y = 0;
    }
    public override void UpdateState() { CheckSwitchState(); HandleClimbing(); StaminaDecreasing(); }
    public override void ExitState() { }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if (_ctx._canClimb == false)
        {
            SwitchState(_factory.Jump());
            _ctx._gravityValue = -9.8f;
        }
        if (_ctx._Player.Stamina < 6)
        {
            SwitchState(_factory.Jump());
            _ctx._gravityValue = -9.8f;
        }
        if (_ctx._playerInputMap.actions["Jump"].WasPressedThisFrame())
        {
            SwitchState(_factory.Jump());
            _ctx._gravityValue = -9.8f;
        }
    }
    private void StaminaDecreasing()
    {
        if (_ctx._playerInputMap.actions["Move"].ReadValue<Vector2>() != Vector2.zero)
        {
            _ctx._staminaContainer.SetActive(true);
            if (_ctx._Player.Stamina > 5) _ctx._Player.Stamina -= _ctx._staminaDecrease / 3 * Time.deltaTime;
        }
    }
    float GetMovementSpeed()
    {
        _ctx._movemenInput = _ctx._playerInputMap.actions["Move"].ReadValue<Vector2>();
        float MovementSpeed;
        MovementSpeed = Mathf.Abs(_ctx._movemenInput.x) + Mathf.Abs(_ctx._movemenInput.y);
        return MovementSpeed;
    }
    void HandleClimbing()
    {
        _ctx.PackEquipment();
        Animations();

        // Check walls in a cross pattern
        Vector3 offset = _ctx.transform.TransformDirection(Vector2.one * 0.5f);
        Vector3 checkDirection = Vector3.zero;
        int k = 0;
        for (int i = 0; i < 4; i++)
        {
            RaycastHit checkHit;
            if (Physics.Raycast(_ctx.transform.position + offset + _ctx.transform.TransformVector(_ctx._climbOffset), _ctx.transform.forward, out checkHit,1f))
            {
                checkDirection += checkHit.normal;
                k++;
                // Draw ray in the editor
                Debug.DrawRay(_ctx.transform.position + offset + _ctx.transform.TransformVector(_ctx._climbOffset), _ctx.transform.forward * checkHit.distance, Color.green);
            }
            // Rotate Offset by 90 degrees
            offset = Quaternion.AngleAxis(90f, _ctx.transform.forward) * offset;
        }
        checkDirection /= k;

        // Check wall directly in front
        RaycastHit hit;
        if (Physics.Raycast(_ctx.transform.position + _ctx.transform.TransformVector(_ctx._climbOffset), -checkDirection * 2, out hit,1f))
        {
            float dot = Vector3.Dot(_ctx.transform.forward, -hit.normal);

            // Draw ray in the editor
            Debug.DrawRay(_ctx.transform.position + _ctx.transform.TransformVector(_ctx._climbOffset), -checkDirection * 2 * hit.distance, Color.red);

            _ctx.transform.rotation = Quaternion.RotateTowards(_ctx.transform.rotation, Quaternion.LookRotation(-hit.normal, Vector3.up), 180f * Time.fixedDeltaTime);

            // Convert movement input to local space
            Vector3 _movemenInputLocal = new Vector3(_ctx._movemenInput.x, _ctx._movemenInput.y, 0);
            Vector3 _movemenInputWorld = _ctx.transform.TransformDirection(_movemenInputLocal);
            _ctx._controller.Move(_movemenInputWorld * _ctx._playerSpeed / 1.5f * Time.deltaTime);
        }
        else { _ctx._canClimb = false;}
    }
    void Animations()
    {
        float movementSpeed = GetMovementSpeed();
        _ctx._animatorController.SetFloat(_ctx._movementSpeedParameter, movementSpeed);
        _ctx._animatorController.SetFloat("Direction X", _ctx._playerInputMap.actions["Move"].ReadValue<Vector2>().x);
        _ctx._animatorController.SetFloat("Direction Y", _ctx._playerInputMap.actions["Move"].ReadValue<Vector2>().y);
    }

}



