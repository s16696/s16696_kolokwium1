using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium_2.Exceptions
{
    public class TooOldExc : Exception
    {
        public TooOldExc()
        {
        }

        public TooOldExc(string message) : base(message)
        {
        }

        public TooOldExc(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TooOldExc(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
