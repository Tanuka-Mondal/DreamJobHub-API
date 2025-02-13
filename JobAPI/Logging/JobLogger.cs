﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace JobAPI.Logging
{
    public class JobLogger : ActionFilterAttribute
    {
        readonly string filename = "JobLogging.txt";
        string logFilePath;
        DateTime startTime;
        DateTime endTime;
        TimeSpan totalTime;
        public JobLogger(IWebHostEnvironment environment)
        {
            string rootPath = environment.ContentRootPath;
            logFilePath = rootPath + "\\Logging" + $"\\{filename}";
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            startTime = DateTime.Now;
            var controllerName = ((ControllerBase)filterContext.Controller)
                .ControllerContext.ActionDescriptor.ControllerName;
            var actionName = ((ControllerBase)filterContext.Controller)
                .ControllerContext.ActionDescriptor.ActionName;
            File.AppendAllText(logFilePath, $"Start Time: {startTime} \tControllerName: {controllerName} \tActionName: {actionName} \t ");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            endTime = DateTime.Now;
            totalTime = endTime - startTime;
            File.AppendAllText(logFilePath, $"End Time: {endTime} \tTotal time: {totalTime.TotalMilliseconds}\n");
        }
    }
}
