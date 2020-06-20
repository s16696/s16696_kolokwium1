using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Projekt_s16696.Exceptions
{
    public class NoTokenExistsException : Exception
    {
        public NoTokenExistsException()
        {
        }

        public NoTokenExistsException(string message) : base(message)
        {
        }

        public NoTokenExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoTokenExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
