// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuestion.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IQuestion type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.Messages
{
    using System;
    using System.Windows;

    /// <summary>
    /// The Question interface.
    /// </summary>
    public interface IQuestion : IUiMessage
    {
        /// <summary>
        /// Gets the buttons.
        /// </summary>
        MessageBoxButton Buttons { get; }

        /// <summary>
        /// Gets the callback.
        /// </summary>
        Action<MessageBoxResult> Callback { get; }
    }
}