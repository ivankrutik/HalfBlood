// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorHandlerContext.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ErrorHandlerContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.ErrorHandler
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.Composition;

    using Halfblood.Common.Exceptions;

    /// <summary>
    /// The error handler context.
    /// </summary>
    [Export(typeof(IErrorHandlerContext))]
    public class ErrorHandlerContext : IErrorHandlerContext
    {
        [ImportMany]
        private readonly IList<IExceptionHandler> _exceptionHandlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorHandlerContext"/> class.
        /// </summary>
        public ErrorHandlerContext()
        {
            _exceptionHandlers = new ObservableCollection<IExceptionHandler>();
            ExceptionHandlers = new ReadOnlyCollection<IExceptionHandler>(_exceptionHandlers);
        }

        /// <summary>
        /// Gets the exception handlers.
        /// </summary>
        public IList<IExceptionHandler> ExceptionHandlers { get; private set; }

        /// <summary>
        /// The add handler.
        /// </summary>
        /// <param name="exceptionHandler">
        /// The exception handler.
        /// </param>
        public void AddHandler(IExceptionHandler exceptionHandler)
        {
            _exceptionHandlers.Add(exceptionHandler);
        }

        /// <summary>
        /// The handling.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Handling(Exception exception)
        {
            foreach (IExceptionHandler exceptionHandler in ExceptionHandlers)
            {
                if (exceptionHandler.Handling(exception))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
