using System.Collections.Generic;
using Entitas;

public sealed class CreateSplineFollowerObjectSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private readonly ISplineFollowerCreatorService _splineFollowerCreatorService;

    public CreateSplineFollowerObjectSystem(Contexts contexts , ISplineFollowerCreatorService splineFollowerCreatorService) : base(contexts.game)
    {
        _contexts = contexts;
        _splineFollowerCreatorService = splineFollowerCreatorService;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SplineFollower);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.needSplineFollower && !entity.hasSplineFollowerObject;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var newSplineFollowerObject = _splineFollowerCreatorService.InitializeSplineFollower(entity);
            
            newSplineFollowerObject.FollowSpeed = entity.splineFollowerOptions.speed;
            newSplineFollowerObject.SetOffset(entity.splineFollowerOptions.offset);
            
            entity.ReplaceSplineFollowerObject(newSplineFollowerObject);
            
            entity.RemoveSplineFollowerOptions();
            entity.needSplineFollower = false;
        }
    }
}