namespace Halfblood.Common.Settings.Adjuster
{
    using System;
    using System.ComponentModel.Composition;
    using System.Linq;

    using Halfblood.Common.Helpers;
    using Halfblood.Common.Interceptors;
    using Halfblood.Common.Log;

    [Interceptor]
    [Export("LOCAL", typeof(IObjctAdjusterManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class LocalObjctAdjusterManager : IObjctAdjusterManager
    {
        private readonly IAdjusterProvider _adjusterProvider;
        private readonly IGetSettingFactory _getSettingFactory;
        private IGetSetting _getSettings;

        [ImportingConstructor]
        public LocalObjctAdjusterManager(IAdjusterProvider adjusterProvider, [Import("LOCAL")] IGetSettingFactory getSettingFactory)
        {
            _adjusterProvider = adjusterProvider;
            _getSettingFactory = getSettingFactory;
        }

        public void TryAdjust(object @object)
        {
            var adjusters = _adjusterProvider.GetAdjusters().OfType<IObjectAdjuster>();

            foreach (IObjectAdjuster adjuster in adjusters)
            {
                ISetting setting = GetSetting().GetSetting(adjuster.Name);

                if (setting != null)
                {
                    try
                    {
                        if (adjuster.Adjust(@object, setting))
                        {
                            return;
                        }
                    }
                    catch (Exception e)
                    {
                        LogManager.Log.Debug(
                            new InvalidOperationException(
                                "The try call adjust for object {0} and setting {1} is fail".StringFormat(
                                    @object,
                                    setting),
                                e));
                    }
                }
            }
        }
        public void Intercept(object @object)
        {
            TryAdjust(@object);
        }

        private IGetSetting GetSetting()
        {
            return this._getSettings ?? (this._getSettings = this._getSettingFactory.Create());
        }
    }

    [Export(typeof(IObjctAdjusterManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ObjctAdjusterManager : IObjctAdjusterManager
    {
        private readonly IAdjusterProvider _adjusterProvider;
        private readonly IGetSettingFactory _getSettingFactory;
        private IGetSetting _getSetting;

        [ImportingConstructor]
        public ObjctAdjusterManager(IAdjusterProvider adjusterProvider, IGetSettingFactory getSettingFactory)
        {
            _adjusterProvider = adjusterProvider;
            _getSettingFactory = getSettingFactory;
        }

        public void TryAdjust(object @object)
        {
            var adjusters = _adjusterProvider.GetAdjusters().OfType<IObjectAdjuster>();

            foreach (IObjectAdjuster adjuster in adjusters) {
                ISetting setting = null;

                try {
                    setting = GetSetting().GetSetting(adjuster.Name);
                }
                catch (Exception e) {
                    LogManager.Log.Debug(
                        new InvalidOperationException(
                            "The try get setting name: '{0}' for object {1} is fail".StringFormat(setting, @object),
                            e));
                    break;
                }

                if (setting != null) {
                    try {
                        if (adjuster.Adjust(@object, setting)) {
                            return;
                        }
                    }
                    catch (Exception e) {
                        LogManager.Log.Debug(
                            new InvalidOperationException(
                                "The try call adjust for object {0} and setting {1} is fail".StringFormat(
                                    @object,
                                    setting),
                                e));
                    }
                }
            }
        }
        public void Intercept(object @object)
        {
            this.TryAdjust(@object);
        }

        private IGetSetting GetSetting()
        {
            return _getSetting ?? (_getSetting = _getSettingFactory.Create());
        }
    }

    public interface IAdjuster
    {
        string Name { get; }

    }
    public interface IIndependencyAdjuster : IAdjuster
    {
        bool Adjust(ISetting setting);
    }
    public interface IIndependencyAdjuster<in TSetting> : IIndependencyAdjuster
        where TSetting : ISetting
    {
        bool Adjust(TSetting setting);
    }
    public interface IObjectAdjuster : IAdjuster
    {
        bool Adjust(object @object, ISetting setting);
    }
    public interface IObjectAdjuster<in TAdjustable, in TSetting> : IObjectAdjuster
        where TSetting : ISetting
    {
        bool Adjust(TAdjustable adjustable, TSetting setting);
    }
    public interface IGetSetting
    {
        ISetting GetSetting(string name);
    }

    public interface IObjctAdjusterManager : IInterceptor
    {
        void TryAdjust(object @object);
    }
}
