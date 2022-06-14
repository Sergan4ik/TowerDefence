using System.Linq;
using Dreamteck.Splines;
using UnityEngine;

public class DreamteckSplineFollowerObject : ISplineFollowerObject
{
    private readonly SplineFollower _splineFollower;

    public DreamteckSplineFollowerObject(SplineFollower splineFollower)
    {
        _splineFollower = splineFollower;
        splineFollower.onEndReached += (d => _isEndReached = true);
    }

    public Vector3 Position => _splineFollower.transform.position;
    public Quaternion Rotation => _splineFollower.transform.rotation;
    
    public float FollowSpeed
    {
        get => _splineFollower.followSpeed;
        set => _splineFollower.followSpeed = value;
    }

    public bool IsEndReached => _isEndReached;

    private bool _isEndReached = false;

    public void SetOffset(Vector3 offset)
    {
        var list = _splineFollower.offsetModifier.GetKeys();
        _splineFollower.offsetModifier.AddKey(offset , 0 , 1);
        _splineFollower.offsetModifier.keys.Last().centerStart = 0;
        _splineFollower.offsetModifier.keys.Last().centerEnd = 1;
    }

    public void Redirect(int toNode, string bySpline)
    {
        throw new System.NotImplementedException();
    }
}