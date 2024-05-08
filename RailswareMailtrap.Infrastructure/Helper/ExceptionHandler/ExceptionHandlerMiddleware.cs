using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace RailswareMailtrap.Infrastructure.Helper.ExceptionHandler
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;


        private static readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            Error = (sender, args) => args.ErrorContext.Handled = true,
            Formatting = Formatting.None,
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public virtual async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                if (context.Response.HasStarted)
                {
                    // If hit here, then the response was returned, but there was an error in some middleware
                    return;
                }


                var problemresponse = CreateProblemDetailsFromException(ex);
                await SendErrorResponseAsync(context, ex, problemresponse).ConfigureAwait(false);
            }
        }

        private ProblemDetails CreateProblemDetailsFromException(Exception ex)
        {
            CommonException exception = ex as CommonException;
            if (exception != null)
            {
                switch (exception)
                {

                    case NotFoundException e: return CreateProblemDetails(nameof(NotFoundException), "Resource not found", HttpStatusCode.NotFound, ex, e.Code);
                    case ValidationException e: return CreateProblemDetails(nameof(ValidationException), "Resource validation error", HttpStatusCode.BadRequest, ex, e.Code);
                    case UnauthorizedException e: return CreateProblemDetails(nameof(UnauthorizedException), "Authorization error", HttpStatusCode.Unauthorized, ex, e.Code);
                    default /* other exceptions */:

                        return new ProblemDetails
                        {
                            Type = nameof(InternalServerErrorException),
                            Title = "Internal error",
                            Status = (int)HttpStatusCode.InternalServerError,
                            Detail = "Something went wrong"
                        };
                }
            }
            else
            {
                return new ProblemDetails
                {
                    Type = nameof(InternalServerErrorException),
                    Title = "Internal error",
                    Status = (int)HttpStatusCode.InternalServerError,
                    Detail = "Something went wrong"
                };
            }
        }

        private ProblemDetails CreateProblemDetails(string type, string title, HttpStatusCode status, Exception ex, int? resultCode = null)
        {
            return new ProblemDetails
            {
                Type = type,
                Title = title,
                Status = (int)status,
                Detail = ex.Message,
                ResultCode = resultCode
            };
        }

        private async Task SendErrorResponseAsync(HttpContext context, Exception ex, ProblemDetails problem)
        {
            var response = new GeneralResponseMessage<ErrorDetail>(new ErrorDetail(problem));
            response.ResultCode = problem.Status.Value;
            var responsemessage = JsonConvert.SerializeObject(response, _jsonSettings);
            context.Response.StatusCode = problem.Status ?? (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(responsemessage);
        }
    }
}
