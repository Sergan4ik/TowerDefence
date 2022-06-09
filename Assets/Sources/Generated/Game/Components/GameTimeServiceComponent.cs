//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity timeServiceEntity { get { return GetGroup(GameMatcher.TimeService).GetSingleEntity(); } }
    public TimeServiceComponent timeService { get { return timeServiceEntity.timeService; } }
    public bool hasTimeService { get { return timeServiceEntity != null; } }

    public GameEntity SetTimeService(ITimeService newInstance) {
        if (hasTimeService) {
            throw new Entitas.EntitasException("Could not set TimeService!\n" + this + " already has an entity with TimeServiceComponent!",
                "You should check if the context already has a timeServiceEntity before setting it or use context.ReplaceTimeService().");
        }
        var entity = CreateEntity();
        entity.AddTimeService(newInstance);
        return entity;
    }

    public void ReplaceTimeService(ITimeService newInstance) {
        var entity = timeServiceEntity;
        if (entity == null) {
            entity = SetTimeService(newInstance);
        } else {
            entity.ReplaceTimeService(newInstance);
        }
    }

    public void RemoveTimeService() {
        timeServiceEntity.Destroy();
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

    public TimeServiceComponent timeService { get { return (TimeServiceComponent)GetComponent(GameComponentsLookup.TimeService); } }
    public bool hasTimeService { get { return HasComponent(GameComponentsLookup.TimeService); } }

    public void AddTimeService(ITimeService newInstance) {
        var index = GameComponentsLookup.TimeService;
        var component = (TimeServiceComponent)CreateComponent(index, typeof(TimeServiceComponent));
        component.instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceTimeService(ITimeService newInstance) {
        var index = GameComponentsLookup.TimeService;
        var component = (TimeServiceComponent)CreateComponent(index, typeof(TimeServiceComponent));
        component.instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveTimeService() {
        RemoveComponent(GameComponentsLookup.TimeService);
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

    static Entitas.IMatcher<GameEntity> _matcherTimeService;

    public static Entitas.IMatcher<GameEntity> TimeService {
        get {
            if (_matcherTimeService == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TimeService);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTimeService = matcher;
            }

            return _matcherTimeService;
        }
    }
}
