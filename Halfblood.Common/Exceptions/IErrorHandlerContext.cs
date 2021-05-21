// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IErrorHandlerContext.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IErrorHandlerContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Exceptions
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The ErrorHandlerContext interface.
    /// </summary>
    [ContractClass(typeof(IErrorHandlerContextContract))]
    public interface IErrorHandlerContext
    {
        /// <summary>
        /// The add handler.
        /// </summary>
        /// <param name="exceptionHandler">
        /// The exception handler.
        /// </param>
        void AddHandler(IExceptionHandler exceptionHandler);

        /// <summary>
        /// The handling.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        bool Handling(Exception exception);
    }

    [ContractClassFor(typeof(IErrorHandlerContext))]
    internal abstract class IErrorHandlerContextContract : IErrorHandlerContext
    {
        void IErrorHandlerContext.AddHandler(IExceptionHandler exceptionHandler)
        {
            Contract.Requires(exceptionHandler != null);
        }

        bool IErrorHandlerContext.Handling(Exception exception)
        {
            Contract.Requires(exception != null);

            return default(bool);
        }
    }
}