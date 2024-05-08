using System.Net;
using System.Runtime.Serialization;

namespace RailswareMailtrap.Infrastructure.Helper.ExceptionHandler
{
    public class UnauthorizedException : CommonException
    {

        public UnauthorizedException(string message) : base((int)HttpStatusCode.Unauthorized, message)
        {

        }
        public UnauthorizedException() : base((int)HttpStatusCode.Unauthorized, string.Empty)
        {

        }
        public UnauthorizedException(HttpStatusCode code, string message) : base(code, message)
        {
        }

        public UnauthorizedException(int code, string message) : base(code, message)
        {
        }

        public UnauthorizedException(HttpStatusCode code, string message, Exception innerException) : base(code, message, innerException)
        {
        }

        public UnauthorizedException(int code, string message, Exception innerException) : base(code, message, innerException)
        {
        }

        public UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}
