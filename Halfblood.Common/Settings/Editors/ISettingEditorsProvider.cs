namespace Halfblood.Common.Settings.Editors
{
    using System.Collections.Generic;

    public interface ISettingEditorsProvider
    {
        IEnumerable<ISettingEditor> GetEditors();
        void Register(ISettingEditor settingEditor);
    }
    public interface ISettingEditor
    {
        string Name { get; }
        string Title { get; }
        string Description { get; }
        void SetSetting(ISetting setting);
    }
    public interface ISettingEditor<in TSetting> : ISettingEditor
        where TSetting : ISetting
    {
        void SetSetting(TSetting setting);
    }
}
