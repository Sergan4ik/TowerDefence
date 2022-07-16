using System;
using System.Collections.Generic;

public interface IUnitAbility
{
    public void PerformShot(GameEntity unit, List<GameEntity> targets);
    public bool CanShoot(GameEntity unit);
}