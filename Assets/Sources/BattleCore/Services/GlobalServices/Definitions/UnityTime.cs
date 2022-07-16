using UnityEngine;

public class UnityTime : ITimeService
{
    public float deltaTime => Time.deltaTime;
    public float realTimeSinceStartup => Time.realtimeSinceStartup;
    public float time => Time.time;
    public float timeScale => Time.timeScale;
}