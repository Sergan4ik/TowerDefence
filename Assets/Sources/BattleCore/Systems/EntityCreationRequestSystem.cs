using System;
using Entitas;
using System.Collections.Generic;

public sealed class EntityCreationRequestSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public EntityCreationRequestSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.CreateProjectile));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCreateProjectile;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            _contexts.game.CreateProjectile(entity.createProjectile.startPosition , entity.createProjectile.startVelocity);
            entity.Destroy();
        }
    }
}