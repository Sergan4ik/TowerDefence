using System.Collections.Generic;
using Entitas;

public sealed class CreateAnimatorSystem : ReactiveSystem<GameEntity>
{
    private readonly IAnimatorCreatorService _creatorService;

    public CreateAnimatorSystem(Contexts contexts , IAnimatorCreatorService creatorService) : base(contexts.game)
    {
        _creatorService = creatorService;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.AnimatorOptions, GameMatcher.Animator));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.needAnimator && !entity.hasAnimatorObject && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.ReplaceAnimatorObject(_creatorService.CreateAnimator(entity.animatorOptions , entity.view));
            entity.RemoveAnimatorOptions();
            entity.needAnimator = false;
        }
    }
}