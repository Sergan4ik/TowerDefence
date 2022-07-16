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
            var e_1 = _contexts.game.CreateEntity();
            e_1.needSplineFollower = true;
            e_1.isMovable = true;
            e_1.AddSplineFollowerOptions(7, new Vector3(offset , 0 ,0));
            e_1.AddAsset("Char1", "Prefabs/Units");
            e_1.AddPosition(new Vector3(0 , -999 ,0));
            e_1.AddRotation(Quaternion.identity);
            e_1.needAnimator = true;
            e_1.AddAnimatorOptions(0);
            e_1.AddPath(pathNumber , 0 , PathBehaviourOnEnd.Stop);

            e_1.AddHealth(100 , 100);

            e_1.isTargetable = true;
        }
        
        public void CreateUnit(DefenderSpawnSettings spawnSettings)
        {
            var e = _contexts.game.CreateEntity();
            e.AddAsset("Unit1", "Prefabs/Units");
            e.AddPosition(spawnSettings.SpawnPoint);
            e.AddRotation(Quaternion.identity);
            
            e.needAnimator = true;
            e.AddAnimatorOptions(0);
            
            e.AddTargetingStrategy(spawnSettings.canBeTarget , spawnSettings.additionalData);
            e.AddTargetsStash(1 , new List<GameEntity>());
            e.AddShooting(new DirectShot(_contexts.game, 40f , 3f , _contexts.game.timeService.instance));
        }
        
        public void CreateWaveSignal(int pathNumber)
        {
            var e_1 = _contexts.game.CreateEntity();
            e_1.needSplineFollower = true;
            e_1.isMovable = true;
            e_1.AddSplineFollowerOptions(15, new Vector3(0 , 0 ,0));
            e_1.AddAsset("WaveSignal" ,"Prefabs");
            e_1.AddPosition(new Vector3());
            e_1.AddRotation(Quaternion.identity);
            e_1.AddPath(pathNumber, 0 , PathBehaviourOnEnd.Loop);
        
            e_1.needAnimator = true;
            e_1.AddAnimatorOptions(0);
        }
    }
}