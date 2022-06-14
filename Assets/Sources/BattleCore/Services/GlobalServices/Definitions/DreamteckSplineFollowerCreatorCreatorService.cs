using System;
using System.Collections.Generic;
using Dreamteck.Splines;
using Entitas;
using UnityEngine;

public class DreamteckSplineFollowerCreatorCreatorService : ISplineFollowerCreatorService
{
    private readonly SplineComputer _spline;
    private Contexts _contexts;
    private int _createdCount;
    public DreamteckSplineFollowerCreatorCreatorService(Contexts contexts ,SplineComputer spline)
    {
        _contexts = contexts;
        _spline = spline;
        _createdCount = 0;
    }
    public ISplineFollowerObject InitializeSplineFollower(GameEntity entity)
    {
        var gm = new GameObject()
        {
            name = $"Follower #{_createdCount++}"
        };
        gm.transform.parent = _spline.transform;
        
        var follower = gm.AddComponent<SplineFollower>();
        follower.spline = _spline;
        
        //TODO MAKE UNSUBSCRIBE SYSTEM
        follower.onNode += passed => OnNodeReaction(entity , passed); 
        
        return new DreamteckSplineFollowerObject(follower);
    }

    private void OnNodeReaction(GameEntity entity , List<SplineTracer.NodeConnection> passed)
    {
        if (passed.Count > 0)
            entity.requireRedirectPath = true;
    }
}