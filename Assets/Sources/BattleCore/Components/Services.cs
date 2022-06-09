using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique]
public sealed class TimeServiceComponent : IComponent
{
    public ITimeService instance;
}
[Unique]
public sealed class LoggerServiceComponent : IComponent
{
    public ILoggerService instance;
}
[Unique]
public sealed class ViewServiceComponent : IComponent
{
    public IViewService instance;
}