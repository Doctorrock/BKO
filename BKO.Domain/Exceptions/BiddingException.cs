using System;
using System.Runtime.Serialization;

namespace BKO.Domain.Models
{
    [Serializable]
    internal class BiddingException : Exception
    {
        public BiddingException()
        {
        }

        public BiddingException(string message) : base(message)
        {
        }

        public BiddingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BiddingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}