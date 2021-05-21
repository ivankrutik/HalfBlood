namespace Halfblood.Common.Settings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    using Halfblood.Common.Settings.Adjuster;

    [Export(typeof(ISettingManagerFactory))]
    [Export(typeof(IGetSettingFactory))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SettingManagerFactory : ISettingManagerFactory, IGetSettingFactory
    {
        private static ISettingsManager localSettingsManager;
        private static ISettingsManager remoteSettingsManager;

        [Import] private Lazy<IParserSetting> _parserSetting;
        [Import] private Lazy<ISettingsService> _remoteSettingsService;
        [Import("LOCAL")] private Lazy<ISettingsService> _localSettingsService;
        [Import] private Lazy<IEmptySettingsProvider> _remoteSettingsProvider;
        [Import("LOCAL")] private Lazy<IEmptySettingsProvider> _localeSettingsProvider;
        private const string APP_NAME = "HALFBLOOD";
        
        public ISettingsManager Create(PersistSetting persistSetting)
        {
            switch (persistSetting)
            {
                case PersistSetting.Local:
                    return localSettingsManager
                       ?? (localSettingsManager =
                           SettingsManager.Create(_localSettingsService.Value, APP_NAME, _parserSetting.Value, _localeSettingsProvider.Value));
                case PersistSetting.Remote:
                    return remoteSettingsManager
                        ?? (remoteSettingsManager =
                            SettingsManager.Create(_remoteSettingsService.Value, APP_NAME, _parserSetting.Value, _remoteSettingsProvider.Value));
                default:
                    throw new ArgumentOutOfRangeException("persistSetting");
            }
        }

        IGetSetting IGetSettingFactory.Create()
        {
            Create(PersistSetting.Local);
            Create(PersistSetting.Remote);

            return new GetSettings(localSettingsManager.GetSettings().Concat(remoteSettingsManager.GetSettings()));
        }

        class GetSettings : IGetSetting
        {
            private readonly IEnumerable<ISetting> _settings;

            public GetSettings(IEnumerable<ISetting> settings)
            {
                _settings = settings;
            }

            public ISetting GetSetting(string name)
            {
                return _settings.FirstOrDefault(setting => setting.Name == name);
            }
        }
    }

    [Export("LOCAL", typeof(IGetSettingFactory))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class LocaleSettingManagerFactory : ISettingManagerFactory, IGetSettingFactory
    {
        private static ISettingsManager localSettingsManager;

        [Import] private Lazy<IParserSetting> _parserSetting;
        [Import("LOCAL")] private Lazy<ISettingsService> _localSettingsService;
        [Import("LOCAL")] private Lazy<IEmptySettingsProvider> _localeSettingsProvider;
        private const string APP_NAME = "HALFBLOOD";

        public ISettingsManager Create(PersistSetting persistSetting)
        {
            return localSettingsManager
                   ?? (localSettingsManager =
                       SettingsManager.Create(
                           _localSettingsService.Value,
                           APP_NAME,
                           _parserSetting.Value,
                           _localeSettingsProvider.Value));
        }

        IGetSetting IGetSettingFactory.Create()
        {
            Create(PersistSetting.Local);
            Create(PersistSetting.Remote);

            return new GetSettings(localSettingsManager.GetSettings());
        }

        class GetSettings : IGetSetting
        {
            private readonly IEnumerable<ISetting> _settings;

            public GetSettings(IEnumerable<ISetting> settings)
            {
                _settings = settings;
            }

            public ISetting GetSetting(string name)
            {
                return _settings.FirstOrDefault(setting => setting.Name == name);
            }
        }
    }
}