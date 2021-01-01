using System;
using System.Runtime.Serialization;

namespace Library
{
    [Serializable]
    internal class GetPersonIsWrong : Exception
    {
        public GetPersonIsWrong()
        {
        }

        public GetPersonIsWrong(string message) : base(message)
        {
        }

        public GetPersonIsWrong(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GetPersonIsWrong(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}