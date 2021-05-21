namespace Halfblood.Common.Settings.Editors
{
    using System;
    using System.ComponentModel.Composition;

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class SettingEditorAttribute : ExportAttribute
    {
        public SettingEditorAttribute()
            : base(typeof(ISettingEditor))
        {
        }
    }
}