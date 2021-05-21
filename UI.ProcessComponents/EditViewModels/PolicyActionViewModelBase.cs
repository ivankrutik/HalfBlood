// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PolicyActionViewModelBase.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the PolicyActionViewModelBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.EditViewModels
{
    using System;
    using System.Reactive;

    using ReactiveUI;

    using UI.Entities;
    using UI.Infrastructure.Messages;
    using UI.Infrastructure.ViewModels;

    /// <summary>
    /// The policy action view model base.
    /// </summary>
    /// <typeparam name="TActionObject">
    /// The type of editable object.
    /// </typeparam>
    /// <typeparam name="TState">
    /// The state
    /// </typeparam>
    public abstract class PolicyActionViewModelBase<TActionObject, TState> 
        : AsyncLoaderViewModelBase<Unit>, IChangeStateViewModel<TActionObject, TState>
        where TActionObject : class, IUiEntity, IHasState<TState>
        where TState : struct
    {
        protected readonly IScreen HostScreen;
        protected readonly IMessageBus MessageBus;
        private TActionObject _actionObject;
        private TState _state;

        protected PolicyActionViewModelBase(IScreen hostScreen = null, IMessageBus messageBus = null)
        {
            HostScreen = hostScreen;
            MessageBus = messageBus;
        }

        public TState State
        {
            get { return _state; }
            set { this.RaiseAndSetIfChanged(ref _state, value); }
        }
        public TActionObject ActionObject
        {
            get { return _actionObject; }
            private set { this.RaiseAndSetIfChanged(ref _actionObject, value); }
        }

        public virtual void SetActionObject(TActionObject @object)
        {
            if (@object == null)
            {
                throw new ArgumentNullException("object");
            }

            ActionObject = @object;
        }

        protected override void Complete()
        {
            ActionObject.State = State;

            if (this.MessageBus != null)
            {
                this.MessageBus.SendMessage(new UpdateStateMessage<TActionObject>(ActionObject));
            }

            if (HostScreen != null)
            {
                this.HostScreen.Router.NavigateBack.Execute(null);
            }
        }
    }
}