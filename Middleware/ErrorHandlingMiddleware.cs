using Microsoft.AspNetCore.Http.HttpResults;
using YogaReservationAPI.Exceptions;

namespace YogaReservationAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        private ServiceResponse<string> ServiceResponse(Exception ex, string message)
        {
            var response = new ServiceResponse<string>();
            response.Data = ex.Message;
            response.Success = false;
            response.Message = message;

            return response;
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException notFound)
            {
                _logger.LogError($"Error {notFound} with message {notFound.Message}");
                context.Response.StatusCode = 404;

                var response = ServiceResponse(notFound, "Resource not found.");

                await context.Response.WriteAsJsonAsync(response);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error {ex} with message {ex.Message}");
                context.Response.StatusCode = 500;

                var response = ServiceResponse(ex, "Internal Server Error");

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
