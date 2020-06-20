using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Projekt_s16696.Exceptions
{
    public class NoLoginOrPasswordException : Exception
    {
        public NoLoginOrPasswordException()
        {
        }

        public NoLoginOrPasswordException(string message) : base(message)
        {
        }

        public NoLoginOrPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoLoginOrPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
