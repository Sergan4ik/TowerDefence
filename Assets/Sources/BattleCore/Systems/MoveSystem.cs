using Entitas;
using UnityEngine;

public sealed class MoveSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _movableEntities;
    
    public MoveSystem(Contexts contexts)
    {
        _movableEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position
            , GameMatcher.Movable
            , GameMatcher.Speed)
        );
    }

    public void Execute()
    {
        foreach (var entity in _movableEntities)
        {
            entity.position.value += (entity.speed.value * Time.deltaTime);
        }
    }
}