using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RailswareMailtrap.Infrastructure.Helper.ExceptionHandler
{
    public class ErrorDetail
    {
        [JsonProperty("field")]
        public string Field { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

        public ErrorDetail() : this(string.Empty, string.Empty)
        {

        }

        public ErrorDetail(string field, string message)
        {
            Field = field;
            Message = message;
        }

        public ErrorDetail(ProblemDetails problem)
        {
            Field = problem.Title;
            Message = problem.Detail;
        }

    }
}
