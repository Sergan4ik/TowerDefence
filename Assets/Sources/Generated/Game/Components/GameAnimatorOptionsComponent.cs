//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnimatorOptionsComponent animatorOptions { get { return (AnimatorOptionsComponent)GetComponent(GameComponentsLookup.AnimatorOptions); } }
    public bool hasAnimatorOptions { get { return HasComponent(GameComponentsLookup.AnimatorOptions); } }

    public void AddAnimatorOptions(float newPlaceholder) {
        var index = GameComponentsLookup.AnimatorOptions;
        var component = (AnimatorOptionsComponent)CreateComponent(index, typeof(AnimatorOptionsComponent));
        component.placeholder = newPlaceholder;
        AddComponent(index, component);
    }

    public void ReplaceAnimatorOptions(float newPlaceholder) {
        var index = GameComponentsLookup.AnimatorOptions;
        var component = (AnimatorOptionsComponent)CreateComponent(index, typeof(AnimatorOptionsComponent));
        component.placeholder = newPlaceholder;
        ReplaceComponent(index, component);
    }

    public void RemoveAnimatorOptions() {
        RemoveComponent(GameComponentsLookup.AnimatorOptions);
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

    static Entitas.IMatcher<GameEntity> _matcherAnimatorOptions;

    public static Entitas.IMatcher<GameEntity> AnimatorOptions {
        get {
            if (_matcherAnimatorOptions == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnimatorOptions);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnimatorOptions = matcher;
            }

            return _matcherAnimatorOptions;
        }
    }
}
