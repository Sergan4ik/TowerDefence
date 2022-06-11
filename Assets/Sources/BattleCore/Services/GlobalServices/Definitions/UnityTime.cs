using UnityEngine;

public class UnityTime : ITimeService
{
    public float deltaTime => Time.deltaTime;
    public float timeSinceStartup => Time.realtimeSinceStartup;
    public float timeScale => Time.timeScale;
}