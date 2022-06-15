using System;
using System.Collections.Generic;
using Entitas;

public sealed class PathRedirectSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public PathRedirectSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.RedirectPath);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSplineFollowerObject && entity.hasPath;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.requireRedirectPath = false;
            
            var path = entity.path;
            if (path.currentStage == _contexts.game.pathConfig.pathVariants[path.currentStage].Count - 1) // last stage now
                continue;

            var previousPathStage = _contexts.game.pathConfig.pathVariants[path.pathNumber][path.currentStage];
            
            entity.ReplacePath(path.pathNumber , path.currentStage + 1);
            path = entity.path;
            
            var newPathStage = _contexts.game.pathConfig.pathVariants[path.pathNumber][path.currentStage];
            
            entity.splineFollowerObject.splineFollowerObject.Redirect(previousPathStage.Item1 , newPathStage.Item2);
        }
    }
}