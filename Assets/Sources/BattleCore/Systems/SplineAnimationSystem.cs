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
            {
                entity.ReplaceSetBool("Run", false);
            }
            else
            {
                entity.ReplaceSetBool("Run", true);
                entity.ReplaceSetFloat("Run_Speed" , entity.splineFollowerObject.splineFollowerObject.FollowSpeed / 3);
            }
        }
    }
}