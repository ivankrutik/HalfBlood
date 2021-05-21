// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessLauncher.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ProcessLauncher type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents
{
    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Diagnostics;
    using System.Reactive;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Reflection;

    using FluentValidation;

    using Halfblood.Common;
    using Halfblood.Common.Exceptions;
    using Halfblood.Common.Connection;
    using Halfblood.Common.Interceptors;
    using Halfblood.Common.Settings;
    using Halfblood.Common.Settings.Adjuster;
    using Halfblood.Common.Validations;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.Messages;
    using UI.ProcessComponents.HandlersMessage;

    [Export(typeof(IMefProfileLauncher))]
    public class ProcessLauncher : IMefProfileLauncher
    {
        public void LoadProfiles(CompositionContainer container)
        {
            InitMessagesManagment(container);
            InitExceptionsManagment(container);
            InitValidatorManager(container);
            InitAuthorizeCompletedMessage(container);
        }

        private void InitAuthorizeCompletedMessage(CompositionContainer container)
        {
            var messageBus = container.GetExportedValue<IMessageBus>();
            IDisposable disposable = Disposable.Empty;
            disposable = messageBus.Listen<AuthentificationCompletedMessage>().Subscribe(
                msg =>
                    {
                        var objectAdjusterManager = container.GetExportedValue<IObjctAdjusterManager>();
                        var interceptorProvider = container.GetExportedValue<IInterceptorsProvider>();
                        interceptorProvider.Register(objectAdjusterManager);
                        interceptorProvider.Unregister(container.GetExportedValue<IObjctAdjusterManager>("LOCAL"));

                        var manager = container.GetExportedValue<IIndependencyAdjustManager>();
                        manager.AdjustAll();
                        
                        disposable.Dispose();
                    });
        }
        private void InitMessagesManagment(CompositionContainer container)
        {
            var handler = container.GetExportedValue<HandlerMessageContext>();
            handler.Init();
        }
        private void InitExceptionsManagment(CompositionContainer container)
        {
            var exceptionHandler = container.GetExportedValue<IErrorHandlerContext>();

            RxApp.DefaultExceptionHandler = Observer.Create<Exception>(
                exc =>
                {
                    if (Debugger.IsAttached)
                    {
                        Debugger.Break();
                    }

                    UserError.Throw("Произошла необработанная ошибка", exc);
                    Halfblood.Common.Log.LogManager.Log.Debug(exc);
                });

            var messager = container.GetExportedValue<IMessenger>();
            UserError.RegisterHandler(
                exc =>
                {
                    if (!exceptionHandler.Handling(exc.InnerException))
                    {
                        messager.Add(
                        new UiMessage(exc.ErrorMessage + "\n" + exc.InnerException.ToMessage(), TypeOfMessage.Error));
                    }
                    return Observable.Return(RecoveryOptionResult.CancelOperation);
                });
        }
        private void InitValidatorManager(CompositionContainer container)
        {
            FieldInfo fieldInfo = typeof(ValidationManager).GetField("_factory", BindingFlags.Static | BindingFlags.NonPublic);
            fieldInfo.SetValue(null, container.GetExportedValue<IValidatorFactory>());
        }
    }
}