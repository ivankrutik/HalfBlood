namespace Halfblood.Common.Settings.Adjuster
{
    using System;
    using System.ComponentModel.Composition;
    using System.Linq;

    using Halfblood.Common.Helpers;
    using Halfblood.Common.Log;

    public interface IIndependencyAdjustManager
    {
        void AdjustAll();
        void TryAdjust(ISetting setting);
    }

    [Export(typeof(IIndependencyAdjustManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class IndependencyAdjustManager : IIndependencyAdjustManager
    {
        private readonly IAdjusterProvider _adjusterProvider;
        private readonly IGetSettingFactory _getSettingFactory;
        private IGetSetting _getSetting;

        [ImportingConstructor]
        public IndependencyAdjustManager(IAdjusterProvider adjusterProvider, IGetSettingFactory getSettingFactory)
        {
            _adjusterProvider = adjusterProvider;
            _getSettingFactory = getSettingFactory;
        }

        public void AdjustAll()
        {
            var adjusters = _adjusterProvider.GetAdjusters().OfType<IIndependencyAdjuster>();

            foreach (IIndependencyAdjuster adjuster in adjusters)
            {
                ISetting setting = null;
                try {
                    setting = GetSetting(adjuster.Name);
                }
                catch (Exception e) {
                    LogManager.Log.Debug(
                        new InvalidOperationException(
                            "The try get setting name: '{0}' for adjuster {1} is fail".StringFormat(adjuster.Name, adjuster),
                            e));
                    break;
                }

                if (setting == null) {
                    LogManager.Log.Debug(
                        new ArgumentNullException(
                            "The setting for adjuster {0} with not found".StringFormat(adjuster)));
                }
                else if (adjuster.Adjust(setting)) {
                    return;
                }
            }
        }
        public void TryAdjust(ISetting setting)
        {
            IIndependencyAdjuster adjuster = _adjusterProvider.GetAdjuster(setting.GetType());
            if (adjuster != null)
            {
                try
                {
                    adjuster.Adjust(setting);
                }
                catch (Exception e)
                {
                    LogManager.Log.Debug(
                        new InvalidOperationException(
                            "The try call adjust {0} for setting {1} is fail".StringFormat(adjuster, setting),
                            e));
                }
            }
            else LogManager.Log.Debug("The adjuster for setting is not found".StringFormat(setting));
        }

        private ISetting GetSetting(string name)
        {
            if (_getSetting == null)
            {
                _getSetting = _getSettingFactory.Create();
            }

            return _getSetting.GetSetting(name);
        }
    }
}