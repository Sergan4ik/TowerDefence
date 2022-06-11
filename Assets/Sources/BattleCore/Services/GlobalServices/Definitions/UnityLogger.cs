using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class UnityLogger : ILoggerService
{
    public void LogMessage(LogMessageComponent messageComponent)
    {
        Debug.Log(messageComponent.message);
    }

    public void LogWarning(LogWarningComponent warningComponent)
    {
        Debug.LogWarning(warningComponent.message);
    }

    public void LogError(LogErrorComponent errorComponent)
    {
        Debug.LogError(errorComponent.message);
    }
}