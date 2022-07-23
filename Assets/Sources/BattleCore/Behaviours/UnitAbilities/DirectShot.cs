using System.Collections.Generic;
using UnityEngine;

public class DirectShot : IUnitAbility
{
    private readonly GameContext _gameContext;
    private readonly float _directDamage;
    private readonly float _fireRate; //bullets per second

    public ICooldownBehaviour CooldownBehaviour => _cooldown;
    private readonly TimeCooldown _cooldown;

    public DirectShot(GameContext gameContext, float directDamage , float fireRate , ITimeService timeService)
    {
        _gameContext = gameContext;
        _directDamage = directDamage;
        _fireRate = fireRate;

        _cooldown = new TimeCooldown(1 / _fireRate, timeService);
    }

    public void UseAbility(GameEntity unit, List<GameEntity> targets)
    {
        foreach (var target in targets)
        {
            // _gameContext.CreateEntity().AddDamage(unit, target, _directDamage);
            _gameContext.CreateEntity().AddDamageAtRadius(unit, target.position.value, 5, _directDamage);
            _gameContext.CreateEntity().AddCreateProjectile(unit.position.value ,new Vector3(0 , 1000 , 100));
        }

        if (unit.hasAnimatorObject)
        {
            unit.AddSetTrigger("Shoot");
            unit.AddSetFloat("Shoot_speed", _fireRate);
        }
    }
    public bool CanUseAbility(GameEntity unit) => !CooldownBehaviour.InCooldown;
}