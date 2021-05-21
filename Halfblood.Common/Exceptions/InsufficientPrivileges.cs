namespace Halfblood.Common.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class InsufficientPrivileges : Exception
    {
        public InsufficientPrivileges()
        {
        }

        public InsufficientPrivileges(string message)
            : base(message)
        {
        }

        public InsufficientPrivileges(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InsufficientPrivileges(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
