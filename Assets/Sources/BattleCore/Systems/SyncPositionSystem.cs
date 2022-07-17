using Entitas;

public sealed class SyncPositionSystem : IExecuteSystem 
{

    readonly IGroup<GameEntity> _entities;

    public SyncPositionSystem(Contexts contexts) 
    {
        _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.SyncPosition, GameMatcher.Position));
    }

    public void Execute() 
    {
        foreach (var e in _entities) 
        {
            e.ReplacePosition(e.syncPosition.value.position);
        }
    }
}