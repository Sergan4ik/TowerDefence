public sealed class LogSystems : Feature
{
    public LogSystems(Contexts contexts , Services services)
    {
        Add(new LoggingSystem(contexts.log , services.loggerService));
    }
}

public sealed class ServiceRegistrationSystems : Feature
{
    public ServiceRegistrationSystems(Contexts contexts, Services services)
    {
        Add(new RegisterTimeService(contexts, services.timeService));
        Add(new RegisterLoggerService(contexts, services.loggerService));
        Add(new RegisterViewService(contexts, services.viewService));
        Add(new RegisterGravityService(contexts, services.gravityService));
        Add(new RegisterSplineFollowerService(contexts, services.splineFollowerCreatorService));
        Add(new RegisterAnimatorCreatorService(contexts, services.animatorCreatorService));
        Add(new RegisterPathConfig(contexts, services.graphCreatorService));
    }
}

public sealed class GameSystems : Feature
{
    public GameSystems(Contexts contexts, Services services)
    {
        Add(new LoadAssetSystem(contexts, services.viewService));
        Add(new CreateSplineFollowerObjectSystem(contexts, services.splineFollowerCreatorService));
        Add(new CreateAnimatorSystem(contexts, services.animatorCreatorService));

        Add(new RotationEventSystem(contexts));
        Add(new HealthEventSystem(contexts));
        Add(new PositionEventSystem(contexts));
        Add(new DeadEventSystem(contexts));

        Add(new MoveSystem(contexts, services.timeService));
        Add(new GravitySystem(contexts, services.gravityService, services.timeService));

        Add(new SplineFollowerSystem(contexts));
        Add(new SplineAnimationSystem(contexts));
        Add(new PathRedirectSystem(contexts));
        Add(new PathEndReachSystem(contexts));

        Add(new TargetFindSystem(contexts));
        Add(new TargetLookAtSystem(contexts));

        Add(new ShootingSystem(contexts));

        Add(new AnimatorSystem(contexts));

        Add(new DamageSystem(contexts));
    }
}