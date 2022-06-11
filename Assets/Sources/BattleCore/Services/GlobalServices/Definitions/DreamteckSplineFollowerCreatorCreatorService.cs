using Dreamteck.Splines;
using Entitas;
using UnityEngine;

public class DreamteckSplineFollowerCreatorCreatorService : ISplineFollowerCreatorService
{
    private readonly SplineComputer _spline;
    private int _createdCount;
    public DreamteckSplineFollowerCreatorCreatorService(SplineComputer spline)
    {
        _spline = spline;
        _createdCount = 0;
    }
    public ISplineFollowerObject InitializeSplineFollower(Contexts contexts, Entity entity)
    {
        var gm = new GameObject()
        {
            name = $"Follower #{_createdCount++}"
        };
        gm.transform.parent = _spline.transform;
        
        var follower = gm.AddComponent<SplineFollower>();
        follower.spline = _spline;
        
        return new DreamteckSplineFollowerObject(follower);
    }
}