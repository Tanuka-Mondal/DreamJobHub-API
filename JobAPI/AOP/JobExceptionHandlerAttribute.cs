using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using JobAPI.Exceptions;

namespace JobAPI.AOP
{
    public class JobExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(DuplicateJobException))
            {
                context.Result = new ConflictObjectResult(context.Exception.Message);
            }
            else if (context.Exception.GetType() == typeof(JobNotFoundException))
            {
                context.Result = new ConflictObjectResult(context.Exception.Message);
            }

        }
    }
}
