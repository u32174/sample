﻿using System;
using System.Runtime.Serialization;

namespace CommandsApi.Repositories
{
    [Serializable]
    internal class RecordNotFoundException : Exception
    {
        public RecordNotFoundException()
        {
        }

        public RecordNotFoundException(string message) : base(message)
        {
        }

        public RecordNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RecordNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}