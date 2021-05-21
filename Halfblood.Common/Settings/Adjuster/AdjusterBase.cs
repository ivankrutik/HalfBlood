namespace Halfblood.Common.Settings.Adjuster
{
    public abstract class ObjectAdjusterBase<TAdjustable, TSetting> : IObjectAdjuster<TAdjustable, TSetting>
        where TSetting : ISetting
    {
        public abstract string Name { get; }

        public bool Adjust(object @object, ISetting setting)
        {
            if (@object is TAdjustable && setting is TSetting)
            {
                return Adjust((TAdjustable)@object, (TSetting)setting);
            }

            return false;
        }

        public abstract bool Adjust(TAdjustable adjustable, TSetting setting);
    }
}