using System;
using Entitas;
using Entitas.Unity;
using UnityEngine;

[RequireComponent(typeof(EntityLink))]
public class UnityGameView : MonoBehaviour {

    protected Contexts _contexts;
    protected GameEntity _entity;

    public void InitializeView(Contexts contexts, IEntity entity) 
    {
        _contexts = contexts;
        _entity = (GameEntity)entity;
        gameObject.Link(entity);
    }
}