using System.Net;
using System.Text.Json;

namespace SmartInventory.Api.Middlewares
{
    public sealed class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware( RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Unhadled Exception");
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex) {

            var statusCode = ex switch
            {
                ArgumentException => HttpStatusCode.BadRequest,
                KeyNotFoundException => HttpStatusCode.NotFound,
                _=>HttpStatusCode.InternalServerError
            };
            var response = new ApiErrorResponse {
                StatusCode = (int)statusCode,
                Message = ex.Message,
                TraceId = context.TraceIdentifier,
                Detail = statusCode == HttpStatusCode.InternalServerError?"An Unexpected error occured.":null
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = response.StatusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
