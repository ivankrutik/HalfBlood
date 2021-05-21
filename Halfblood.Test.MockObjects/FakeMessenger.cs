// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeMessenger.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeMessenger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reactive;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using System.Windows;

    using UI.Infrastructure;
    using UI.Infrastructure.Messages;

    public class FakeMessenger : IMessenger
    {
        public IList<IUiMessage> Messages { get; private set; }
        public event Action<IUiMessage> AddedMessage;

        public FakeMessenger()
        {
            Messages = new ObservableCollection<IUiMessage>();
        }

        public void Add(IUiMessage message)
        {
            Messages.Add(message);
            OnAddedMessage(message);
        }

        public void Add(string message)
        {
            Add(new UiMessage(message));
        }

        public void Ask(string question, MessageBoxButton buttons, Action<MessageBoxResult> callback)
        {
            throw new NotImplementedException();
        }

        public void Ask(IQuestion question)
        {
            throw new NotImplementedException();
        }

        public IObservable<Unit> AskToObservable(string question, MessageBoxButton buttons, Action<MessageBoxResult> callback)
        {
            throw new NotImplementedException();
        }

        public IObservable<Unit> AskToObservable(IQuestion question)
        {
            throw new NotImplementedException();
        }

        public IObservable<MessageBoxResult> AskToObservable(string question, MessageBoxButton buttons)
        {
            throw new NotImplementedException();
        }

        public IObservable<Unit> AskToObservable(string question, MessageBoxButton buttons, Action<MessageBoxResult> callback, IScheduler scheduler = null)
        {
            throw new NotImplementedException();
        }

        public IObservable<Unit> AskToObservable(IQuestion question, IScheduler scheduler = null)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnAddedMessage(IUiMessage message)
        {
            Action<IUiMessage> handler = AddedMessage;
            if (handler != null)
            {
                handler(message);
            }
        }
    }
}
