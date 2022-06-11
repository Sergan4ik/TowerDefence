using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public sealed class SplineFollowerOptions : IComponent
{
    public float speed;
    public Vector3 offset;
}
[FlagPrefix("need")]
public sealed class SplineFollowerComponent : IComponent { }
public sealed class SplineFollowerObjectComponent : IComponent { public ISplineFollowerObject splineFollowerObject; }