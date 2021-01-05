using System;
using System.IO;
using System.Runtime.Serialization;

namespace Library
{
    [Serializable]
    internal class FileDoesntExist : Exception
    {
        public FileDoesntExist()
        {
        }

        public FileDoesntExist(string message) : base(message)
        {
        }

        public FileDoesntExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileDoesntExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}