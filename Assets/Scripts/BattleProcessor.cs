using System;
using Unity.VisualScripting;
using UnityEngine;

public sealed class GameSystems : Feature
{
    public GameSystems(Contexts contexts , Services services)
    {
        Add(new MoveSystem(contexts, services.timeService));
        Add(new LoadAssetSystem(contexts, services.viewService));
        Add(new PositionEventSystem(contexts));
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
    }
}

public class BattleProcessor : MonoBehaviour
{
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
        );
        
        _serviceRegistration = new ServiceRegistrationSystems(Contexts.sharedInstance, services);
        _gameSystems = new GameSystems(Contexts.sharedInstance , services);
        _logSystems = new LogSystems(Contexts.sharedInstance , services);
        
        InitializeSystems();
        
        CreateTestEntities();
    }

    private void CreateTestEntities()
    {
        for (int i = 0; i < 400; i++)
        {
            var e = Contexts.sharedInstance.game.CreateEntity();
            e.AddPosition(new Vector3(i, 0, 0));
            e.isMovable = true;
            e.AddVelocity(new Vector3(0, 1, 0), 10);
            e.AddAsset("Zombie1", "");
        }

        var e1 = Contexts.sharedInstance.log.CreateEntity();
        e1.AddLogMessage($"{Contexts.sharedInstance.game.timeService.instance.deltaTime}");
        e1.AddLogWarning("Warning");
        e1.AddLogError("Error");
        
        var e2 = Contexts.sharedInstance.log.CreateEntity();
        e2.AddLogMessage($"{Contexts.sharedInstance.game.timeService.instance.deltaTime}");
        e2.AddLogWarning("Warning");
        e2.AddLogError("Error");
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