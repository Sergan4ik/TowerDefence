public interface ITimeService
{
    public float deltaTime { get; }
    public float timeSinceStartup { get; } 
    public float timeScale { get; } 
}