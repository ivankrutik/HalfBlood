namespace UI.Components.Settings.Adjusters
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Windows;
    using System.Windows.Threading;

    using Halfblood.Common.Settings;
    using Halfblood.Common.Settings.Adjuster;

    using MahApps.Metro;

    using ReactiveUI;

    using UI.Infrastructure.Messages;

    [Adjuster(SettingType = typeof(ColorSetting))]
    [Export(typeof(IIndependencyAdjuster<ColorSetting>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ColorAdjuster : IIndependencyAdjuster<ColorSetting>, IDisposable
    {
        private readonly IMessageBus _messageBus;
        private IDisposable _disposable;

        [ImportingConstructor]
        public ColorAdjuster(IMessageBus messageBus)
        {
            _messageBus = messageBus;
            _disposable = Disposable.Empty;
        }

        public string Name
        {
            get { return "ColorSetting"; }
        }

        public static void AdjustSetting(ColorSetting setting)
        {
            var accent = ThemeManager.DefaultAccents.FirstOrDefault(x => x.Name == setting.Accent.Name)
                         ?? ThemeManager.DefaultAccents.First();
            var theme = setting.Theme;

            Application.Current.Dispatcher.Invoke(
                () => ThemeManager.ChangeTheme(Application.Current.MainWindow, accent, theme));
        }

        public bool Adjust(ColorSetting setting)
        {
            Contract.Requires(setting != null, "The setting must be is not null");

            if (this.UiIsNotLoaded())
            {
                _disposable = _messageBus.Listen<UILoadedMessage>().Subscribe(_ =>
                    {
                        _disposable.Dispose();
                        AdjustSetting(setting);
                    });
            }
            else
            {
                AdjustSetting(setting);
            }

            return true;
        }
        public void Dispose()
        {
            _disposable.Dispose();
        }

        bool IIndependencyAdjuster.Adjust(ISetting setting)
        {
            return Adjust(setting as ColorSetting);
        }
        private bool UiIsNotLoaded()
        {
            return Application.Current.Dispatcher.Invoke(() => Application.Current.MainWindow == null);
        }
    }
}
