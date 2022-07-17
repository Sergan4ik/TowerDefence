using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class CollisionComponent : IComponent
{
    public List<Entity> collisions;
}

public sealed class RigidbodyComponent : IComponent
{
    public IRigidbody instance;
}

public sealed class ForceComponent : IComponent
{
    public Vector3 value;
}

