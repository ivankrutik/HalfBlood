namespace ServiceContracts.Exceptions
{
    using System;

    public class DepartmentOrderException : Exception
    {
        public DepartmentOrderException(string message)
            : base(message)
        {

        }
    }
}
