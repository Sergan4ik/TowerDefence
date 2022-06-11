//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity animatorCreatorEntity { get { return GetGroup(GameMatcher.AnimatorCreator).GetSingleEntity(); } }
    public AnimatorCreatorComponent animatorCreator { get { return animatorCreatorEntity.animatorCreator; } }
    public bool hasAnimatorCreator { get { return animatorCreatorEntity != null; } }

    public GameEntity SetAnimatorCreator(IAnimatorCreatorService newInstance) {
        if (hasAnimatorCreator) {
            throw new Entitas.EntitasException("Could not set AnimatorCreator!\n" + this + " already has an entity with AnimatorCreatorComponent!",
                "You should check if the context already has a animatorCreatorEntity before setting it or use context.ReplaceAnimatorCreator().");
        }
        var entity = CreateEntity();
        entity.AddAnimatorCreator(newInstance);
        return entity;
    }

    public void ReplaceAnimatorCreator(IAnimatorCreatorService newInstance) {
        var entity = animatorCreatorEntity;
        if (entity == null) {
            entity = SetAnimatorCreator(newInstance);
        } else {
            entity.ReplaceAnimatorCreator(newInstance);
        }
    }

    public void RemoveAnimatorCreator() {
        animatorCreatorEntity.Destroy();
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

    public AnimatorCreatorComponent animatorCreator { get { return (AnimatorCreatorComponent)GetComponent(GameComponentsLookup.AnimatorCreator); } }
    public bool hasAnimatorCreator { get { return HasComponent(GameComponentsLookup.AnimatorCreator); } }

    public void AddAnimatorCreator(IAnimatorCreatorService newInstance) {
        var index = GameComponentsLookup.AnimatorCreator;
        var component = (AnimatorCreatorComponent)CreateComponent(index, typeof(AnimatorCreatorComponent));
        component.instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceAnimatorCreator(IAnimatorCreatorService newInstance) {
        var index = GameComponentsLookup.AnimatorCreator;
        var component = (AnimatorCreatorComponent)CreateComponent(index, typeof(AnimatorCreatorComponent));
        component.instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveAnimatorCreator() {
        RemoveComponent(GameComponentsLookup.AnimatorCreator);
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

    static Entitas.IMatcher<GameEntity> _matcherAnimatorCreator;

    public static Entitas.IMatcher<GameEntity> AnimatorCreator {
        get {
            if (_matcherAnimatorCreator == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnimatorCreator);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnimatorCreator = matcher;
            }

            return _matcherAnimatorCreator;
        }
    }
}