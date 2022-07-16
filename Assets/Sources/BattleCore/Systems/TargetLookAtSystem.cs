using System.Numerics;
using Entitas;
using Quaternion = UnityEngine.Quaternion;

public sealed class TargetLookAtSystem : IExecuteSystem
{
    private IGroup<GameEntity> _units;

    public TargetLookAtSystem(Contexts contexts)
    {
        _units = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.TargetsStash, GameMatcher.Rotation , GameMatcher.Position));
    }

    public void Execute()
    {
        foreach (var unit in _units)
        {
            if (unit.targetsStash.targets.Count <= 0) continue;
            if (!unit.targetsStash.targets[0].hasPosition) continue;
            PositionComponent lookTarget = unit.targetsStash.targets[0].position;
            
            unit.ReplaceRotation(Quaternion.LookRotation(lookTarget.value - unit.position.value));
        }
    }
}