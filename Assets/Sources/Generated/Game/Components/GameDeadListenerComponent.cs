//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DeadListenerComponent deadListener { get { return (DeadListenerComponent)GetComponent(GameComponentsLookup.DeadListener); } }
    public bool hasDeadListener { get { return HasComponent(GameComponentsLookup.DeadListener); } }

    public void AddDeadListener(System.Collections.Generic.List<IDeadListener> newValue) {
        var index = GameComponentsLookup.DeadListener;
        var component = (DeadListenerComponent)CreateComponent(index, typeof(DeadListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDeadListener(System.Collections.Generic.List<IDeadListener> newValue) {
        var index = GameComponentsLookup.DeadListener;
        var component = (DeadListenerComponent)CreateComponent(index, typeof(DeadListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDeadListener() {
        RemoveComponent(GameComponentsLookup.DeadListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDeadListener;

    public static Entitas.IMatcher<GameEntity> DeadListener {
        get {
            if (_matcherDeadListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DeadListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDeadListener = matcher;
            }

            return _matcherDeadListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddDeadListener(IDeadListener value) {
        var listeners = hasDeadListener
            ? deadListener.value
            : new System.Collections.Generic.List<IDeadListener>();
        listeners.Add(value);
        ReplaceDeadListener(listeners);
    }

    public void RemoveDeadListener(IDeadListener value, bool removeComponentWhenEmpty = true) {
        var listeners = deadListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveDeadListener();
        } else {
            ReplaceDeadListener(listeners);
        }
    }
}
