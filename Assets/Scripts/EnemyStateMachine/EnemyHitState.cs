using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitState : EnemyBaseState
{
    public EnemyHitState(EnemyStateMachine currentcontext, EnemyStateFactory enemyStateFactory) : base(currentcontext, enemyStateFactory) { }
    public override void EnterState()
    {
        _ctx._Animations.SetBool("FigthState", true);
    }
    public override void UpdateState() { CheckSwitchState(); AttackPlayer(); }
    public override void ExitState()
    {
        _ctx._Animations.SetBool("FigthState", false);
    }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if (_ctx._Health <= 0) SwitchState(_factory.Die());
        if (!_ctx._playerInAttackRange) SwitchState(_factory.ChasePlayer());
        if (!_ctx._playerInSightRange) SwitchState(_factory.Patrol());
    }
    private void AttackPlayer()
    {
        Attack();
        //_ctx.transform.LookAt(_ctx._Player, Vector3.up);
    }
    public void Attack()

    {
        if (!_ctx._IsHurt)
        {
            if (!_ctx._alreadyAttacked)
            {
                ///Attack code here
                MeeleEnemyAttack();
                ///End of attack code
                _ctx._alreadyAttacked = true;
                _ctx.Invocation();
            }
        }
    }
    public void MeeleEnemyAttack()
    {
        _ctx._Animations.Play("Attack", 0, 0f);
        if (_ctx.HitBox != null) _ctx.HitBox.SetActive(true);
        _ctx.Invoke("DeactivateHitBox", 1.0f);
        SwitchState(_factory.AttackPlayer());

    }
}