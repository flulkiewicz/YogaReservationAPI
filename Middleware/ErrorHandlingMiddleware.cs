namespace YogaReservationAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error {ex} with message {ex.Message}");
                context.Response.StatusCode = 500;

                var response = new ServiceResponse<string>();
                response.Data = ex.Message;
                response.Success = false;
                response.Message = "Internal Server Error";

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
