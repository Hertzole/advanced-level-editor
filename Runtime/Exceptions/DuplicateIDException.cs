using System;

namespace Hertzole.ALE
{
    public sealed class DuplicateIDException : Exception
    {
        public DuplicateIDException(string message) : base(message) { }

        public DuplicateIDException(string message, Exception innerException) : base(message, innerException) { }

        public DuplicateIDException() { }
    }
}
