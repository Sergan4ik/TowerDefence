using System;
using UnityEngine;

public abstract class DefenderSpawnSettings : MonoBehaviour
{
    public float smallSphereRadius;
    public Vector3 offset;

    public abstract byte[] additionalData { get; }
    public abstract Func<GameEntity, GameEntity, bool> canBeTarget { get; }
    public virtual Vector3 SpawnPoint => transform.position + offset;
    
#if UNITY_EDITOR
    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position + offset , smallSphereRadius);
    }
#endif

}