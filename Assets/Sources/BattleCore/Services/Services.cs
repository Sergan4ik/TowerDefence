public class Services
{
    public readonly ITimeService timeService;
    public readonly ILoggerService loggerService;
    public readonly IViewService viewService;

    public Services(ITimeService timeService , ILoggerService loggerService , IViewService viewService)
    {
        this.timeService = timeService;
        this.loggerService = loggerService;
        this.viewService = viewService;
    }
}