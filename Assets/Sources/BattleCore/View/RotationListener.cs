using Entitas;
using UnityEngine;

public class RotationListener : MonoBehaviour, IEventListener, IRotationListener
{
    public bool listenX = true;
    public bool listenY = true;
    public bool listenZ = true;
    
    GameEntity _entity;
 
    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddRotationListener(this);
    }

    public void OnRotation(GameEntity entity, Quaternion value)
    {
        var newRot = value.eulerAngles;
        
        if (!listenX)
            newRot.x = 0;
        if (!listenY)
            newRot.y = 0;
        if (!listenZ)
            newRot.z = 0;
        value.eulerAngles = newRot;
        
        transform.rotation = value;
    }
}