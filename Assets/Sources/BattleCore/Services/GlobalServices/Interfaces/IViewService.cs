using Entitas;

public interface IViewService
{
    public UnityGameView LoadAsset(Contexts contexts, IEntity entity, string assetName , string assetPath);
}