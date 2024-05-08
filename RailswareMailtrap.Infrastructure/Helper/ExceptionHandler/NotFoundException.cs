using System.Net;
using System.Runtime.Serialization;

namespace RailswareMailtrap.Infrastructure.Helper.ExceptionHandler
{
    public class NotFoundException : CommonException
    {

        public NotFoundException(string message) : base((int)HttpStatusCode.NotFound, message)
        {

        }
        public NotFoundException() : base((int)HttpStatusCode.NotFound, string.Empty)
        {

        }

        public NotFoundException(HttpStatusCode code, string message) : base(code, message)
        {
        }

        public NotFoundException(int code, string message) : base(code, message)
        {
        }

        public NotFoundException(HttpStatusCode code, string message, Exception innerException) : base(code, message, innerException)
        {
        }

        public NotFoundException(int code, string message, Exception innerException) : base(code, message, innerException)
        {
        }

        public NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
