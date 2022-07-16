using System.Collections.Generic;

public class DirectShot : IUnitAbility
{
    private readonly GameContext _gameContext;
    private readonly float _directDamage;
    private readonly float _fireRate; //bullets per second
    private readonly ITimeService _timeService;
    private float _lastShotTime;

    public DirectShot(GameContext gameContext, float directDamage , float fireRate , ITimeService timeService)
    {
        _gameContext = gameContext;
        _directDamage = directDamage;
        _fireRate = fireRate;
        _timeService = timeService;
        _lastShotTime = -2 * fireRate;
    }
    public void PerformShot(GameEntity unit, List<GameEntity> targets)
    {
        foreach (var target in targets)
        {
            _gameContext.CreateEntity().AddDamage(unit, target, _directDamage);
        }

        if (unit.hasAnimatorObject)
        {
            unit.AddSetTrigger("Shoot");
            unit.AddSetFloat("Shoot_speed", _fireRate);
        }

        _lastShotTime = _timeService.time;
    }

    public bool CanShoot(GameEntity unit) => (_timeService.time - _lastShotTime) >= 1 / _fireRate;
}