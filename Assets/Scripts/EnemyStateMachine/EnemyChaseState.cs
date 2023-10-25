using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{

    public EnemyChaseState(EnemyStateMachine currentcontext, EnemyStateFactory enemyStateFactory) : base(currentcontext, enemyStateFactory) { }
    public override void EnterState() { _ctx.Rigging.weight = 1.0f;_ctx._Animations.SetBool("FigthState", false); }
    public override void UpdateState() { CheckSwitchState(); ChasePlayer(); }
    public override void ExitState() { }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if (_ctx._Health <= 0) SwitchState(_factory.Die());
        if (!_ctx._playerInSightRange) SwitchState(_factory.Patrol());
        if (_ctx._playerInAttackRange) SwitchState(_factory.AttackPlayer());
    }
    private void ChasePlayer()
    {
        _ctx._agent.SetDestination(_ctx._Player.position);
        _ctx._Animations.SetFloat("EnemySpeed", 1);
        _ctx.transform.LookAt(_ctx._Player, Vector3.up);
    }
}
