namespace Halfblood.Common.Settings
{
    public interface ISettingManagerFactory
    {
        ISettingsManager Create(PersistSetting persistSetting);
    }
}