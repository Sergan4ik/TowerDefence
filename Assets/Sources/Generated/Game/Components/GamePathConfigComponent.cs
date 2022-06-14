//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity pathConfigEntity { get { return GetGroup(GameMatcher.PathConfig).GetSingleEntity(); } }
    public PathConfigComponent pathConfig { get { return pathConfigEntity.pathConfig; } }
    public bool hasPathConfig { get { return pathConfigEntity != null; } }

    public GameEntity SetPathConfig(System.Collections.Generic.List<System.Collections.Generic.List<System.ValueTuple<int, string>>> newPathVariants) {
        if (hasPathConfig) {
            throw new Entitas.EntitasException("Could not set PathConfig!\n" + this + " already has an entity with PathConfigComponent!",
                "You should check if the context already has a pathConfigEntity before setting it or use context.ReplacePathConfig().");
        }
        var entity = CreateEntity();
        entity.AddPathConfig(newPathVariants);
        return entity;
    }

    public void ReplacePathConfig(System.Collections.Generic.List<System.Collections.Generic.List<System.ValueTuple<int, string>>> newPathVariants) {
        var entity = pathConfigEntity;
        if (entity == null) {
            entity = SetPathConfig(newPathVariants);
        } else {
            entity.ReplacePathConfig(newPathVariants);
        }
    }

    public void RemovePathConfig() {
        pathConfigEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PathConfigComponent pathConfig { get { return (PathConfigComponent)GetComponent(GameComponentsLookup.PathConfig); } }
    public bool hasPathConfig { get { return HasComponent(GameComponentsLookup.PathConfig); } }

    public void AddPathConfig(System.Collections.Generic.List<System.Collections.Generic.List<System.ValueTuple<int, string>>> newPathVariants) {
        var index = GameComponentsLookup.PathConfig;
        var component = (PathConfigComponent)CreateComponent(index, typeof(PathConfigComponent));
        component.pathVariants = newPathVariants;
        AddComponent(index, component);
    }

    public void ReplacePathConfig(System.Collections.Generic.List<System.Collections.Generic.List<System.ValueTuple<int, string>>> newPathVariants) {
        var index = GameComponentsLookup.PathConfig;
        var component = (PathConfigComponent)CreateComponent(index, typeof(PathConfigComponent));
        component.pathVariants = newPathVariants;
        ReplaceComponent(index, component);
    }

    public void RemovePathConfig() {
        RemoveComponent(GameComponentsLookup.PathConfig);
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

    static Entitas.IMatcher<GameEntity> _matcherPathConfig;

    public static Entitas.IMatcher<GameEntity> PathConfig {
        get {
            if (_matcherPathConfig == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PathConfig);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPathConfig = matcher;
            }

            return _matcherPathConfig;
        }
    }
}
