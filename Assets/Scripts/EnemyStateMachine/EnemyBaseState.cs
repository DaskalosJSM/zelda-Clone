using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState 
{
    protected EnemyStateMachine _ctx;
    protected EnemyStateFactory _factory;
    public EnemyBaseState(EnemyStateMachine currentcontext, EnemyStateFactory enemyStateFactory)
    {
        _ctx = currentcontext;
        _factory = enemyStateFactory;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchState();
    public abstract void InitializeSubState();
    protected void UpdateStates(){}
    protected void SwitchState(EnemyBaseState newState)
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