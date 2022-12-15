using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PointCollector.API.Common.ExceptionHandling
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var requestBody = "";
            var requestPath = context.Request.Path.Value;
            using (StreamReader stream = new StreamReader(context.Request.Body))
            {
                requestBody = await stream.ReadToEndAsync();
            }

            _logger.LogError($"Unhandled 500 error: Path: {requestPath} ---- Body: {requestBody}");
            context.Response.ContentType = "application/json";
            var response = context.Response;
            
            var problemDetails = new ProblemDetails // TODO: replace it with custom error class.. DONT USE PROBLEMDETAILS
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Something went wrong.",
                Type = "Internal Server Error",
                Detail = "Please try again later or contact us.",
                Instance = string.Empty,
            };

            var result = JsonConvert.SerializeObject(problemDetails);

            await context.Response.WriteAsync(result);
        }
    }
}
