namespace Halfblood.Common.Settings
{
    using System.Collections.Generic;

    public interface IParserSetting
    {
        IList<ISetting> Parse(ISettingsModel settingModel);
        string ToJson(IList<ISetting> settings);
    }
}