using Entitas;
using UnityEngine;

public class RotationListener : MonoBehaviour, IEventListener, IRotationListener {
    
    GameEntity _entity;
 
    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddRotationListener(this);
    }

    public void OnRotation(GameEntity entity, Quaternion value)
    {
        transform.rotation = value;
    }
}