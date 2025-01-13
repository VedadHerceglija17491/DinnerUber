using System.Net;
using System.Text.Json;

namespace BubberDinner.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;       
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExcepctionAsync(context, ex);
            }
        }

        private static Task HandleExcepctionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { error = "An error occured" });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;
            
            return context.Response.WriteAsync(result);
        }
    }
}
