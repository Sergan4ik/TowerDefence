using Entitas;
using UnityEngine;

public class PositionListener : MonoBehaviour, IEventListener, IPositionListener {
    
    GameEntity _entity;
 
    public void OnPosition(GameEntity e, Vector3 newPosition) {
        transform.position = newPosition;
    }

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddPositionListener(this);
    }
}