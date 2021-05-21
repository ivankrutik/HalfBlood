namespace Halfblood.Common.Settings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Linq;
    using System.Diagnostics.Contracts;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;

    using Halfblood.Common.Helpers;
    using Halfblood.Common.Log;

    using Newtonsoft.Json;

    public enum ChangesFlag
    {
        Modify,
        Inserting,
        Removing
    }

    /// <summary>
    /// Содержит в себе настройки для [приложения,юзера]
    /// может обновлять настройки
    /// </summary>
    public class SettingsManager : ISettingsManager
    {
        #region PRIVATE FIELDS
        private static IEmptySettingsProvider emptySettingsProvider;
        private readonly string _appName;
        private readonly IParserSetting _parserSetting;
        private readonly ISettingsService _settingsService;
        private readonly Subject<Exception> _thrownException = new Subject<Exception>();
        private ISettingsModel _settingsModel;
        private IList<ISetting> _actualSettings;
        private IList<ISetting> _initialSettings;
        #endregion

        protected SettingsManager(ISettingsService settingsService, string appName, IParserSetting parserSetting)
        {
            Contract.Requires(parserSetting != null);
            Contract.Requires(settingsService != null);
            Contract.Requires(!string.IsNullOrWhiteSpace(appName));

            _settingsService = settingsService;
            _appName = appName;
            _parserSetting = parserSetting;
        }

        public IObservable<Exception> ThrownException
        {
            get { return this._thrownException; }
        }

        public static ISettingsManager Create(
            ISettingsService settingsService,
            string appName,
            IParserSetting parserSetting,
            IEmptySettingsProvider emptySettingsProvider)
        {
            Contract.Requires(parserSetting != null);
            Contract.Requires(settingsService != null);
            Contract.Requires(!string.IsNullOrWhiteSpace(appName));

            SettingsManager.emptySettingsProvider = emptySettingsProvider;

            var settingManager = new SettingsManager(settingsService, appName, parserSetting);
            settingManager.Synchronization();

            return settingManager;
        }

        /// <summary>
        /// Сбрасывает все измененныя в настройках в хранилище.
        /// </summary>
        public void Flush()
        {
            IList<ISetting> settings = GetSettings().ToList();
            bool isUpdated = SaveOrUpdateSettings(settings, _settingsModel.Id);

            if (isUpdated)
            {
                Synchronization();
            }
        }

        public void ResetChanges()
        {
            _actualSettings.Clear();
            _initialSettings.DoForEach(_actualSettings.Add);
        }
        public void RegisterAsRemoved(ISetting setting)
        {
            if (_actualSettings.Any(x => x.Name == setting.Name))
            {
                _actualSettings.Remove(setting);
            }
            else throw new ArgumentOutOfRangeException("Removing fail. {0} not found".StringFormat(setting));
        }
        public void RegisterChanges(ISetting setting)
        {
            var oldSetting = _actualSettings.FirstOrDefault(x => x.Name == setting.Name);
            if (oldSetting != null)
            {
                _actualSettings.Remove(oldSetting);
            }

            _actualSettings.Add(setting);
        }
        public IEnumerable<ISetting> GetSettings()
        {
            return _actualSettings.Select(x => x.MakeCopy());
        }
        public ISetting GetSetting(string name)
        {
            ISetting setting = _actualSettings.FirstOrDefault(x => x.Name == name);
            if (setting != null)
            {
                return setting.MakeCopy();
            }

            LogManager.Log.Debug(new ArgumentException("The setting with name {0} not found".StringFormat(name)));
            return null;
        }
        public void Synchronization()
        {
            _settingsModel = CreateOrGet();
            if (_settingsModel != null) {
                _initialSettings = _parserSetting.Parse(_settingsModel);
                IList<ISetting> emptySettings = emptySettingsProvider.GetSettings().ToList();
                emptySettings.Except(_initialSettings, new SettingEqualityComparer()).DoForEach(_initialSettings.Add);
                _actualSettings = _initialSettings.Select(x => x.MakeCopy()).ToList();
            }
            else
            {
                _initialSettings = emptySettingsProvider.GetSettings().ToList();
                _actualSettings = _initialSettings.Select(x => x.MakeCopy()).ToList();
                _settingsModel = new SettingsModel {
                    Application = _appName,
                    SettingsInJson = _parserSetting.ToJson(_actualSettings)
                };
            }
        }
        private ISettingsModel CreateOrGet()
        {
            try {
                if (_settingsService.ExistSetting(_appName)) {
                    return _settingsService.Get(_appName);
                }
            }
            catch (Exception e) {
                _thrownException.OnError(e);
                return null;
            }

            IList<ISetting> settings = emptySettingsProvider.GetSettings().ToList();

            bool isUpdated = SaveOrUpdateSettings(settings);
            return isUpdated ? _settingsService.Get(_appName) : null;
        }
        private bool SaveOrUpdateSettings(IEnumerable<ISetting> settings, long settingId = 0)
        {
            var settingMmodel = new SettingsModel {
                Application = _appName,
                SettingsInJson = _parserSetting.ToJson(settings.ToList()),
                Id = settingId
            };

            try {
                _settingsService.SaveSetting(settingMmodel);
                return true;
            }
            catch (Exception e) {
                _thrownException.OnError(e);
                return false;
            }
        }
    }

    class SettingEqualityComparer : IEqualityComparer<ISetting>
    {
        public bool Equals(ISetting x, ISetting y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(ISetting obj)
        {
            return obj.Name.GetHashCode();
        }
    }

    [Export("LOCAL", typeof(ISettingsService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LocalSettingsService : ISettingsService
    {
        private const string SETTING_FILE = "setting.hb";
        private string _path;

        public LocalSettingsService()
        {
            File.Open(Path, FileMode.OpenOrCreate).Dispose();
        }

        public void SaveSetting(ISettingsModel settingModel)
        {
            string json = JsonConvert.SerializeObject(settingModel);
            using (var streamWriter = new StreamWriter(Path))
            {
                streamWriter.Write(json);
            }
        }
        public bool ExistSetting(string appName)
        {
            using (FileStream stream = File.Open(Path, FileMode.Open))
            {
                return stream.ReadByte() != -1;
            }
        }
        public ISettingsModel Get(string appName)
        {
            using (var streamWriter = new StreamReader(Path))
            {
                string json = streamWriter.ReadToEnd();
                return JsonConvert.DeserializeObject<SettingsModel>(json);
            }
        }

        private string Path
        {
            get
            {
                return _path ?? (_path = AppDomain.CurrentDomain.BaseDirectory + SETTING_FILE);
            }
        }
    }
}
