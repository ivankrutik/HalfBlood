namespace Buisness.Workflows.ExceptionHandlers
{
    using System;
    using System.ComponentModel.Composition;

    using Halfblood.Common;
    using Halfblood.Common.Exceptions;

    using NHibernate.Exceptions;

    [Export(typeof(IExceptionHandler))]
    public class OracleExceptionHandler : IExceptionHandler
    {
        public bool Handling(Exception exception)
        {
            var adoException = exception.GetExceptionFromHierarchy<GenericADOException>();
            if (adoException != null)
            {

            }

            return false;
        }
    }
}
