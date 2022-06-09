using Entitas;

public interface IViewService
{
    public void LoadAsset(Contexts contexts, IEntity entity, string assetName);
}