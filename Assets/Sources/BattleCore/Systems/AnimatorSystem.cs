using System.Collections.Generic;
using Entitas;

public sealed class AnimatorSystem : ReactiveSystem<GameEntity>
{

    public AnimatorSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.SetTrigger, GameMatcher.SetFloat, GameMatcher.SetBool));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAnimatorObject && (entity.hasSetBool || entity.hasSetTrigger || entity.hasSetFloat);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.hasSetTrigger)
            {
                entity.animatorObject.instance.SetTrigger(entity.setTrigger);
                entity.RemoveSetTrigger();
            }
            if (entity.hasSetBool)
            {
                entity.animatorObject.instance.SetBool(entity.setBool);
                entity.RemoveSetBool();
            }
            if (entity.hasSetFloat)
            {
                entity.animatorObject.instance.SetFloat(entity.setFloat);
                entity.RemoveSetFloat();
            }
        }
    }
}