using System;
using System.Runtime.Serialization;

namespace BKO.Domain.Exceptions
{
    [Serializable]
    internal class CardNotInHandException : Exception
    {
        public CardNotInHandException()
        {
        }

        public CardNotInHandException(string message) : base(message)
        {
        }

        public CardNotInHandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CardNotInHandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}