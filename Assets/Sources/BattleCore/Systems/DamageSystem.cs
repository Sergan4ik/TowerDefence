using System;
using System.Collections.Generic;
using Entitas;

public sealed class DamageSystem : ReactiveSystem<GameEntity>
{
    public DamageSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Damage);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHealth && !entity.isDead;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            float newHealth = Math.Max(entity.health.amount - entity.damage.amount , 0);
            if (newHealth == 0)
                entity.isDead = true;
            entity.ReplaceHealth(newHealth , entity.health.maxAmount);
            
            entity.RemoveDamage();
        }
    }
}