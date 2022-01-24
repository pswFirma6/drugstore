using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PharmacyLibrary.Exceptions
{
    [Serializable]
    public abstract class CustomException: Exception
    {
        protected CustomException(string message) : base(message) { }
    }

    [Serializable]
    public class CustomNotFoundException : CustomException
    {
        public CustomNotFoundException(string message) : base(message) { }
    }

    [Serializable]
    public class BadRequestCustomException : CustomException
    {
        public BadRequestCustomException(string message) : base(message) { }
    }
}
