using System;
using System.Collections.Generic;
using Entitas;

public sealed class TargetableComponent : IComponent { }

public sealed class TargetingStrategyComponent : IComponent
{
    public Func<GameEntity, GameEntity, bool> canBeTarget; // enemy / unit / addData / result
    public byte[] additionalData;
}

public sealed class TargetsStashComponent : IComponent
{
    public int maxTargetsCount;
    public List<Entity> targets;
}