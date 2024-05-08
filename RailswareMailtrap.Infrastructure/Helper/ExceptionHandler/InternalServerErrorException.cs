using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RailswareMailtrap.Infrastructure.Helper.ExceptionHandler
{
    public class InternalServerErrorException : CommonException
    {

        public InternalServerErrorException() : base((int)HttpStatusCode.InternalServerError, string.Empty)
        {

        }

        public InternalServerErrorException(string message) : base((int)HttpStatusCode.InternalServerError, message)
        {

        }
        public InternalServerErrorException(HttpStatusCode code, string message) : base(code, message)
        {
        }

        public InternalServerErrorException(int code, string message) : base(code, message)
        {
        }

        public InternalServerErrorException(HttpStatusCode code, string message, Exception innerException) : base(code, message, innerException)
        {
        }

        public InternalServerErrorException(int code, string message, Exception innerException) : base(code, message, innerException)
        {
        }

        public InternalServerErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
