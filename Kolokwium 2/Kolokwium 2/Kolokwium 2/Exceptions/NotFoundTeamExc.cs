using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium_2.Exceptions
{
    public class NotFoundTeamExc : Exception
    {
        public NotFoundTeamExc()
        {
        }

        public NotFoundTeamExc(string message) : base(message)
        {
        }

        public NotFoundTeamExc(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundTeamExc(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
