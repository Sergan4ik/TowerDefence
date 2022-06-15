using System;
using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;
using Entitas;
using UnityEngine;

public class DreamteckSplineFollowerCreatorService : ISplineFollowerCreatorService
{
    private Contexts _contexts;
    private readonly PathSetup _pathGraph;
    private int _createdCount;
    public DreamteckSplineFollowerCreatorService(Contexts contexts ,PathSetup pathGraph)
    {
        _contexts = contexts;
        _pathGraph = pathGraph;
        _createdCount = 0;
    }
    public ISplineFollowerObject InitializeSplineFollower(GameEntity entity)
    {
        var gm = new GameObject()
        {
            name = $"Follower #{_createdCount++}"
        };
        gm.transform.parent = _pathGraph.transform;
        
        var follower = gm.AddComponent<SplineFollower>();
        follower.spline = _pathGraph.splines.First(s =>
            _contexts.game.pathConfig.pathVariants[entity.path.pathNumber][1].Item2 == s.name);
        //TODO MAKE UNSUBSCRIBE SYSTEM
        follower.onNode += passed => OnNodeReaction(entity , passed);
        //entity.requireRedirectPath = true;
        return new DreamteckSplineFollowerObject(follower , entity , _contexts.game , _pathGraph);
    }

    private void OnNodeReaction(GameEntity entity , List<SplineTracer.NodeConnection> passed)
    {
        if (passed.Count > 0)
            if (passed[0].node != _pathGraph.nodes[_contexts.game.pathConfig.pathVariants[entity.path.pathNumber][entity.path.currentStage].Item1 - 1])            
                entity.requireRedirectPath = true;
    }
}