using Entitas;
using Entitas.CodeGeneration.Attributes;

[Log]
public sealed class LogMessageComponent : IComponent { public string message; }
[Log]
public sealed class LogWarningComponent : IComponent { public string message; }
[Log]
public sealed class LogErrorComponent : IComponent { public string message; }