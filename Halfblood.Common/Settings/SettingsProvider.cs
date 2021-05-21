namespace Halfblood.Common.Settings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    public interface ISettingMetadata
    {
        string Name { get; }
        PersistSetting PersistSetting { get; }
    }
    public interface IEmptySettingsProvider
    {
        //void Register(ISetting setting);
        //void Unregister(ISetting setting);
        bool IsExist(string name);
        IEnumerable<ISetting> GetSettings();
        ISetting GetSetting(string name);
    }
    internal class SettingMetadata : ISettingMetadata
    {
        public SettingMetadata(string name, PersistSetting persistSetting)
        {
            Name = name;
            PersistSetting = persistSetting;
        }

        public string Name { get; set; }
        public PersistSetting PersistSetting { get; private set; }
    }

    [Export(typeof(IEmptySettingsProvider))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class RemoteEmptySettingsProvider 
        : MefLoaderBase<ISetting, ISettingMetadata, string, Func<ISetting>>, IEmptySettingsProvider
    {
        private readonly IList<Tuple<ISettingMetadata, ISetting>> _settings =
            new List<Tuple<ISettingMetadata, ISetting>>();

        public void Register(ISetting setting)
        {
            Unregister(setting);
            _settings.Add(Tuple.Create((ISettingMetadata)new SettingMetadata(setting.Name, PersistSetting.Remote), setting));
        }
        public void Unregister(ISetting setting)
        {
            Tuple<ISettingMetadata, ISetting> oldSetting = _settings.FirstOrDefault(
                tuple => tuple.Item2.Equals(setting));

            if (oldSetting != null)
            {
                _settings.Remove(oldSetting);
            }
        }
        public bool IsExist(string name)
        {
            return _settings.Any(tuple => tuple.Item2.Name == name);
        }
        public IEnumerable<ISetting> GetSettings()
        {
            return _settings.Where(x => x.Item1.PersistSetting == PersistSetting.Remote).Select(x => x.Item2);
        }
        public ISetting GetSetting(string name)
        {
            var tuple = _settings.FirstOrDefault(x => x.Item2.Name == name);
            if (tuple != null)
            {
                return tuple.Item2;
            }

            return null;
        }

        protected override void Imports(Lazy<ISetting, ISettingMetadata> lazy)
        {
            _settings.Add(Tuple.Create(lazy.Metadata, lazy.Value));
        }
    }

    [Export("LOCAL", typeof(IEmptySettingsProvider))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class LocalEmptySettingProvider 
        : MefLoaderBase<ISetting, ISettingMetadata, string, Func<ISetting>>, IEmptySettingsProvider
    {
        private readonly IList<Tuple<ISettingMetadata, ISetting>> _settings =
            new List<Tuple<ISettingMetadata, ISetting>>();

        public void Register(ISetting setting)
        {
            Unregister(setting);
            _settings.Add(Tuple.Create((ISettingMetadata)new SettingMetadata(setting.Name, PersistSetting.Local), setting));
        }
        public void Unregister(ISetting setting)
        {
            Tuple<ISettingMetadata, ISetting> oldSetting = _settings.FirstOrDefault(
                tuple => tuple.Item2.Equals(setting));

            if (oldSetting != null)
            {
                _settings.Remove(oldSetting);
            }
        }
        public bool IsExist(string name)
        {
            return _settings.Any(tuple => tuple.Item2.Name == name);
        }
        public IEnumerable<ISetting> GetSettings()
        {
            return _settings.Where(x => x.Item1.PersistSetting == PersistSetting.Local).Select(x => x.Item2);
        }
        public ISetting GetSetting(string name)
        {
            var tuple = _settings.FirstOrDefault(x => x.Item2.Name == name);
            if (tuple != null)
            {
                return tuple.Item2;
            }

            return null;

        }

        protected override void Imports(Lazy<ISetting, ISettingMetadata> lazy)
        {
            _settings.Add(Tuple.Create(lazy.Metadata, lazy.Value));
        }
    }
}