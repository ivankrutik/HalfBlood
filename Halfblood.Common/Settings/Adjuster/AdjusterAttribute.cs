namespace Halfblood.Common.Settings.Adjuster
{
    using System;
    using System.ComponentModel.Composition;

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class AdjusterAttribute : ExportAttribute
    {
        public AdjusterAttribute()
            : base(typeof(IAdjuster))
        {
            AdjustableType = NoneType.None;
            SettingType = NoneType.None;
        }

        public Type AdjustableType { get; set; }
        public Type SettingType { get; set; }
    }

    internal class NoneType
    {
        private static NoneType _none;

        static NoneType()
        {
            _none = new NoneType();
        }

        public static Type None
        {
            get { return _none.GetType(); }
        }
    }
}