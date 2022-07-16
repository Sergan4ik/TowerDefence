using System;
using Entitas;
using UnityEngine;
using SerializeUtils = Utils.SerializationUtils;

public class DefendersWithRadiusTargetingSpawnSettings : DefenderSpawnSettings
{
    [Range(0 , 500)]
    public float detectRadius;

    public override byte[] additionalData => SerializeUtils.SerializeFloat(detectRadius);
    public override Func<GameEntity, GameEntity, bool> canBeTarget => TargetStrategies.RadiusTargeting;

#if UNITY_EDITOR
    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.DrawWireSphere(transform.position + offset , detectRadius);
    }
    #endif
}