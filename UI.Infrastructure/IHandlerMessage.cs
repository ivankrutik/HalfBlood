// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHandlerMessage.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IHandlerMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure
{
    using System;

    using ReactiveUI;

    /// <summary>
    /// The HandlerMessage interface.
    /// </summary>
    public interface IHandlerMessage : IDisposable
    {
        /// <summary>
        /// The initialization.
        /// </summary>
        /// <param name="messageBus">
        /// The message bus.
        /// </param>
        void Init(IMessageBus messageBus);
    }
}
