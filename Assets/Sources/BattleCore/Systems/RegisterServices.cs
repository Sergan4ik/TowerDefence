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
public class RegisterGravityService : IInitializeSystem
{
    private readonly Contexts _contexts;
    private readonly IGravityService _gravityService;
    public RegisterGravityService(Contexts contexts, IGravityService gravityService)
    {
        _gravityService = gravityService;
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.game.ReplacePhysicsService(_gravityService);
    }
}
public class RegisterSplineFollowerService : IInitializeSystem
{
    private readonly Contexts _contexts;
    private readonly ISplineFollowerCreatorService _splineFollowerCreatorService;
    public RegisterSplineFollowerService(Contexts contexts, ISplineFollowerCreatorService splineFollowerCreatorService)
    {
        _splineFollowerCreatorService = splineFollowerCreatorService;
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.game.ReplaceSplineFollowerCreatorService(_splineFollowerCreatorService);
    }
}
public class RegisterAnimatorCreatorService : IInitializeSystem
{
    private readonly Contexts _contexts;
    private readonly IAnimatorCreatorService _splineFollowerCreatorService;
    public RegisterAnimatorCreatorService(Contexts contexts, IAnimatorCreatorService splineFollowerCreatorService)
    {
        _splineFollowerCreatorService = splineFollowerCreatorService;
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.game.ReplaceAnimatorCreator(_splineFollowerCreatorService);
    }
}
public sealed class RegisterPathConfig : IInitializeSystem
{
    private readonly Contexts _contexts;
    private readonly IGraphCreatorService _graphCreatorServiceService;

    public RegisterPathConfig(Contexts contexts , IGraphCreatorService graphCreatorServiceService)
    {
        _contexts = contexts;
        _graphCreatorServiceService = graphCreatorServiceService;
    }


    public void Initialize()
    {
        _contexts.game.SetLevelMap(_graphCreatorServiceService.AllPaths);
    }
}