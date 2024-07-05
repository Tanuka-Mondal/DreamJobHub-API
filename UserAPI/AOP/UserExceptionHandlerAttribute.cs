using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Exceptions;

namespace UserAPI.AOP
{
    public class UserExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(DuplicateUserException))
            {
                context.Result = new ConflictObjectResult(context.Exception.Message);
            }
            else if (context.Exception.GetType() == typeof(UserNotFoundException))
            {
                context.Result = new ConflictObjectResult(context.Exception.Message);
            }

        }
    }
}
