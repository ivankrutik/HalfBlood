// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Messenger.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the Messenger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Reactive;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Windows;

    using Infrastructure;

    using ReactiveUI;

    using UI.Infrastructure.Messages;

    /// <summary>
    /// The Messenger.
    /// </summary>
    [Obsolete("Сделать потокобезопасным [Synchronize?]")]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IMessenger))]
    public class Messenger : IMessenger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Messenger"/> class.
        /// </summary>
        public Messenger()
        {
            Messages = new ObservableCollection<IUiMessage>();
        }

        /// <summary>
        /// The added message.
        /// </summary>
        public event Action<IUiMessage> AddedMessage;

        /// <summary>
        /// Gets the messages.
        /// </summary>
        public IList<IUiMessage> Messages { get; private set; }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Add(IUiMessage message)
        {
            Contract.Requires(message != null);

            Messages.Add(message);
            OnAddedMessage(message);
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Add(string message)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(message));

            Add(new UiMessage(message));
        }

        /// <summary>
        /// The ask.
        /// </summary>
        /// <param name="question">
        /// The question.
        /// </param>
        /// <param name="buttons">
        /// The buttons.
        /// </param>
        /// <param name="callback">
        /// The callback.
        /// </param>
        public void Ask(string question, MessageBoxButton buttons, Action<MessageBoxResult> callback)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(question));
            Contract.Requires(callback != null);

            Ask(new Question { Body = question, Buttons = buttons, Callback = callback });
        }

        /// <summary>
        /// The ask.
        /// </summary>
        /// <param name="question">
        /// The question.
        /// </param>
        public void Ask(IQuestion question)
        {
            this.Add(question);
        }

        /// <summary>
        /// The ask to observable.
        /// </summary>
        /// <param name="question">
        /// The question.
        /// </param>
        /// <param name="scheduler">
        /// The scheduler.
        /// </param>
        /// <returns>
        /// The <see cref="IObservable"/>.
        /// </returns>
        public IObservable<Unit> AskToObservable(IQuestion question, IScheduler scheduler = null)
        {
            Contract.Requires(question != null);

            var callback = question.Callback;
            Func<MessageBoxResult, IObservable<Unit>> function = callback.ToAsync(
                scheduler ?? RxApp.MainThreadScheduler);
            var subject = new AsyncSubject<Unit>();

            var newQuestions = new Question
            {
                Body = question.Body,
                Buttons = question.Buttons,
                Callback = result =>
                    function(result)
                        .Catch(subject.OnError)
                        .Subscribe(unit => {
                            subject.OnNext(unit);
                            subject.OnCompleted();
                        })
            };

            this.Add(newQuestions);
            return subject;
        }

        /// <summary>
        /// The ask to observable.
        /// </summary>
        /// <param name="question">
        /// The question.
        /// </param>
        /// <param name="buttons">
        /// The buttons.
        /// </param>
        /// <param name="callback">
        /// The callback.
        /// </param>
        /// <param name="scheduler">
        /// The scheduler.
        /// </param>
        /// <returns>
        /// The <see cref="IObservable"/>.
        /// </returns>
        public IObservable<Unit> AskToObservable(
            string question,
            MessageBoxButton buttons,
            Action<MessageBoxResult> callback,
            IScheduler scheduler = null)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(question));
            Contract.Requires(callback != null);

            return this.AskToObservable(
                new Question { Body = question, Buttons = buttons, Callback = callback },
                scheduler);
        }

        /// <summary>
        /// The ask to observable.
        /// </summary>
        /// <param name="question">
        /// The question.
        /// </param>
        /// <param name="buttons">
        /// The buttons.
        /// </param>
        /// <returns>
        /// The <see cref="IObservable"/>.
        /// </returns>
        public IObservable<MessageBoxResult> AskToObservable(string question, MessageBoxButton buttons)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(question));

            var subject = new AsyncSubject<MessageBoxResult>();

            var newQuestions = new Question
            {
                Body = question,
                Buttons = buttons,
                Callback = result => {
                    subject.OnNext(result);
                    subject.OnCompleted();
                }
            };

            this.Add(newQuestions);
            return subject;
        }

        /// <summary>
        /// The on added message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        protected virtual void OnAddedMessage(IUiMessage message)
        {
            Contract.Requires(message != null);

            Action<IUiMessage> handler = AddedMessage;
            if (handler != null)
            {
                handler(message);
            }
        }
    }
}