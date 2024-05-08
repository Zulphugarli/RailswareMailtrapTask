using FluentValidation.Results;
using System.Net;
using System.Runtime.Serialization;

namespace RailswareMailtrap.Infrastructure.Helper.ExceptionHandler
{

    public class ValidationException : CommonException
    {

        public ValidationException() : base((int)HttpStatusCode.BadRequest, string.Empty)
        {


        }

        public ValidationException(string message) : base((int)HttpStatusCode.BadRequest, message)
        {

        }

        public ValidationException(HttpStatusCode code, string message) : base(code, message)
        {
        }

        public ValidationException(int code, string message) : base(code, message)
        {
        }

        public ValidationException(HttpStatusCode code, string message, Exception innerException) : base(code, message, innerException)
        {
        }

        public ValidationException(int code, string message, Exception innerException) : base(code, message, innerException)
        {
        }

        public ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
