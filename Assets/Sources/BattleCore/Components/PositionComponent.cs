using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class PositionComponent : IComponent { public Vector3 value; }
public sealed class VelocityComponent : IComponent { public Vector3 speed; }
[Event(EventTarget.Self)]
public sealed class RotationComponent : IComponent { public Quaternion value; }
public sealed class MovableComponent : IComponent { }

[FlagPrefix("use")]
public sealed class GravityComponent : IComponent { }