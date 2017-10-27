using System;
using System.Runtime.Serialization;

namespace BKO.Models
{
    [Serializable]
    internal class TrickContainsPositonException : Exception
    {
        public TrickContainsPositonException()
        {
        }

        public TrickContainsPositonException(string message) : base(message)
        {
        }

        public TrickContainsPositonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TrickContainsPositonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}