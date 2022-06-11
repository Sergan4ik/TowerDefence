using Entitas;

public interface ISplineFollowerCreatorService
{
    public ISplineFollowerObject InitializeSplineFollower(Contexts contexts, Entity entity);
}