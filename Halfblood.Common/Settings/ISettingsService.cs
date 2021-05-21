namespace Halfblood.Common.Settings
{
    public interface ISettingsService
    {
        void SaveSetting(ISettingsModel settingModel);
        bool ExistSetting(string appName);
        ISettingsModel Get(string appName);
    }

    public interface ISettingsModel
    {
        long Id { get; }
        string Application { get; }
        string SettingsInJson { get; }
    }

    public class SettingsModel : ISettingsModel
    {
        public long Id { get; set; }
        public string Application { get; set; }
        public string SettingsInJson { get; set; }
    }
}
