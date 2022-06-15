using System.Linq;
using Dreamteck.Splines;
using UnityEngine;

public class DreamteckSplineFollowerObject : ISplineFollowerObject
{
    private readonly SplineFollower _splineFollower;
    private readonly GameEntity _entity;
    private readonly GameContext _context;
    private readonly PathSetup _path;

    public DreamteckSplineFollowerObject(SplineFollower splineFollower, GameEntity entity , GameContext context , PathSetup path)
    {
        _splineFollower = splineFollower;
        _entity = entity;
        _context = context;
        _path = path;
        splineFollower.onEndReached += (d => _isEndReached = true);
    }

    public Vector3 Position => _splineFollower.transform.position;
    public Quaternion Rotation => _splineFollower.transform.rotation;
    
    public float FollowSpeed
    {
        get => _splineFollower.followSpeed;
        set => _splineFollower.followSpeed = value;
    }

    public bool IsEndReached => _entity.path.currentStage == _context.pathConfig.pathVariants[_entity.path.pathNumber].Count;

    private bool _isEndReached = false;

    public void SetOffset(Vector3 offset)
    {
        var list = _splineFollower.offsetModifier.GetKeys();
        _splineFollower.offsetModifier.AddKey(offset , 0 , 1);
        _splineFollower.offsetModifier.keys.Last().centerStart = 0;
        _splineFollower.offsetModifier.keys.Last().centerEnd = 1;
    }

    public void Redirect(int fromNode, string bySpline)
    {
        Node.Connection from = _path.nodes[fromNode].GetConnections().First(c => c.spline.name == bySpline);
        _splineFollower.spline = from.spline;
        _splineFollower.RebuildImmediate();
        double startpercent = _splineFollower.ClipPercent(from.spline.GetPointPercent(from.pointIndex));
        _splineFollower.SetPercent(startpercent);
    }
}