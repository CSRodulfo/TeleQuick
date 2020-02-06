using System;
using System.Runtime.Serialization;

namespace DataAccess.Commons
{
    [Serializable]
    internal class NoConnectionException : Exception
    {
        public NoConnectionException()
        {
        }

        public NoConnectionException(string message)
            : base(message)
        {
        }

        public NoConnectionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected NoConnectionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}