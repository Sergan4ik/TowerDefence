using System.Collections;
using Dreamteck.Splines;
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
        Add(new HealthEventSystem(contexts));
        Add(new PositionEventSystem(contexts));
        
        Add(new MoveSystem(contexts, services.timeService));
        Add(new GravitySystem(contexts , services.gravityService , services.timeService));
        
        Add(new SplineFollowerSystem(contexts));
        Add(new SplineAnimationSystem(contexts));
        Add(new PathRedirectSystem(contexts));
        Add(new PathEndReachSystem(contexts));
        
        Add(new AnimatorSystem(contexts));

        Add(new DamageSystem(contexts));
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
        CreateZombie(0 , 6);
        //StartCoroutine(CreateWaveSignalCoroutine(0));
        //StartCoroutine(CreateWaveSignalCoroutine(13));
        //TestAllPaths();
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
            CreateZombie(offset , Random.Range(0 , 5));

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

    private void TestAllPaths()
    {
        var creator = new GraphCreatorService(pathSetup);
        int pathsCount = creator.AllPaths.Count;
        for(int i = 0; i < pathsCount; ++i)
            CreateZombie(0 , i);
    }
    
    private void CreateZombie(float offset , int pathNumber)
    {
        var e_1 = Contexts.sharedInstance.game.CreateEntity();
        e_1.needSplineFollower = true;
        e_1.isMovable = true;
        e_1.AddSplineFollowerOptions(7, new Vector3(offset , 0 ,0));
        e_1.AddAsset("Char1", "Prefabs/Units");
        e_1.AddPosition(new Vector3());
        e_1.AddRotation(Quaternion.identity);
        e_1.needAnimator = true;
        e_1.AddAnimatorOptions(0);
        e_1.AddPath(pathNumber , 0 , PathBehaviourOnEnd.Stop);
        
        e_1.AddHealth(100 , 100);
    }

    private IEnumerator CreateWaveSignalCoroutine(int pathNumber)
    {
        int waveCnt = 5;
        var waveSignalCoroutine = new WaitForSeconds(Random.Range(0 , 1f));
        for (int i = 0; i < waveCnt; ++i)
        {
            CreateWaveSignal(pathNumber);
            yield return waveSignalCoroutine;
        }
    }
    private void CreateWaveSignal(int pathNumber)
    {
        var e_1 = Contexts.sharedInstance.game.CreateEntity();
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