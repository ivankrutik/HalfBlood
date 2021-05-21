// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HandlerMessageContext.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the HandlerMessageContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.HandlersMessage
{
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;

    using ReactiveUI;

    using UI.Infrastructure;

    /// <summary>
    /// The handler message context.
    /// </summary>
    [Export]
    public class HandlerMessageContext : IPartImportsSatisfiedNotification
    {
        private readonly IMessageBus _messageBus;
        [ImportMany]
        private IHandlerMessage[] _handlerMessages;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandlerMessageContext"/> class.
        /// </summary>
        /// <param name="messageBus">
        /// The message bus.
        /// </param>
        [ImportingConstructor]
        public HandlerMessageContext(IMessageBus messageBus)
        {
            this._messageBus = messageBus;
            this.Init();
        }

        /// <summary>
        /// The initialization.
        /// </summary>
        public void Init()
        {
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            _handlerMessages.DoForEach(handler => handler.Init(_messageBus));
        }
    }
}