namespace Halfblood.Test.MockObjects
{
    using System.ComponentModel.Composition;

    using Halfblood.Common.Settings;

    [Export(typeof(ISettingsService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FakeSettingsService : ISettingsService
    {
        public void SaveSetting(ISettingsModel settingModel)
        {
        }

        public bool ExistSetting(string appName)
        {
            return true;
        }

        public ISettingsModel Get(string appName)
        {
            return new SettingsModel
            {
                Application = appName,
                Id = 100,
                SettingsInJson =
                    "{\"ColorSetting\":\"{\"Accent\":\"'Steel'\",\"Theme\":1,\"Name\":\"ColorSetting\"}\"}"
            };
        }
    }
}
