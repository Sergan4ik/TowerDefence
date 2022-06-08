using System;
using UnityEngine;

public class BattleProcessor : MonoBehaviour
{
    private MoveSystem _moveSystem;
    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        Contexts _contexts = Contexts.sharedInstance;
        var e = _contexts.game.CreateEntity();
        e.AddPosition(new Vector3(0, 0, 0));
        e.AddSpeed(new Vector3(0, 0, 0));
        e.isMovable = true;

         _moveSystem = new MoveSystem(_contexts);
    }

    private void Update()
    {
        _moveSystem.Execute();
    }
}