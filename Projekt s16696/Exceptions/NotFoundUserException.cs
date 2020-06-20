﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Projekt_s16696.Exceptions
{
    public class NotFoundUserException : Exception
    {
        public NotFoundUserException()
        {
        }

        public NotFoundUserException(string message) : base(message)
        {
        }

        public NotFoundUserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
