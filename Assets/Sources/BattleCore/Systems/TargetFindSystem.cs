using Entitas;

public sealed class TargetFindSystem : IExecuteSystem
{
    private IGroup<GameEntity> _targetables;
    private IGroup<GameEntity> _units;

    public TargetFindSystem(Contexts contexts)
    {
        _targetables = contexts.game.GetGroup(GameMatcher.Targetable);
        _units = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.TargetingStrategy , GameMatcher.TargetsStash));
    }

    public void Execute()
    {
        foreach (var unit in _units)
        {
            foreach (var enemy in _targetables)
            {
                if (HasEnoughTargets(unit)) continue;
                if (!unit.targetingStrategy.canBeTarget(enemy, unit)) continue;
                unit.targetsStash.targets.Add(enemy);
            }

            bool HasEnoughTargets(GameEntity gameEntity)
            {
                return gameEntity.targetsStash.targets.Count >= gameEntity.targetsStash.maxTargetsCount;
            }
        }
    }
}