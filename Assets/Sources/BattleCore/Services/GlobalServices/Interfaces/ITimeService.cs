public interface ITimeService
{
    public float deltaTime { get; }
    public float realTimeSinceStartup { get; } 
    public float time { get; }
    public float timeScale { get; } 
}