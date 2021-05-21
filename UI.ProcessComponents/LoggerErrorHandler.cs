// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerErrorHandler.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the LoggerErrorHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents
{
    using System;
    using System.ComponentModel.Composition;

    using Halfblood.Common.Exceptions;
    using Halfblood.Common.Log;

    /// <summary>
    /// The logger error handler.
    /// </summary>
    [Export(typeof(IExceptionHandler))]
    public class LoggerErrorHandler : IExceptionHandler
    {
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
            LogManager.Log.Debug(exception);
            return false;
        }
    }
}