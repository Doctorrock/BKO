using System;
using System.Runtime.Serialization;

namespace BKO.Models
{
    [Serializable]
    internal class TrickContainsThisCardException : Exception
    {
        public TrickContainsThisCardException()
        {
        }

        public TrickContainsThisCardException(string message) : base(message)
        {
        }

        public TrickContainsThisCardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TrickContainsThisCardException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}