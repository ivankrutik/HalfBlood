// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessenger.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the TypeOfMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Reactive;
    using System.Reactive.Concurrency;
    using System.Windows;

    using UI.Infrastructure.Messages;

    /// <summary>
    /// The type of message.
    /// </summary>
    public enum TypeOfMessage
    {
        /// <summary>
        /// The warning.
        /// </summary>
        Warning,

        /// <summary>
        /// The information.
        /// </summary>
        Information,

        /// <summary>
        /// The error.
        /// </summary>
        Error,

        /// <summary>
        /// The question.
        /// </summary>
        Question
    }

    /// <summary>
    /// The messanger interface.
    /// </summary>
    public interface IMessenger
    {
        /// <summary>
        /// The added message.
        /// </summary>
        event Action<IUiMessage> AddedMessage;

        /// <summary>
        /// Gets the messages.
        /// </summary>
        IList<IUiMessage> Messages { get; }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void Add(IUiMessage message);

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void Add(string message);

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
        void Ask(string question, MessageBoxButton buttons, Action<MessageBoxResult> callback);

        /// <summary>
        /// The ask.
        /// </summary>
        /// <param name="question">
        /// The question.
        /// </param>
        void Ask(IQuestion question);

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
        IObservable<MessageBoxResult> AskToObservable(string question, MessageBoxButton buttons);

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
        IObservable<Unit> AskToObservable(string question, MessageBoxButton buttons, Action<MessageBoxResult> callback, IScheduler scheduler = null);

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
        IObservable<Unit> AskToObservable(IQuestion question, IScheduler scheduler = null);
    }

    /// <summary>
    /// The Message interface.
    /// </summary>
    public interface IUiMessage
    {
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        string Body { get; set; }

        /// <summary>
        /// Gets or sets the type of message.
        /// </summary>
        TypeOfMessage TypeOfMessage { get; set; }
    }

    /// <summary>
    /// The message.
    /// </summary>
    public class UiMessage : IUiMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UiMessage"/> class.
        /// </summary>
        public UiMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UiMessage"/> class.
        /// </summary>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <param name="typeOfMessage">
        /// The type of message.
        /// </param>
        public UiMessage(string body, TypeOfMessage typeOfMessage = TypeOfMessage.Information)
        {
            Body = body;
            TypeOfMessage = typeOfMessage;
        }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the type of message.
        /// </summary>
        public TypeOfMessage TypeOfMessage { get; set; }
    }

    /// <summary>
    /// The question.
    /// </summary>
    public class Question : IQuestion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Question"/> class.
        /// </summary>
        public Question()
        {
            TypeOfMessage = TypeOfMessage.Question;
        }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the type of message.
        /// </summary>
        public TypeOfMessage TypeOfMessage { get; set; }

        /// <summary>
        /// Gets or sets the buttons.
        /// </summary>
        public MessageBoxButton Buttons { get; set; }

        /// <summary>
        /// Gets or sets the callback.
        /// </summary>
        public Action<MessageBoxResult> Callback { get; set; }
    }
}