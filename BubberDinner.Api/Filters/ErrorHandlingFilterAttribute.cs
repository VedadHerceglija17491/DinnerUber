using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BubberDinner.Api.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is null)
            {
                return;
            }
            context.Result = new ObjectResult(new
            {
                error = context.Exception.Message
            });

            context.ExceptionHandled = true;
        }
    }
}
