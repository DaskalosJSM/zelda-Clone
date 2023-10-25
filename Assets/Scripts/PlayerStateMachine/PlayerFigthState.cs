using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFigthState : PlayerBaseState
{
    public PlayerFigthState(PlayerStateMachine currentContex, PlayerStateFactory playerStateFactory) : base(currentContex, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx.StartMeeleeAttack();
        _ctx._staminaContainer.SetActive(true);
        if (_ctx._Player.Stamina > 5) _ctx._Player.Stamina -= _ctx._staminaDecrease;
        _ctx._animatorController.SetTrigger("Attack1");
        _ctx._Hitbox.SetActive(true);
        _ctx.UnpackEquipment();
    }
    public override void UpdateState() { CheckSwitchState(); Figth(); }
    public override void ExitState(){}
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
          if (!_ctx._comboIndex && _ctx.IsFocused)
        {
            SwitchState(_factory.Focus());
        }

        if (!_ctx._comboIndex)
        {
            SwitchState(_factory.Grounded());
        }
       
    }

    void Figth()
    {
        if (_ctx._playerInputMap.actions["Attack"].WasPressedThisFrame() && _ctx._comboIndex == true)
        {
            if (_ctx._Player.Stamina > 5) _ctx._Player.Stamina -= _ctx._staminaDecrease / 2;
            _ctx._animatorController.SetTrigger("Attack2");
        }
    }
}

