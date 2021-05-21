namespace Halfblood.Common.Settings
{
    using Halfblood.Common.Settings.Adjuster;

    public interface IGetSettingFactory
    {
        IGetSetting Create();
    }
}