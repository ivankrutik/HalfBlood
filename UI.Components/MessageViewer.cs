// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageViewer.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The message viewer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components
{
    using System.Windows;

    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;

    using UI.Components.NotifyMessagWindows;
    using System;
    using System.ComponentModel.Composition;

    using UI.Infrastructure;
    using UI.Infrastructure.Messages;
    using UI.Infrastructure.Views;
    using UI.Resources;

    [Export(typeof(IMessageViewer))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MessageViewer : IMessageViewer
    {
        private readonly NotifyMessageManager _notifyMessageMgr;

        [ImportingConstructor]
        public MessageViewer(IMessenger messanger)
        {
            messanger.AddedMessage += MessangerAddedMessage;
            _notifyMessageMgr = new NotifyMessageManager(Screen.Width, Screen.Height, 200, 150);
        }

        private void MessangerAddedMessage(IUiMessage msg)
        {
            if (msg is IQuestion)
            {
                MessangerAddedMessage((IQuestion)msg);
                return;
            }

            string titleMessage = this.GetTitle(msg.TypeOfMessage);

            switch (msg.TypeOfMessage)
            {
                case TypeOfMessage.Warning:
                    ErrorMessage(msg, titleMessage);
                    break;
                case TypeOfMessage.Information:
                    InfoMessage(msg, titleMessage);
                    break;
                case TypeOfMessage.Error:
                    ErrorMessage(msg, titleMessage);
                    break;
                case TypeOfMessage.Question:
                    ErrorMessage(msg, titleMessage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void MessangerAddedMessage(IQuestion question)
        {
            string titleMessage = this.GetTitle(question.TypeOfMessage);

            var window = ((MetroWindow)Application.Current.MainWindow);
            window.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Theme;

            var settings = new MetroDialogSettings { CanChangeSizeToContent = false };
            MessageDialogStyle messageDialogStyle = default(MessageDialogStyle);

            if (question.Buttons == MessageBoxButton.OK)
            {
                settings.AffirmativeButtonText = "ok";
                messageDialogStyle = MessageDialogStyle.Affirmative;
            }
            else if (question.Buttons == MessageBoxButton.OKCancel)
            {
                settings.AffirmativeButtonText = "ok";
                settings.NegativeButtonText = "отмена";
                messageDialogStyle = MessageDialogStyle.AffirmativeAndNegative;
            }
            else if (question.Buttons == MessageBoxButton.YesNo)
            {
                settings.AffirmativeButtonText = "да";
                settings.NegativeButtonText = "нет";
                messageDialogStyle = MessageDialogStyle.AffirmativeAndNegative;
            }
            else if (question.Buttons == MessageBoxButton.YesNoCancel)
            {
                settings.AffirmativeButtonText = "да";
                settings.NegativeButtonText = "нет";
                settings.FirstAuxiliaryButtonText = "отмена";
                messageDialogStyle = MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary;
            }

            window.ShowMessageAsync(titleMessage, question.Body, messageDialogStyle, settings)
                .ContinueWith(
                    task =>
                    {
                        MessageDialogResult result = task.Result;

                        if (result == MessageDialogResult.Affirmative)
                        {
                            if (question.Buttons == MessageBoxButton.OK
                                || question.Buttons == MessageBoxButton.OKCancel)
                            {
                                question.Callback(MessageBoxResult.OK);
                            }
                            else question.Callback(MessageBoxResult.Yes);
                        }
                        else if (result == MessageDialogResult.Negative)
                        {
                            if (question.Buttons == MessageBoxButton.OK
                                || question.Buttons == MessageBoxButton.OKCancel)
                            {
                                question.Callback(MessageBoxResult.Cancel);
                            }
                            else question.Callback(MessageBoxResult.No);
                        }
                        else if (result == MessageDialogResult.FirstAuxiliary)
                        {
                            if (question.Buttons == MessageBoxButton.OK
                                || question.Buttons == MessageBoxButton.OKCancel)
                            {
                                question.Callback(MessageBoxResult.Cancel);
                            }
                            else question.Callback(MessageBoxResult.No);
                        }
                    });
        }
        private string GetTitle(TypeOfMessage typeOfMessage)
        {
            switch (typeOfMessage)
            {
                case TypeOfMessage.Error:
                    return CustomMessages.Error;
                case TypeOfMessage.Information:
                    return CustomMessages.Information;
                case TypeOfMessage.Warning:
                    return CustomMessages.Warning;
                case TypeOfMessage.Question:
                    return CustomMessages.AcceptionAction;
                default:
                    return string.Empty;
            }
        }
        private void InfoMessage(IUiMessage message, string titleMessage)
        {
            var msg = new NotifyMessage("/Assets/GreenSkin.png", titleMessage, message.Body, null);
            _notifyMessageMgr.EnqueueMessage(msg);
        }
        private void ErrorMessage(IUiMessage message, string titleMessage)
        {
            var window = ((MetroWindow)Application.Current.MainWindow);
            window.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Theme;
            var mySettings = new MetroDialogSettings { AffirmativeButtonText = "Ok", CanChangeSizeToContent = false };
            window.ShowMessageAsync(titleMessage, message.Body, MessageDialogStyle.Affirmative, mySettings);
        }
    }
}
