using Entitas;

public sealed class SplineAnimationSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> toAnimate;

    public SplineAnimationSystem(Contexts contexts)
    {
        _contexts = contexts;
        toAnimate = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.AnimatorObject, GameMatcher.SplineFollowerObject));
    }

    public void Execute()
    {
        foreach (var entity in toAnimate)
        {
            if (entity.splineFollowerObject.splineFollowerObject.IsEndReached)
                entity.animatorObject.instance.CrossFadeTo("Idle" , 0.5f);
            else
                entity.animatorObject.instance.CrossFadeTo("Run" , 0.5f);
        }
    }
}