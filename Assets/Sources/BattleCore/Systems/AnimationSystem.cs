using Entitas;

public sealed class AnimationSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> entities;

    public AnimationSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.AnimatorObject));
    }

    public void Execute()
    {
    }
}