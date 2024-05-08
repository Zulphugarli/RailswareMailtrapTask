using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RailswareMailtrap.Infrastructure.Helper.ExceptionHandler
{

    [Serializable]
    public abstract class CommonException : Exception
    {

        protected CommonException()
        {
        }


        /// <summary>
        /// The error code. Range: 400-599. Almost always corresponds to HTTP Status client/server code but can differ for non-standard codes
        /// </summary>
        public int Code { get; }

        /// <summary>Initializes a new instance of the class</summary>
        /// <param name="code">The status code. Range: 400-599. Almost always corresponds to HTTP Status client/server code but can differ for non-standard codes</param>
        /// <param name="message">The error message that explains the reason for the exception. Required</param>
        private protected CommonException(HttpStatusCode code, string message)
          : this((int)code, message)
        {
        }

        /// <summary>Initializes a new instance of the class</summary>
        /// <param name="code">The status code. Range: 400-599. Almost always corresponds to HTTP Status client/server code but can differ for non-standard codes</param>
        /// <param name="message">The error message that explains the reason for the exception. Required</param>
        private protected CommonException(int code, string message)
          : base(message)
        {
            Ensure.IsValidErrorCode(code);
            Ensure.MessageIsNotNullOrWhiteSpace(message);
            Code = code;
        }

        /// <summary>Initializes a new instance of the class</summary>
        /// <param name="code">The status code. Range: 400-599. Almost always corresponds to HTTP Status client/server code but can differ for non-standard codes</param>
        /// <param name="message">The error message that explains the reason for the exception. Required</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        private protected CommonException(HttpStatusCode code, string message, Exception innerException)
          : this((int)code, message, innerException)
        {
        }

        /// <summary>Initializes a new instance of the class</summary>
        /// <param name="code">The status code. Range: 400-599. Almost always corresponds to HTTP Status client/server code but can differ for non-standard codes</param>
        /// <param name="message">The error message that explains the reason for the exception. Required</param>
        /// <param name="innerException">The exception that is the cause of the current exception. Required</param>
        private protected CommonException(int code, string message, Exception innerException)
          : base(message, innerException)
        {
            Ensure.IsValidErrorCode(code);
            Ensure.MessageIsNotNullOrWhiteSpace(message);
            Ensure.IsNotNull(innerException, nameof(innerException));
            Code = code;
        }

        /// <inheritdoc />
        private protected CommonException(SerializationInfo info, StreamingContext context)
          : base(info, context)
        {
            Code = info.GetInt32(nameof(Code));
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Code", Code);
        }
    }
}
