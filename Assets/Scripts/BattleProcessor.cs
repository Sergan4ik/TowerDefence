using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using SerializeUtils = Utils.SerializationUtils;

public class BattleProcessor : MonoBehaviour
{
    [SerializeField] private PathSetup pathSetup;
    [SerializeField] private List<DefenderSpawnSettings> defenders;

    private GameSystems _gameSystems;
    private ServiceRegistrationSystems _serviceRegistration;
    private LogSystems _logSystems;

    private GameContext gameContext => Contexts.sharedInstance.game;
    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        var sharedInstance = Contexts.sharedInstance;
        sharedInstance.Reset();
        
        var services = new Services(
             new UnityTime()
            , new UnityLogger()
            , new UnityViewService()
            , new UnityGravity()
            , new DreamteckSplineFollowerCreatorService(sharedInstance , pathSetup)
            , new UnityAnimatorCreator()
            , new GraphCreatorService(pathSetup)
        );

        _serviceRegistration = new ServiceRegistrationSystems(sharedInstance, services);
        _gameSystems = new GameSystems(sharedInstance , services);
        _logSystems = new LogSystems(sharedInstance , services);
        
        InitializeSystems();
        
        CreateTestEntities();

    }

    private void CreateTestEntities()
    {
        StartCoroutine(SpawnWave());
        foreach (var unit in defenders)
        {
            gameContext.CreateUnit(unit);
        }
    }

    IEnumerator SpawnWave()
    {
        int cnt = 100;
        var waitForSeconds = new WaitForSeconds(0.2f);
        var forSeconds = new WaitForSeconds(0.05f);
        var spawnWave = new WaitForSeconds(0.01f);
        
        for (int i = 0; i < cnt; ++i)
        {
            float offset = Random.Range(-1, 1);
            gameContext.CreateZombie(offset , Random.Range(0 , 14));

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
            gameContext.CreateZombie(0 , i);
    }

    private IEnumerator CreateWaveSignalCoroutine(int pathNumber)
    {
        int waveCnt = 5;
        var waveSignalCoroutine = new WaitForSeconds(Random.Range(0 , 1f));
        for (int i = 0; i < waveCnt; ++i)
        {
            gameContext.CreateWaveFantom(pathNumber);
            yield return waveSignalCoroutine;
        }
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
    }

    private void LateUpdate()
    {
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