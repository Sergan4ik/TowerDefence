using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class PositionComponent : IComponent { public Vector3 value; }

public sealed class VelocityComponent : IComponent
{
    public Vector3 direction;
    public float speed;
}

public sealed class MovableComponent : IComponent { }

public sealed class RotationComponent : IComponent { public Quaternion value; }

public sealed class ViewComponent : IComponent
{
    public IViewController instance;
}

public sealed class Asset : IComponent
{
    public string name;
    public string path;
} 