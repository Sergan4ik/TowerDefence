using System.Collections.Generic;
using Entitas;

public sealed class ForceAddComponent : ReactiveSystem<GameEntity>
{
    public ForceAddComponent(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Force));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasRigidbody && entity.hasForce;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities) 
        {
            e.rigidbody.instance.AddForce(e.force.value);
            e.RemoveForce();
        }
    }
}