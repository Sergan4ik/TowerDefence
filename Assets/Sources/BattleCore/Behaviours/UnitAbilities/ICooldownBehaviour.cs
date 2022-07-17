using System;

public interface ICooldownBehaviour
{
    public bool InCooldown { get; }
    public void OnUse();
}

public class TimeCooldown : ICooldownBehaviour
{
    private readonly ITimeService _timeService;
    private readonly float _cooldownTime;
    private float _lastUse;

    public float CurrentCooldown => Math.Max(_timeService.time - _lastUse , 0);
    public bool InCooldown => (_timeService.time - _lastUse) < _cooldownTime;

    public TimeCooldown(float cooldownTime , ITimeService timeService)
    {
        _cooldownTime = cooldownTime;
        _timeService = timeService;
        _lastUse = -2 * cooldownTime;
    }

    public void OnUse()
    {
        _lastUse = _timeService.time;
    }
}