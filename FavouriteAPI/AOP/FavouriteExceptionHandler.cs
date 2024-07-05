using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using FavouriteAPI.Exceptions;

namespace FavouriteAPI.AOP
{
    public class FavouriteExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(DuplicateFavouriteException))
            {
                context.Result = new ConflictObjectResult(context.Exception.Message);
            }
            else if(context.Exception.GetType() == typeof(FavouriteNotFoundException))
            {
                context.Result = new ConflictObjectResult(context.Exception.Message);
            }

        }
    }
}
