using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Entitas;
using Entitas.Unity;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(EntityLink))]
public class UnityGameView : MonoBehaviour,IEventListener, IRotationListener , IPositionListener
{
    protected Contexts _contexts;
    protected GameEntity _entity;

    [LabelText("Position settings")]
    public bool listenPosition = true;
    public bool interpolatePosition = true;

    [LabelText("Rotation settings")]
    [Space]
    public bool listenRotationX = true;
    public bool listenRotationY = true;
    public bool listenRotationZ = true;
    public bool interpolateRotation = true;

    private TweenerCore<Quaternion, Quaternion, NoOptions> _rotationTween = null;
    private TweenerCore<Vector3, Vector3, VectorOptions> _positionTween = null;

    public virtual void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddRotationListener(this);
        _entity.AddPositionListener(this);
    }

    public virtual void OnPosition(GameEntity e, Vector3 newPosition) 
    {
        if (listenPosition)
        {
            if (interpolatePosition)
                _positionTween = transform.DOMove(newPosition, 0.1f);
            else
                transform.position = newPosition;
        }
    }

    public virtual void OnRotation(GameEntity entity, Quaternion value)
    {
        var newRot = value.eulerAngles;
        
        if (!listenRotationX)
            newRot.x = 0;
        if (!listenRotationY)
            newRot.y = 0;
        if (!listenRotationZ)
            newRot.z = 0;
        
        value.eulerAngles = newRot;
        if (interpolateRotation)
             _rotationTween = transform.DORotateQuaternion(value, 0.1f);
        else 
            transform.rotation = value;
    }
    
    public virtual void InitializeView(Contexts contexts, IEntity entity) 
    {
        _contexts = contexts;
        _entity = (GameEntity)entity;
        gameObject.Link(entity);
    }

    private void OnDestroy()
    {
        if (gameObject.GetEntityLink()?.entity != null)
            gameObject.Unlink();
        this.transform.DOKill(true);
    }
}