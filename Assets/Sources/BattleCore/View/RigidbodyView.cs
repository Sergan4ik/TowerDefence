using System;
using Entitas;
using Entitas.Unity;
using Sirenix.OdinInspector;
using UnityEngine;

public interface IRigidbody
{
    Vector3 velocity { get; set; }
    public void AddForce(Vector3 value);
    public void AddImpulse(Vector3 value);
}

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyView : UnityGameView , IRigidbody , ISyncPosition
{
    public Vector3 position => rigidbody.position;

    public new Rigidbody rigidbody => _rigidbody = _rigidbody ? _rigidbody : GetComponent<Rigidbody>();
    private Rigidbody _rigidbody;
    
    public Vector3 velocity
    {
        get => rigidbody.velocity;
        set => rigidbody.velocity = value;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void AddImpulse(Vector3 value)
    {
        rigidbody.AddForce(value, ForceMode.Impulse);
    }

    public void AddForce(Vector3 value)
    {
        rigidbody.AddForce(value, ForceMode.Force);
    }
    
    [Button]
    public void AddForce(Vector3 value , ForceMode mode)
    {
        rigidbody.AddForce(value, mode);
    }

    public override void RegisterListeners(IEntity entity)
    {
        base.RegisterListeners(entity);
        transform.position = _entity.position.value;
        _entity.RemovePositionListener();
        _entity.RemoveRotationListener();

        _entity.AddRigidbody(this);
        _entity.AddSyncPosition(this);
    }

    protected void OnDestroy()
    {
        if (gameObject.GetEntityLink()?.entity != null)
            gameObject.Unlink();
    }

}