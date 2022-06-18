using System;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;

public static class TargetStrategies
{
    public static bool RadiusTargeting(GameEntity enemy , GameEntity unit)
    {
        if (!enemy.hasPosition) return false;
        if (!unit.hasPosition) throw new ArgumentException($"Unit with radius targeting doesn't have position {unit.ToString()}");
    
        float radius = Utils.SerializationUtils.DeserializeFloat(unit.targetingStrategy.additionalData);
        Vector3 unitPosition = unit.position.value;
        Vector3 enemyPosition = enemy.position.value;

        return (unitPosition - enemyPosition).sqrMagnitude > radius * radius;
    }
}