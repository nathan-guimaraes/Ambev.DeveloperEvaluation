using Ambev.DeveloperEvaluation.Common.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Ambev.DeveloperEvaluation.WebApi.Filters;

public class LogActionExecutionFilter : IActionFilter
{
    private readonly ILogger<LogActionExecutionFilter> _logger;
    private readonly Stopwatch _stopwatch = new();

    public LogActionExecutionFilter(ILogger<LogActionExecutionFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var controllerName = context.Controller.GetType().Name;
        var actionName = context.ActionDescriptor.DisplayName;

        _logger.LogActionStart(controllerName, actionName);
        _stopwatch.Restart();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();

        var controllerName = context.Controller.GetType().Name;
        var actionName = context.ActionDescriptor.DisplayName;

        _logger.LogActionFinished(_stopwatch.ElapsedMilliseconds, controllerName, actionName);
    }
}
