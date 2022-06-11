using Entitas;

public sealed class Asset : IComponent
{
    public string name;
    public string path;
}

public sealed class ViewComponent : IComponent
{
    public UnityGameView instance;
}