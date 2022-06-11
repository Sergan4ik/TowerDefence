public class Services
{
    public readonly ITimeService timeService;
    public readonly ILoggerService loggerService;
    public readonly IViewService viewService;
    public readonly IGravityService gravityService;
    public readonly ISplineFollowerCreatorService splineFollowerCreatorService;
    public readonly IAnimatorCreatorService animatorCreatorService;

    public Services(ITimeService timeService , ILoggerService loggerService , IViewService viewService , IGravityService gravityService , ISplineFollowerCreatorService splineFollowerCreatorService , IAnimatorCreatorService animatorCreatorService)
    {
        this.timeService = timeService;
        this.loggerService = loggerService;
        this.viewService = viewService;
        this.gravityService = gravityService;
        this.splineFollowerCreatorService = splineFollowerCreatorService;
        this.animatorCreatorService = animatorCreatorService;
    }
}