public interface ILoggerService
{
    public void LogMessage(LogMessageComponent messageComponent);
    public void LogWarning(LogWarningComponent warningComponent);
    public void LogError(LogErrorComponent errorComponent);
}