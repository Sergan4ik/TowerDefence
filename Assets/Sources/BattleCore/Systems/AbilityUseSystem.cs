using Entitas;

public sealed class AbilityUseSystem : IExecuteSystem
{
    private IGroup<GameEntity> _casters;

    public AbilityUseSystem(Contexts contexts)
    {
        _casters = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Ability, GameMatcher.TargetsStash));
    }

    public void Execute()
    {
        foreach (var caster in _casters)
        {
            if (caster.targetsStash.targets.Count <= 0) continue;
            
            if (caster.ability.unitAbilityInstance.CanUseAbility(caster))
            {
                caster.ability.unitAbilityInstance.UseAbility(caster , caster.targetsStash.targets);
                caster.ability.unitAbilityInstance.CooldownBehaviour.OnUse();
            }
        }
    }
}