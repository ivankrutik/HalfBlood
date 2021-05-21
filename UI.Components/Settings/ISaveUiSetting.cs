namespace UI.Components.Settings
{
    using System.ComponentModel.Composition;

    using Halfblood.Common.Settings;

    public interface ISaveUiSetting
    {
        void Save();
    }

    [Export(typeof(ISaveUiSetting)), PartCreationPolicy(CreationPolicy.Shared)]
    public class SaveSettingAfterClosingApp : ISaveUiSetting
    {
        private readonly ISettingManagerFactory _settingManagerFactory;

        [ImportingConstructor]
        public SaveSettingAfterClosingApp(
            ISettingManagerFactory settingManagerFactory)
        {
            _settingManagerFactory = settingManagerFactory;
        }

        public void Save()
        {
            ISettingsManager settingsManager = _settingManagerFactory.Create(PersistSetting.Remote);
            settingsManager.Flush();

            settingsManager = _settingManagerFactory.Create(PersistSetting.Local);
            settingsManager.Flush();
        }
    }
}