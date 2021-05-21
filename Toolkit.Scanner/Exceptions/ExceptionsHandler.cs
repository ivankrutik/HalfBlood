// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionsHandler.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ExceptionsHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Reflection.Emit;

namespace Toolkit.Scanner.Exceptions
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.InteropServices;

    using Halfblood.Common.Exceptions;

    using UI.Infrastructure;

    /// <summary>
    /// The exceptions handler.
    /// </summary>
    [Export(typeof(IExceptionHandler))]
    public class ExceptionsHandler : IExceptionHandler
    {
        private readonly IMessenger messenger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandler"/> class.
        /// </summary>
        /// <param name="messenger">
        /// The Messenger.
        /// </param>
        [ImportingConstructor]
        public ExceptionsHandler(IMessenger messenger)
        {
            this.messenger = messenger;
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
            if (exception is COMException)
            {
                messenger.Add(new UiMessage(WiaError.GetErrorMessage((COMException)exception), TypeOfMessage.Error));
                return true;
            }

            return false;
        }
    }
}
