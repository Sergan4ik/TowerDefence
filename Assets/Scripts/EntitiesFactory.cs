using System.Collections.Generic;
using Entitas;
using UnityEngine;


namespace DefaultNamespace
{
    public class EntitiesFactory
    {
        private readonly Contexts _contexts;

        public EntitiesFactory(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void CreateZombie(float offset , int pathNumber)
        {
            var entity = _contexts.game.CreateEntity();
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
        
        public void CreateUnit(DefenderSpawnSettings spawnSettings)
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddAsset("Unit1", "Prefabs/Units");
            entity.AddPosition(spawnSettings.SpawnPoint);
            entity.AddRotation(Quaternion.identity);
            
            entity.needAnimator = true;
            entity.AddAnimatorOptions(0);
            
            entity.AddTargetingStrategy(spawnSettings.canBeTarget , spawnSettings.additionalData);
            entity.AddTargetsStash(1 , new List<GameEntity>());
            entity.AddAbility(new DirectShot(_contexts.game, 40f , 1f , _contexts.game.timeService.instance));
        }

        public void CreateProjectile(RigidbodyView view)
        {
            var entity = _contexts.game.CreateEntity();
            entity.isMovable = true;
            entity.AddAsset("Projectile1", "Prefabs");
            entity.AddPosition(new Vector3(0 , 0 ,5));
            entity.AddRotation(Quaternion.identity);
            entity.AddForce(new Vector3(0 , 100 , 0));
        }
        
        public void CreateWaveFantom(int pathNumber)
        {
            var entity = _contexts.game.CreateEntity();
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
}