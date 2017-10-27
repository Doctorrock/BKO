using System;
using System.Runtime.Serialization;

namespace BKO.Domain.Models
{
    [Serializable]
    internal class WrongPlayerException : Exception
    {
        public WrongPlayerException()
        {
        }

        public WrongPlayerException(string message) : base(message)
        {
        }

        public WrongPlayerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongPlayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}