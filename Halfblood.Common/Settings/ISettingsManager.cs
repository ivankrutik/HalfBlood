namespace Halfblood.Common.Settings
{
    using System;
    using System.Collections.Generic;

    using Halfblood.Common.Settings.Adjuster;

    public interface ISettingsManager : IGetSetting
    {
        void Flush();
        void ResetChanges();
        void Synchronization();

        void RegisterChanges(ISetting setting);
        void RegisterAsRemoved(ISetting setting);

        IEnumerable<ISetting> GetSettings();
        IObservable<Exception> ThrownException { get; }
    }
}