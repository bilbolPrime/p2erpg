using BilbolStack.Boonamai.P2ERPG.Common.Constants;
using System.Text.Json;

namespace BilbolStack.Boonamai.P2ERPG.ApiMiddleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, RequestDelegate next)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            string message = string.Empty;
            bool success = false;
            try
            {
                await _next(context);
                success = true;
            }
            catch (UnauthorizedAccessException ex)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                message = ex.Message;
            }
            catch (ArgumentException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                message = "Something went wrong";
                var account = GetPublicAccount(context);
                _logger.LogError($"Error for {GetPublicAccount(context)} {ex.Message}", ex);
            }

            if (!success)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IgnoreNullValues = true
                };

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { message }, options));
            }
        }

        private string GetPublicAccount(HttpContext context)
        {
            try
            {
                var account = context.Request.Headers[Headers.WALLET].FirstOrDefault();
                return account ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
