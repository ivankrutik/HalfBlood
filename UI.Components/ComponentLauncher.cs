namespace UI.Components
{
    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Reactive.Disposables;
    using System.Windows;

    using Halfblood.Common;

    using ReactiveUI;

    using UI.Components.Settings;
    using UI.Infrastructure.Messages;
    using UI.Infrastructure.Views;

    [Export(typeof(IMefProfileLauncher))]
    public class ComponentLauncher : IMefProfileLauncher
    {
        public void LoadProfiles(CompositionContainer container)
        {
            // init message viewer
            var messageViewver = container.GetExportedValue<IMessageViewer>();

            var messageBus = container.GetExportedValue<IMessageBus>();
            IDisposable disposable = Disposable.Empty;
            disposable = messageBus.Listen<AuthentificationCompletedMessage>().Subscribe(_ => {
                Application.Current.Exit += (sender, args) =>
                {
                    var saveUiSetting = container.GetExportedValue<ISaveUiSetting>();
                    saveUiSetting.Save();
                };

                disposable.Dispose();
            });
        }
    }
}
