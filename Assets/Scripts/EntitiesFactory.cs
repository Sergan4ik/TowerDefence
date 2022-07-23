using System.Collections.Generic;
using Entitas;
using UnityEngine;

public static class EntitiesFactory
{
    public static void ApplyDamage(this Contexts _contexts, GameEntity dealer, GameEntity receiver, float amount)
    {
        ApplyDamage(_contexts.game , dealer , receiver , amount);
    }
    public static void ApplyDamage(this GameContext _context, GameEntity dealer, GameEntity receiver, float amount)
    {
        _context.CreateEntity().AddDamage(dealer , receiver , amount);
    }
    public static void LogMessage(this Contexts _contexts , string logMessage)
    {
        LogMessage(_contexts.log , logMessage);
    }
    public static void LogMessage(this LogContext _context , string logMessage)
    {
        _context.CreateEntity().AddLogMessage(logMessage);
    }
    public static void CreateZombie(this GameContext context , float offset , int pathNumber)
    {
        var entity = context.CreateEntity();
        entity.needSplineFollower = true;
        entity.isMovable = true;
        entity.AddSplineFollowerOptions(7, new Vector3(offset , 0 ,0));
        entity.AddAsset("Char1", "Prefabs/Units");
        entity.AddPosition(new Vector3(0 , -999 ,0));
        entity.AddRotation(Quaternion.identity);
        entity.needAnimator = true;
        entity.AddAnimatorOptions(0);
        entity.AddPath(pathNumber , 0 , PathBehaviourOnEnd.Stop);

        entity.AddHealth(100 , 100);

        entity.isTargetable = true;
    }
        
    public static void CreateUnit(this GameContext context ,DefenderSpawnSettings spawnSettings)
    {
        var entity = context.CreateEntity();
        entity.AddAsset("Unit1", "Prefabs/Units");
        entity.AddPosition(spawnSettings.SpawnPoint);
        entity.AddRotation(Quaternion.identity);
            
        entity.needAnimator = true;
        entity.AddAnimatorOptions(0);
            
        entity.AddTargetingStrategy(spawnSettings.canBeTarget , spawnSettings.additionalData);
        entity.AddTargetsStash(1 , new List<GameEntity>());
        entity.AddAbility(new DirectShot(context, 40f , 1f , context.timeService.instance));
    }

    public static void CreateProjectile(this GameContext context, Vector3 startPosition , Vector3 startForce)
    {
        var entity = context.CreateEntity();
        entity.isMovable = true;
        entity.AddAsset("Projectile1", "Prefabs");
        entity.AddPosition(startPosition);
        entity.AddRotation(Quaternion.identity);
        entity.AddForce(startForce);
    }
        
    public static void CreateWaveFantom(this GameContext context, int pathNumber)
    {
        var entity = context.CreateEntity();
        entity.needSplineFollower = true;
        entity.isMovable = true;
        entity.AddSplineFollowerOptions(15, new Vector3(0 , 0 ,0));
        entity.AddAsset("WaveSignal" ,"Prefabs");
        entity.AddPosition(new Vector3());
        entity.AddRotation(Quaternion.identity);
        entity.AddPath(pathNumber, 0 , PathBehaviourOnEnd.Loop);
        
        entity.needAnimator = true;
        entity.AddAnimatorOptions(0);
    }
}