using Entitas;
using TMPro;

public sealed class GravitySystem : IExecuteSystem
{
    private readonly IGravityService _gravityService;
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _movableEntities;
    
    public GravitySystem(Contexts contexts , IGravityService gravityService , ITimeService timeService)
    {
        _movableEntities =
            contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Gravity, 
                GameMatcher.Movable, 
                GameMatcher.Velocity));
        _gravityService = gravityService;
        _timeService = timeService;
    }

    public void Execute()
    {
        foreach (var entity in _movableEntities)
        {
            entity.ReplacePosition(entity.position.value + _gravityService.Gravity * _timeService.deltaTime);
        }
    }
}