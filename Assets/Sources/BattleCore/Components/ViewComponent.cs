using Entitas;

public sealed class AssetComponent : IComponent
{
    public string name;
    public string path;
}

public sealed class ViewComponent : IComponent
{
    public UnityGameView instance;
}