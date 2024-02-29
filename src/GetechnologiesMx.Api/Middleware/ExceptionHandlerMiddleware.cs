using GetechnologiesMx.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace GetechnologiesMx.Api.Middleware {
    public class ExceptionHandlerMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context) {
            try {
                await _next(context);
            }
            catch (Exception ex) {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception) {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch (exception)
            {
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case NotFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case Exception:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }

            _logger.LogError(exception.Message);
            context.Response.StatusCode = (int)httpStatusCode;

            if (result == string.Empty) {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
