using System;

namespace Hertzole.ALE
{
    public sealed class EmptyArrayException : Exception
    {
        public EmptyArrayException(string message) : base(message) { }

        public EmptyArrayException(string message, Exception innerException) : base(message, innerException) { }

        public EmptyArrayException() { }
    }
}
