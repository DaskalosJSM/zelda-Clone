public class EnemyStateFactory
{
    EnemyStateMachine _context;
    public EnemyStateFactory(EnemyStateMachine currentContext)
    {
        _context = currentContext;
    }
    public EnemyBaseState Patrol()
    {
        return new EnemyPatrolState(_context, this);
    }
    public EnemyBaseState ChasePlayer()
    {
        return new EnemyChaseState(_context, this);
    }
    public EnemyBaseState AttackPlayer()
    {
        return new EnemyAttackState(_context, this);
    }
     public EnemyBaseState HitState()
    {
        return new EnemyHitState(_context, this);
    }
      public EnemyBaseState Die()
    {
        return new EnemyDieState(_context, this);
    }
    
}
