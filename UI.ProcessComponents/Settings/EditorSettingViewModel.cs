namespace UI.ProcessComponents.Settings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Windows.Input;
    using Halfblood.Common.Log;
    using Halfblood.Common.Settings;
    using Halfblood.Common.Settings.Adjuster;
    using Halfblood.Common.Settings.Editors;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.Settings;

    /// <summary>
    /// Contains the list of settings and strategy for their editing.
    /// Provider the interface of a choice of strategy of editing for the chosen setting.
    /// </summary>
    [Export(typeof(IEditorSettingViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditorSettingViewModel : ReactiveObject, IEditorSettingViewModel
    {
        #region PRIVATE FIELDS
        private readonly IMessenger _messenger;
        private readonly ISettingEditorsProvider _settingEditorsProvider;
        private readonly IIndependencyAdjustManager _adjustManager;
        private readonly IList<ISetting> _dirtySettings = new List<ISetting>();
        private readonly Func<ISettingsManager> _getSettingsManager;
        private ISettingsManager _settingsManager;
        private ISettingEditor _settingsEditor;
        private ReactiveCommand _flushCommand;
        private bool _isBusy;
        #endregion

        [ImportingConstructor]
        public EditorSettingViewModel(
            IScreen screen,
            IMessenger messenger,
            ISettingEditorsProvider settingEditorsProvider,
            ISettingManagerFactory settingManagerFactory,
            IIndependencyAdjustManager adjustManager)
        {
            HostScreen = screen;
            _messenger = messenger;
            _settingEditorsProvider = settingEditorsProvider;
            _adjustManager = adjustManager;
            _getSettingsManager = InitSettingManager(settingManagerFactory);

            Binding();
        }

        ~EditorSettingViewModel()
        {
            LogManager.Log.Debug("EditorSettingViewModel is DESTROYED");
        }

        public bool IsBusy
        {
            get { return this._isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public ICommand FlushCommand
        {
            get
            {
                if (_flushCommand == null)
                {
                    _flushCommand = new ReactiveCommand();
                    _flushCommand.ThrownExceptions.Subscribe(OnError);
                    _flushCommand.IsExecuting.Subscribe(isBusy => IsBusy = isBusy);
                    _flushCommand.RegisterAsyncAction(_ => Flush())
                        .Subscribe(
                            _ =>
                            {
                                _messenger.Add("Настройки успешно применены");
                                HostScreen.Router.NavigateBack.Execute(null);
                            });
                }

                return _flushCommand;
            }
        }
        public IList<ISettingEditor> SettingEditors
        {
            get { return this._settingEditorsProvider.GetEditors().ToList(); }
        }
        public ISettingEditor SelectedSettingsEditor
        {
            get { return this._settingsEditor; }
            set { this.RaiseAndSetIfChanged(ref this._settingsEditor, value); }
        }
        public string UrlPathSegment
        {
            get;
            private set;
        }
        public IScreen HostScreen
        {
            get;
            private set;
        }

        public void Flush()
        {
            // flushing setting
            _getSettingsManager().Flush();

            // adjust and clear dirty settings
            _dirtySettings.DoForEach(_adjustManager.TryAdjust);
            _dirtySettings.Clear();
        }

        private void Binding()
        {
            this.WhenAnyValue(x => x.SelectedSettingsEditor)
                .Where(settingEditor => settingEditor != null)
                .Catch(OnError)
                .Subscribe(
                    settingEditor =>
                    {
                        ISetting setting = _dirtySettings.FirstOrDefault(x => x.Name == settingEditor.Name)
                                           ?? _getSettingsManager().GetSetting(settingEditor.Name);

                        if (setting != null)
                        {
                            settingEditor.SetSetting(setting);
                            _getSettingsManager().RegisterChanges(setting);
                            _dirtySettings.Add(setting);
                        }
                    });
        }
        private void OnError(Exception exception)
        {
            UserError.Throw("Не удалось сохранить настройки", exception);
        }
        private Func<ISettingsManager> InitSettingManager(ISettingManagerFactory settingManagerFactory)
        {
            return () => {
                try {
                    if (_settingsManager != null) {
                        return _settingsManager;
                    }
                    var settingsManager = settingManagerFactory.Create(PersistSetting.Remote);
                    settingsManager.ThrownException.Subscribe(OnError);
                    return (_settingsManager = settingsManager);
                }
                catch (Exception e) {
                    UserError.Throw("Не удалось инициализировать менеджер настроек", e);
                    HostScreen.Router.NavigateBack.Execute(null);
                    return EmptySettingManager.Create();
                }
            };
        }

        class EmptySettingManager : ISettingsManager
        {
            public IObservable<Exception> ThrownException { get; private set; }

            public static EmptySettingManager Create()
            {
                return new EmptySettingManager();
            }
            public ISetting GetSetting(string name)
            {
                return null;
            }
            public void Flush()
            {
            }
            public void ResetChanges()
            {
            }
            public void Synchronization()
            {
            }
            public void RegisterChanges(ISetting setting)
            {
            }
            public void RegisterAsRemoved(ISetting setting)
            {
            }
            public IEnumerable<ISetting> GetSettings()
            {
                return null;
            }
        }
    }
}
