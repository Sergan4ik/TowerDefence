﻿using System;
using System.Collections;
using Dreamteck.Splines;
using Entitas;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class GameSystems : Feature
{
    public GameSystems(Contexts contexts , Services services)
    {
        Add(new LoadAssetSystem(contexts, services.viewService));
        Add(new CreateSplineFollowerObjectSystem(contexts, services.splineFollowerCreatorService));
        Add(new CreateAnimatorSystem(contexts, services.animatorCreatorService));
        
        Add(new RotationEventSystem(contexts));
        Add(new PositionEventSystem(contexts));
        
        Add(new MoveSystem(contexts, services.timeService));
        Add(new GravitySystem(contexts , services.gravityService , services.timeService));
        
        Add(new SplineFollowerSystem(contexts));
        Add(new SplineAnimationSystem(contexts));
        Add(new PathRedirectSystem(contexts));
        
        Add(new AnimatorSystem(contexts));
    }
}

public sealed class LogSystems : Feature
{
    public LogSystems(Contexts contexts , Services services)
    {
        Add(new LoggingSystem(contexts.log , services.loggerService));
    }
}

public sealed class ServiceRegistrationSystems : Feature
{
    public ServiceRegistrationSystems(Contexts contexts, Services services)
    {
        Add(new RegisterTimeService(contexts, services.timeService));
        Add(new RegisterLoggerService(contexts, services.loggerService));
        Add(new RegisterViewService(contexts, services.viewService));
        Add(new RegisterGravityService(contexts, services.gravityService));
        Add(new RegisterSplineFollowerService(contexts, services.splineFollowerCreatorService));
        Add(new RegisterAnimatorCreatorService(contexts, services.animatorCreatorService));
        Add(new RegisterPathConfig(contexts, services.graphCreatorService));
    }
}

public class BattleProcessor : MonoBehaviour
{
    [SerializeField]
    private PathSetup pathSetup;
    private GameSystems _gameSystems;
    private LogSystems _logSystems;
    private ServiceRegistrationSystems _serviceRegistration;

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        var services = new Services(
             new UnityTime()
            , new UnityLogger()
            , new UnityViewService()
            , new UnityGravity()
            , new DreamteckSplineFollowerCreatorService(Contexts.sharedInstance , pathSetup)
            , new UnityAnimatorCreator()
            , new GraphCreatorService(pathSetup)
        );
        
        _serviceRegistration = new ServiceRegistrationSystems(Contexts.sharedInstance, services);
        _gameSystems = new GameSystems(Contexts.sharedInstance , services);
        _logSystems = new LogSystems(Contexts.sharedInstance , services);
        
        InitializeSystems();
        
        CreateTestEntities();
    }

    private void CreateTestEntities()
    {
        //StartCoroutine(SpawnWave());
        CreateZombie(0);
    }

    IEnumerator SpawnWave()
    {
        int cnt = 100;
        var waitForSeconds = new WaitForSeconds(0.2f);
        var forSeconds = new WaitForSeconds(0.05f);
        var spawnWave = new WaitForSeconds(0.01f);
        
        for (int i = 0; i < cnt; ++i)
        {
            float offset = Random.Range(-3, 3);
            CreateZombie(offset);

            var rand = (int)Random.Range(0, 3) % 3;
            if (rand == 0)
            {
                yield return waitForSeconds;
            }
            else if (rand == 1)
            {
                yield return forSeconds;
            }
            else
            {
                yield return spawnWave;
            }
        }
    }

    private void CreateZombie(float offset)
    {
        var e_1 = Contexts.sharedInstance.game.CreateEntity();
        e_1.needSplineFollower = true;
        e_1.isMovable = true;
        e_1.AddSplineFollowerOptions(1, new Vector3(offset , 0 ,0));
        e_1.AddAsset("Char1", "");
        e_1.AddPosition(new Vector3());
        e_1.AddRotation(Quaternion.identity);
        e_1.needAnimator = true;
        e_1.AddAnimatorOptions(0);
        e_1.AddPath(13 , 0);
    }

    private void InitializeSystems()
    {
        _serviceRegistration.Initialize();
        _gameSystems.Initialize();
        _logSystems.Initialize();
    }

    private void Update()
    {
        ExecuteSystems();

        CleanUpSystems();
    }

    private void CleanUpSystems()
    {
        _logSystems.Cleanup();
        _gameSystems.Cleanup();
    }

    private void ExecuteSystems()
    {
        _gameSystems.Execute();
        _logSystems.Execute();
    }

    private void OnApplicationQuit()
    {
        _gameSystems.TearDown();
    }
}