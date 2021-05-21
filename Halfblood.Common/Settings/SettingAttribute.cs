namespace Halfblood.Common.Settings
{
    using System;
    using System.ComponentModel.Composition;

    public enum PersistSetting : byte
    {
        Local = 0,
        Remote
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class SettingAttribute : ExportAttribute
    {
        public SettingAttribute(PersistSetting persistSetting)
            : base(typeof(ISetting))
        {
            PersistSetting = persistSetting;
        }

        public PersistSetting PersistSetting { get; private set; }
        public string Name { get; set; }
    }
}