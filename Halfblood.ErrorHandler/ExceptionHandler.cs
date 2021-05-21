// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionHandler.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ExceptionHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.ErrorHandler
{
    using System;
    using System.ComponentModel.Composition;

    using Halfblood.Common.Exceptions;

    using UI.Infrastructure;

    /// <summary>
    /// The exception handler.
    /// </summary>
    [Export(typeof(IExceptionHandler))]
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly IMessenger messenger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandler"/> class.
        /// </summary>
        /// <param name="messenger">
        /// The Messenger.
        /// </param>
        [ImportingConstructor]
        public ExceptionHandler(IMessenger messenger)
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
            return false;
            this.messenger.Add(new UiMessage(exception.Message, TypeOfMessage.Error));
        }
    }
}
