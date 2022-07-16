using Entitas.Unity;
using Mono.CompilerServices.SymbolWriter;
using UnityEngine;

public abstract class OnDeadBehaviour : MonoBehaviour
{
    public EntityLink entityLink;
    public virtual void OnDead(GameEntity entity)
    {
        entityLink.Unlink();
        entity.Destroy();
    }
}