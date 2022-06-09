using Entitas;
using UnityEngine;

public class UnityGameView : MonoBehaviour, IViewController {

    protected Contexts _contexts;
    protected GameEntity _entity;

    public Vector3 Position {
        get => transform.position;
        set => transform.position = value;
    }

    public Vector3 Scale
    {
        get => transform.localScale;
        set => transform.localScale = value;
    }

    public bool Active
    {
        get => gameObject.activeSelf;
        set => gameObject.SetActive(value);
    }

    public void InitializeView(Contexts contexts, IEntity entity) {
        _contexts = contexts;
        _entity = (GameEntity)entity;
    }

    public void DestroyView() {
        Destroy(this);
    }   
}