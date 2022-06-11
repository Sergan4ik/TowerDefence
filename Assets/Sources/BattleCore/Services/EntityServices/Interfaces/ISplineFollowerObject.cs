using UnityEngine;

public interface ISplineFollowerObject
{
    public Vector3 Position { get; }
    public Quaternion Rotation { get; }
    public float FollowSpeed { get; set; }
    public void SetOffset(Vector3 offset);
    public bool IsEndReached { get; }
}