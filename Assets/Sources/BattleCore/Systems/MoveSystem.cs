using Entitas;

public sealed class MoveSystem : IExecuteSystem
{
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _movableEntities;
    
    public MoveSystem(Contexts contexts , ITimeService timeService)
    {
        _timeService = timeService;
        _movableEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position
            , GameMatcher.Movable
            , GameMatcher.Velocity)
        );
    }

    public void Execute()
    {
        foreach (var entity in _movableEntities)
        {
            entity.ReplacePosition(entity.position.value + (entity.velocity.speed * _timeService.deltaTime));
        }
    }
}