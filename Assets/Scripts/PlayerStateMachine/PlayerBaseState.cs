using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState 
{
    protected PlayerStateMachine _ctx;
    protected PlayerStateFactory _factory;
    public PlayerBaseState(PlayerStateMachine currentcontext, PlayerStateFactory playerStateFactory)
    {
        _ctx = currentcontext;
        _factory = playerStateFactory;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchState();
    public abstract void InitializeSubState();
    protected void UpdateStates(){}
    public void SwitchState(PlayerBaseState newState)
    {
        // current State exit State
        ExitState();
        // new enter state
        newState.EnterState();
        // switch current state of context
        _ctx.CurrentState = newState;

    }
    protected void SetSuperState(){}
    protected void SetSubState(){}
}
