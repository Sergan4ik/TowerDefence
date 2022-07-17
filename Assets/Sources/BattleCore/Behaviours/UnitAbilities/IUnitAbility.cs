using System;
using System.Collections.Generic;

public interface IUnitAbility
{
    public void UseAbility(GameEntity unit, List<GameEntity> targets);
    public bool CanUseAbility(GameEntity unit);
    public ICooldownBehaviour CooldownBehaviour { get; }
}