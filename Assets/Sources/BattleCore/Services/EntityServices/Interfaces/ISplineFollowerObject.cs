﻿using UnityEngine;

public interface ISplineFollowerObject
{
    public Vector3 Position { get; }
    public Quaternion Rotation { get; }
    public float FollowSpeed { get; set; }
    public void SetOffset(Vector3 offset);
    public bool IsEndReached { get; }
    public int WrapMode { get; set; }
    public void Redirect(int fromNode, string bySpline);
}