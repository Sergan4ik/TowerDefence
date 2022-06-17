using System;
using Entitas;
using UnityEngine;

public class UnityViewService : IViewService
{
    public UnityGameView LoadAsset(Contexts contexts, IEntity entity, string assetName , string assetPath)
    {
        var viewGo = GameObject.Instantiate(Resources.Load<GameObject>($"{assetPath}/{assetName}"));
        
        if (viewGo != null) {
            var viewController = viewGo.GetComponent<UnityGameView>();
            if(viewController != null) 
                viewController.InitializeView(contexts, entity);

            var eventListeners = viewGo.GetComponents<IEventListener>();
            
            foreach(var listener in eventListeners) 
                listener.RegisterListeners(entity);

            return viewController;
        }

        throw new ArgumentException($"Can't instantiate prefab {assetName}");
    }
}