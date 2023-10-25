using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{

    public EnemyAttackState(EnemyStateMachine currentcontext, EnemyStateFactory enemyStateFactory) : base(currentcontext, enemyStateFactory) { }
    public override void EnterState()
    {
        _ctx.ActivateRandomNumberCoroutine();
        _ctx._Animations.SetBool("FigthState", true);
        _ctx.Rigging.weight = 1.0f;
    }
    public override void UpdateState() { CheckSwitchState(); ReadValueIndex(); }
    public override void ExitState()
    {
        _ctx.DeactivateRandomNumberCoroutine();
        _ctx._Animations.SetBool("FigthState", false);
    }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if (_ctx._Health <= 0) SwitchState(_factory.Die());
        if (!_ctx._playerInAttackRange) SwitchState(_factory.ChasePlayer());
        if (_ctx.AttackIndex == 3) SwitchState(_factory.HitState());
    }
    public void ReadValueIndex()
    {
        Vector3 targetPlayer = _ctx._Player.transform.position;
        _ctx._agent.stoppingDistance = 2.5f;
        if (_ctx.AttackIndex == 0) MoveRight(targetPlayer);
        if (_ctx.AttackIndex == 1) MoveLeft(targetPlayer);
        if (_ctx.AttackIndex == 2) Face();

        _ctx.transform.LookAt(targetPlayer, Vector3.up);
    }
    public void MoveRight(Vector3 target)
    {
        _ctx._agent.ResetPath();
        _ctx._Animations.SetFloat("Walkdirection", 1f);
        _ctx.transform.RotateAround(target, Vector3.up, 80f * Time.deltaTime);
        //Debug.Log("izquierda");
    }
    public void Face()
    {
        _ctx._Animations.SetFloat("Walkdirection", 0f);
        //Debug.Log("Idle");
    }
    public void MoveLeft(Vector3 target)
    {
        _ctx._agent.ResetPath();
        _ctx._Animations.SetFloat("Walkdirection", -1f);
        _ctx.transform.RotateAround(target, Vector3.up, -80f * Time.deltaTime);
        // Debug.Log("derecha");<
    }
}
