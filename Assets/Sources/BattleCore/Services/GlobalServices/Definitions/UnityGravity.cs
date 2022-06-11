using UnityEngine;

public class UnityGravity : IGravityService
{
    public Vector3 Gravity => Physics.gravity;
}