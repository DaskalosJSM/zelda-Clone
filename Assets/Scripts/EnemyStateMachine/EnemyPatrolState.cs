using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{

    public EnemyPatrolState(EnemyStateMachine currentcontext, EnemyStateFactory enemyStateFactory) : base(currentcontext, enemyStateFactory) { }
    public override void EnterState() {}
    public override void UpdateState() { CheckSwitchState(); HandlePatrol(); }
    public override void ExitState() { }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if (_ctx._playerInSightRange) SwitchState(_factory.ChasePlayer());
    }
    private void HandlePatrol()
    {
        _ctx._Animations.SetFloat("EnemySpeed", 0);
    }
}
