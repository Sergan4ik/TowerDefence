using Entitas;

public sealed class SplineFollowerSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> _followers;


    public SplineFollowerSystem(Contexts contexts)
    {
        _contexts = contexts;
        _followers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.SplineFollowerObject, GameMatcher.Position , GameMatcher.Movable));
    }

    public void Execute()
    {
        foreach (var follower in _followers)
        {
            follower.ReplacePosition(follower.splineFollowerObject.splineFollowerObject.Position);
            if (follower.hasRotation)
                follower.ReplaceRotation(follower.splineFollowerObject.splineFollowerObject.Rotation);
        }
    }
}