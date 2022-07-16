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
        return entity.damage.receiver.hasHealth && !entity.damage.receiver.isDead;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var damageComponent in entities)
        {
            GameEntity receiver = damageComponent.damage.receiver;
            float newHealth = Math.Clamp(receiver.health.amount - damageComponent.damage.amount , 0 , receiver.health.maxAmount);
            if (newHealth == 0)
                receiver.isDead = true;
            receiver.ReplaceHealth(newHealth , receiver.health.maxAmount);
            
            damageComponent.Destroy();
        }
    }
}