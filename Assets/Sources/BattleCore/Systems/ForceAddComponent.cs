using System;
using System.Collections.Generic;
using Entitas;

public sealed class ForceAddComponent : IExecuteSystem , ICleanupSystem
{
    private IGroup<GameEntity> entites;
    public ForceAddComponent(Contexts contexts)
    {
        entites = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Rigidbody, GameMatcher.Force));
    }

    /*protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
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
    }*/

    public void Execute()
    {
        foreach (var e in entites) 
        {
            e.rigidbody.instance.AddForce(e.force.value);
        }
    }

    public void Cleanup()
    {
        foreach (var e in entites.GetEntities())
        {
            e.RemoveForce();
        }
    }
}