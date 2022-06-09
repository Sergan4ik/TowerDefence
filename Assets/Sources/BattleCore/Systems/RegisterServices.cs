using Entitas;

public sealed class RegisterTimeService : IInitializeSystem
{
    private readonly Contexts _contexts;
    private readonly ITimeService _timeService;

    public RegisterTimeService(Contexts contexts, ITimeService timeService)
    {
        _contexts = contexts;
        _timeService = timeService;
    }
    
    public void Initialize()
    {
        _contexts.game.ReplaceTimeService(_timeService);
    }
}
public sealed class RegisterLoggerService : IInitializeSystem
{
    private readonly Contexts _contexts;
    private readonly ILoggerService _loggerService;

    public RegisterLoggerService(Contexts contexts, ILoggerService loggerService)
    {
        _contexts = contexts;
        _loggerService = loggerService;
    }
    
    public void Initialize()
    {
        _contexts.game.ReplaceLoggerService(_loggerService);
    }
}
public sealed class RegisterViewService : IInitializeSystem
{
    private readonly Contexts _contexts;
    private readonly IViewService _viewService;

    public RegisterViewService(Contexts contexts, IViewService viewService)
    {
        _contexts = contexts;
        _viewService = viewService;
    }
    
    public void Initialize()
    {
        _contexts.game.ReplaceViewService(_viewService);
    }
}
