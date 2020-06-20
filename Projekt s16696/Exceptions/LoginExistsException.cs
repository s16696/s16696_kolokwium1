using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Projekt_s16696.Exceptions
{
    public class LoginExistsException : Exception
    {
        public LoginExistsException()
        {
        }

        public LoginExistsException(string message) : base(message)
        {
        }

        public LoginExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LoginExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
