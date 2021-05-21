// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageHandlerBase.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The message handler base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.HandlersMessage
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    using ReactiveUI;
    using UI.Infrastructure;
    using UI.Resources;


    /// <summary>
    /// The mssage handler base.
    /// </summary>
    public abstract class MessageHandlerBase : IHandlerMessage
    {
        protected readonly IMessenger Messenger;
        protected readonly IList<IDisposable> Disposables;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageHandlerBase"/> class.
        /// </summary>
        /// <param name="messenger">
        /// The Messenger.
        /// </param>
        protected MessageHandlerBase(IMessenger messenger)
        {
            this.Disposables = new List<IDisposable>();
            this.Messenger = messenger;
        }

        /// <summary>
        /// The initialization.
        /// </summary>
        /// <param name="messageBus">
        /// The message bus.
        /// </param>
        public abstract void Init(IMessageBus messageBus);

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Disposables.DoForEach(disposable => disposable.Dispose());
            Disposables.Clear();
        }

        /// <summary>
        /// The show message.
        /// </summary>
        /// <param name="editState">
        /// The edit state.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        protected virtual void ShowMessage(EditState editState, string message = null)
        {
            this.Messenger.Add(
                new UiMessage(
                    message
                    ?? (editState == EditState.Edit
                            ? CustomMessages.UpdatedSuccessfully
                            : CustomMessages.AddedSuccessfully)));
        }

        protected virtual void ShowMessage(string message)
        {
            this.Messenger.Add(new UiMessage(message));
        }
    }
}