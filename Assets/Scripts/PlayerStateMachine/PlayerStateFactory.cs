public class PlayerStateFactory
{
    PlayerStateMachine _context;
    public PlayerStateFactory(PlayerStateMachine currentContext)
    {
        _context = currentContext;
    }
    public PlayerBaseState Grounded()
    {
        return new PlayerGoundedState(_context, this);
    }
    public PlayerBaseState Climb()
    {
        return new PlayerClimState(_context, this);
    }
    public PlayerBaseState Jump()
    {
        return new PlayerJumpState(_context, this);
    }
    public PlayerBaseState Run()
    {
        return new PlayerRunState(_context, this);
    }
    public PlayerBaseState Attack()
    {
        return new PlayerFigthState(_context, this);
    }
      public PlayerBaseState Glide()
    {
        return new PlayerGlindingState(_context, this);
    }
        public PlayerBaseState Shoot()
    {
        return new PlayerShootState(_context, this);
    }
      public PlayerBaseState Focus()
    {
        return new PlayerFocusState(_context, this);
    }
}
