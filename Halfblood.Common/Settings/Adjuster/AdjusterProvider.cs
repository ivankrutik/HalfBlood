namespace Halfblood.Common.Settings.Adjuster
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    public interface IAdjusterProvider
    {
        IEnumerable<IAdjuster> GetAdjusters();

        IIndependencyAdjuster GetAdjuster(Type settingType);
        IIndependencyAdjuster<TSetting> GetAdjuster<TSetting>()
            where TSetting : ISetting;

        IObjectAdjuster GetAdjuster(Type adjustableType, Type settingType);
        IObjectAdjuster<TAdjustable, TSetting> GetAdjuster<TAdjustable, TSetting>()
            where TSetting : ISetting;
    }
    public interface IAdjusterMetadata
    {
        Type AdjustableType { get; }
        Type SettingType { get; }
    }

    [Export(typeof(IAdjusterProvider))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AdjusterProvider : MefLoaderBase<IAdjuster, IAdjusterMetadata, Tuple<Type, Type>, Func<IAdjuster>>,
                                    IAdjusterProvider
    {
        public IEnumerable<IAdjuster> GetAdjusters()
        {
            return Contents.Select(x => x.Value());
        }

        public IIndependencyAdjuster GetAdjuster(Type settingType)
        {
            if (this.Contents.ContainsKey(Tuple.Create(NoneType.None, settingType)))
            {
                return Contents[Tuple.Create(NoneType.None, settingType)]() as IIndependencyAdjuster;
            }

            return null;
        }
        public IIndependencyAdjuster<TSetting> GetAdjuster<TSetting>() where TSetting : ISetting
        {
            return (IIndependencyAdjuster<TSetting>)GetAdjuster(typeof(TSetting));
        }
        public IObjectAdjuster GetAdjuster(Type adjustableType, Type settingType)
        {
            if (this.Contents.ContainsKey(Tuple.Create(adjustableType, settingType)))
            {
                return Contents[Tuple.Create(adjustableType, settingType)]() as IObjectAdjuster;
            }

            return null;
        }
        public IObjectAdjuster<TAdjustable, TSetting> GetAdjuster<TAdjustable, TSetting>()
            where TSetting : ISetting
        {
            return (IObjectAdjuster<TAdjustable, TSetting>)GetAdjuster(typeof(TAdjustable), typeof(TSetting));
        }

        protected override void Imports(Lazy<IAdjuster, IAdjusterMetadata> lazy)
        {
            Contents.Add(
                Tuple.Create(lazy.Metadata.AdjustableType, lazy.Metadata.SettingType),
                () => lazy.Value);
        }
    }
}