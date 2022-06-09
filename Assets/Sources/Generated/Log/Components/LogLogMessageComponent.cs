//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogEntity {

    public LogMessageComponent logMessage { get { return (LogMessageComponent)GetComponent(LogComponentsLookup.LogMessage); } }
    public bool hasLogMessage { get { return HasComponent(LogComponentsLookup.LogMessage); } }

    public void AddLogMessage(string newMessage) {
        var index = LogComponentsLookup.LogMessage;
        var component = (LogMessageComponent)CreateComponent(index, typeof(LogMessageComponent));
        component.message = newMessage;
        AddComponent(index, component);
    }

    public void ReplaceLogMessage(string newMessage) {
        var index = LogComponentsLookup.LogMessage;
        var component = (LogMessageComponent)CreateComponent(index, typeof(LogMessageComponent));
        component.message = newMessage;
        ReplaceComponent(index, component);
    }

    public void RemoveLogMessage() {
        RemoveComponent(LogComponentsLookup.LogMessage);
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
public sealed partial class LogMatcher {

    static Entitas.IMatcher<LogEntity> _matcherLogMessage;

    public static Entitas.IMatcher<LogEntity> LogMessage {
        get {
            if (_matcherLogMessage == null) {
                var matcher = (Entitas.Matcher<LogEntity>)Entitas.Matcher<LogEntity>.AllOf(LogComponentsLookup.LogMessage);
                matcher.componentNames = LogComponentsLookup.componentNames;
                _matcherLogMessage = matcher;
            }

            return _matcherLogMessage;
        }
    }
}
