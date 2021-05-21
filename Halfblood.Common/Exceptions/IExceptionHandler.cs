// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExceptionHandler.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IExceptionHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Exceptions
{
    using System;

    /// <summary>
    /// The priority.
    /// </summary>
    public enum Priority
    {
        /// <summary>
        /// The low.
        /// </summary>
        Low,

        /// <summary>
        /// The normal.
        /// </summary>
        Normal,

        /// <summary>
        /// The high.
        /// </summary>
        High
    }

    /// <summary>
    /// The ExceptionHandler interface.
    /// </summary>
    public interface IExceptionHandler
    {
        /// <summary>
        /// Gets the priority.
        /// </summary>
        //Priority Priority { get; }

        /// <summary>
        /// The handling.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Handling(Exception exception);
    }
}
