using System;
using System.Collections.Generic;
using Entitas;

public sealed class PathEndReachSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public PathEndReachSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.PathEndReached);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPathEndReached && entity.hasPath && entity.hasSplineFollowerObject;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            switch (entity.path.behaviourOnEnd)
            {
                case PathBehaviourOnEnd.Loop:
                    entity.ReplacePath(entity.path.pathNumber , 0 , PathBehaviourOnEnd.Loop);
                    entity.requireRedirectPath = true;
                    entity.isPathEndReached = false;
                    break;
                case PathBehaviourOnEnd.Stop:
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

}