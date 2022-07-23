using System.Collections.Generic;
using Entitas;

public sealed class RadiusDamageSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private IGroup<GameEntity> targets;
    public RadiusDamageSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        targets = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Health, GameMatcher.Position));
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DamageAtRadius);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDamageAtRadius;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var damageAtEntity in entities)
        {
            var damageComp = damageAtEntity.damageAtRadius;
            foreach (var target in targets)
            {
                if((target.position.value - damageComp.damagePoint).sqrMagnitude > damageComp.radius * damageComp.radius)
                    continue;
                _contexts.ApplyDamage(damageComp.dealer , target , damageComp.amount);
                _contexts.LogMessage($"Damage at {damageComp.damagePoint.ToString()}");
            }
            damageAtEntity.Destroy();
        }
    }
}