public class DestroyOnDead : OnDeadBehaviour
{
    public override void OnDead(GameEntity entity)
    {
        Destroy(gameObject);
        base.OnDead(entity);
    }
}