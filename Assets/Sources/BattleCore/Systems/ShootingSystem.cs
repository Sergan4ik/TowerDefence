using Entitas;

public sealed class ShootingSystem : IExecuteSystem
{
    private IGroup<GameEntity> _shooters;

    public ShootingSystem(Contexts contexts)
    {
        _shooters = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Shooting, GameMatcher.TargetsStash));
    }

    public void Execute()
    {
        foreach (var shooter in _shooters)
        {
            if (shooter.targetsStash.targets.Count <= 0) continue;
            
            if (shooter.shooting.unitAbilityInstance.CanShoot(shooter))
            {
                shooter.shooting.unitAbilityInstance.PerformShot(shooter , shooter.targetsStash.targets);
            }
        }
    }
}