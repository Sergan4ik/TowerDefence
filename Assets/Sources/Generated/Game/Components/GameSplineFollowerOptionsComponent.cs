//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SplineFollowerOptions splineFollowerOptions { get { return (SplineFollowerOptions)GetComponent(GameComponentsLookup.SplineFollowerOptions); } }
    public bool hasSplineFollowerOptions { get { return HasComponent(GameComponentsLookup.SplineFollowerOptions); } }

    public void AddSplineFollowerOptions(float newSpeed, UnityEngine.Vector3 newOffset) {
        var index = GameComponentsLookup.SplineFollowerOptions;
        var component = (SplineFollowerOptions)CreateComponent(index, typeof(SplineFollowerOptions));
        component.speed = newSpeed;
        component.offset = newOffset;
        AddComponent(index, component);
    }

    public void ReplaceSplineFollowerOptions(float newSpeed, UnityEngine.Vector3 newOffset) {
        var index = GameComponentsLookup.SplineFollowerOptions;
        var component = (SplineFollowerOptions)CreateComponent(index, typeof(SplineFollowerOptions));
        component.speed = newSpeed;
        component.offset = newOffset;
        ReplaceComponent(index, component);
    }

    public void RemoveSplineFollowerOptions() {
        RemoveComponent(GameComponentsLookup.SplineFollowerOptions);
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

    static Entitas.IMatcher<GameEntity> _matcherSplineFollowerOptions;

    public static Entitas.IMatcher<GameEntity> SplineFollowerOptions {
        get {
            if (_matcherSplineFollowerOptions == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SplineFollowerOptions);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSplineFollowerOptions = matcher;
            }

            return _matcherSplineFollowerOptions;
        }
    }
}
