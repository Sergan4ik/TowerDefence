using Entitas;
using UnityEngine;

public sealed class PositionComponent : IComponent
{
    public Vector3 value;
}

public sealed class SpeedComponent : IComponent
{
    public Vector3 value;
}

public sealed class MovableComponent : IComponent
{ }