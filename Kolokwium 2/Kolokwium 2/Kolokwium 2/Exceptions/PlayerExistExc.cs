using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium_2.Exceptions
{
    public class PlayerExistExc : Exception
    {
        public PlayerExistExc()
        {
        }

        public PlayerExistExc(string message) : base(message)
        {
        }

        public PlayerExistExc(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlayerExistExc(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
