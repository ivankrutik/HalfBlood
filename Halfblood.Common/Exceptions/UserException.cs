// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserException.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The user exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Exceptions
{
    using System;

    /// <summary>
    /// The user exception.
    /// </summary>
    public class UserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserException"/> class.
        /// </summary>
        public UserException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public UserException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public UserException(string message)
            : base(message, null)
        {
        }
    }
}
