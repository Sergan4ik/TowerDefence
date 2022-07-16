using System;
using Entitas;
using UnityEngine;
using UnityEngine.UIElements;

public class UnityViewService : IViewService
{
    public UnityGameView LoadAsset(Contexts contexts, IEntity entity, string assetName , string assetPath)
    {
        var viewGo = GameObject.Instantiate(Resources.Load<GameObject>($"{assetPath}/{assetName}"),
            new Vector3(0, -999, 0) , Quaternion.identity);
        
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