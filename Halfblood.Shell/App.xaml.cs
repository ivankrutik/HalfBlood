// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the App type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Shell
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Windows;
    using System.Windows.Threading;

    using Halfblood.Common;
    using Halfblood.Common.Exceptions;
    using Halfblood.Common.Navigations;
    using Halfblood.Loader;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.Messages;

    public partial class App : Application
    {
        private Bootstrapper _bootstrapper;

        protected override void OnStartup(StartupEventArgs e)
        {
            Current.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException;

            try
            {
                base.OnStartup(e);
                _bootstrapper = new Bootstrapper();

                var startWindow = new StartWindow(
                    _bootstrapper.IoC.GetExportedValue<IOwnerHostScreen>(),
                    _bootstrapper.IoC.GetExportedValue<IRoutableViewModelManager>(),
                    _bootstrapper.IoC.GetExportedValue<ITitleBarHostScreen>());

                Current.MainWindow = startWindow;
                startWindow.Show();

                var messageBus = _bootstrapper.IoC.GetExportedValue<IMessageBus>();
                messageBus.SendMessage(UILoadedMessage.Empty);
            }
            catch (ReflectionTypeLoadException ex)
            {
                var message = ex.LoaderExceptions.Aggregate(
                    string.Empty,
                    (current, item) => current + item.Message + "\n");
                Handling(new Exception(message, ex));
            }
            catch (Exception ex)
            {
                Handling(ex);
            }
        }
        private void CurrentOnDispatcherUnhandledException(
            object sender,
            DispatcherUnhandledExceptionEventArgs dispatcherUnhandledExceptionEventArgs)
        {
            this.Handling(dispatcherUnhandledExceptionEventArgs.Exception);
            dispatcherUnhandledExceptionEventArgs.Handled = true;
        }
        private void Handling(Exception exception)
        {
            if (_bootstrapper == null)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            var errorHandlerContext = this._bootstrapper.IoC.GetExportedValue<IErrorHandlerContext>();
            var messager = this._bootstrapper.IoC.GetExportedValue<IMessenger>();

            if (!errorHandlerContext.Handling(exception))
            {
                messager.Add(new UiMessage(exception.ToMessage(), TypeOfMessage.Error));
            }
        }
        private void AppOnExit(object sender, ExitEventArgs e)
        {
            var messageBus = _bootstrapper.IoC.GetExportedValue<IMessageBus>();
            messageBus.SendMessage(AppIsUnloadedMessage.Empty);
        }
    }
}