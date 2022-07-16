using Entitas;
using UnityEngine;

public class DeadListener : MonoBehaviour, IEventListener, IDeadListener
{
    public OnDeadBehaviour behaviour;
    GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddDeadListener(this);
    }

    public void OnDead(GameEntity entity) => behaviour.OnDead(entity);
}