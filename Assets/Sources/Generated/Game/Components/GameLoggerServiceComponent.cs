//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity loggerServiceEntity { get { return GetGroup(GameMatcher.LoggerService).GetSingleEntity(); } }
    public LoggerServiceComponent loggerService { get { return loggerServiceEntity.loggerService; } }
    public bool hasLoggerService { get { return loggerServiceEntity != null; } }

    public GameEntity SetLoggerService(ILoggerService newInstance) {
        if (hasLoggerService) {
            throw new Entitas.EntitasException("Could not set LoggerService!\n" + this + " already has an entity with LoggerServiceComponent!",
                "You should check if the context already has a loggerServiceEntity before setting it or use context.ReplaceLoggerService().");
        }
        var entity = CreateEntity();
        entity.AddLoggerService(newInstance);
        return entity;
    }

    public void ReplaceLoggerService(ILoggerService newInstance) {
        var entity = loggerServiceEntity;
        if (entity == null) {
            entity = SetLoggerService(newInstance);
        } else {
            entity.ReplaceLoggerService(newInstance);
        }
    }

    public void RemoveLoggerService() {
        loggerServiceEntity.Destroy();
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

    public LoggerServiceComponent loggerService { get { return (LoggerServiceComponent)GetComponent(GameComponentsLookup.LoggerService); } }
    public bool hasLoggerService { get { return HasComponent(GameComponentsLookup.LoggerService); } }

    public void AddLoggerService(ILoggerService newInstance) {
        var index = GameComponentsLookup.LoggerService;
        var component = (LoggerServiceComponent)CreateComponent(index, typeof(LoggerServiceComponent));
        component.instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceLoggerService(ILoggerService newInstance) {
        var index = GameComponentsLookup.LoggerService;
        var component = (LoggerServiceComponent)CreateComponent(index, typeof(LoggerServiceComponent));
        component.instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveLoggerService() {
        RemoveComponent(GameComponentsLookup.LoggerService);
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

    static Entitas.IMatcher<GameEntity> _matcherLoggerService;

    public static Entitas.IMatcher<GameEntity> LoggerService {
        get {
            if (_matcherLoggerService == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LoggerService);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLoggerService = matcher;
            }

            return _matcherLoggerService;
        }
    }
}
