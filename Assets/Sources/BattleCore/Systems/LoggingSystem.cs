using System.Collections.Generic;
using Entitas;

public class LoggingSystem : ReactiveSystem<LogEntity>, ICleanupSystem
{
    private readonly ILoggerService _loggerService;
    private IGroup<LogEntity> _logs;

    public LoggingSystem(IContext<LogEntity> context, ILoggerService loggerService) : base(context)
    {
        _logs = context.GetGroup(LogMatcher.AnyOf(
            LogMatcher.LogMessage
            , LogMatcher.LogWarning
            , LogMatcher.LogError)
        );
        _loggerService = loggerService;
    }

    protected override ICollector<LogEntity> GetTrigger(IContext<LogEntity> context)
    {
        return context.CreateCollector(LogMatcher.AnyOf(LogMatcher.LogMessage, LogMatcher.LogWarning,
            LogMatcher.LogError));
    }

    protected override bool Filter(LogEntity entity)
    {
        return entity.hasLogMessage || entity.hasLogWarning || entity.hasLogError;
    }

    protected override void Execute(List<LogEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.hasLogError)
            {
                _loggerService.LogError(entity.logError);
            }

            if (entity.hasLogWarning)
            {
                _loggerService.LogWarning(entity.logWarning);
            }

            if (entity.hasLogMessage)
            {
                _loggerService.LogMessage(entity.logMessage);
            }
        }
    }

    public void Cleanup()
    {
        foreach (var log in _logs.GetEntities())
        {
            log.Destroy();
        }
    }
}