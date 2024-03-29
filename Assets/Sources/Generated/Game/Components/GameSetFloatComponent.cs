//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SetFloatComponent setFloat { get { return (SetFloatComponent)GetComponent(GameComponentsLookup.SetFloat); } }
    public bool hasSetFloat { get { return HasComponent(GameComponentsLookup.SetFloat); } }

    public void AddSetFloat(string newParameterName, float newValue) {
        var index = GameComponentsLookup.SetFloat;
        var component = (SetFloatComponent)CreateComponent(index, typeof(SetFloatComponent));
        component.parameterName = newParameterName;
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSetFloat(string newParameterName, float newValue) {
        var index = GameComponentsLookup.SetFloat;
        var component = (SetFloatComponent)CreateComponent(index, typeof(SetFloatComponent));
        component.parameterName = newParameterName;
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSetFloat() {
        RemoveComponent(GameComponentsLookup.SetFloat);
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

    static Entitas.IMatcher<GameEntity> _matcherSetFloat;

    public static Entitas.IMatcher<GameEntity> SetFloat {
        get {
            if (_matcherSetFloat == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SetFloat);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSetFloat = matcher;
            }

            return _matcherSetFloat;
        }
    }
}
