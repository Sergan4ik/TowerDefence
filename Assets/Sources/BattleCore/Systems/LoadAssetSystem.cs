using System.Collections.Generic;
using Entitas;

public class LoadAssetSystem : ReactiveSystem<GameEntity>
{

    readonly Contexts _contexts;
    readonly IViewService _viewService;

    public LoadAssetSystem(Contexts contexts, IViewService viewService) : base(contexts.game)
    {
        _contexts = contexts;
        _viewService = viewService;
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsset && !entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Asset));
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.ReplaceView(_viewService.LoadAsset(_contexts, e, e.asset.name));
        }
    }
}
