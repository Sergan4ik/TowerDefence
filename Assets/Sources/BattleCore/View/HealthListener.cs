using Entitas;
using UnityEngine;

public class HealthListener : MonoBehaviour, IEventListener, IHealthListener
{
    public HealthBar healthBar;
    GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddHealthListener(this);
    }

    public void OnHealth(GameEntity entity, float amount, float maxAmount)
    {
        healthBar.SetHealth(amount , maxAmount);
    }
}