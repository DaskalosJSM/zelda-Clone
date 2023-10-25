using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyBaseState
{

    public EnemyDieState(EnemyStateMachine currentcontext, EnemyStateFactory enemyStateFactory) : base(currentcontext, enemyStateFactory) { }
    public override void EnterState()
    {
        _ctx._playerInAttackRange = false;
        _ctx._playerInSightRange = false;
        _ctx._agent.enabled = false;
    }
    public override void UpdateState() { CheckSwitchState(); HandleDead(); }
    public override void ExitState() { }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    { }
    private void HandleDead()
    {
        _ctx._playerInAttackRange = false;
        _ctx._playerInSightRange = false;
        _ctx._Animations.SetFloat("Walkdirection", 0f);
        _ctx._Animations.SetTrigger("Die");
        _ctx._playerInAttackRange = false;
        _ctx._playerInSightRange = false;
        _ctx._agent.enabled = false;
        _ctx.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
    }
}
