using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Cleanup(CleanupMode.DestroyEntity)]
public sealed class CreateProjectileComponent : IComponent
{
    public Vector3 startPosition;
    public Vector3 startVelocity;
}