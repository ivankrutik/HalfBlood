namespace Halfblood.Common.Settings.Editors
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Reactive.Linq;

    using Halfblood.Common.Helpers;

    [Export(typeof(ISettingEditorsProvider))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SettingEditorsProvider : ISettingEditorsProvider
    {
        [ImportMany]
        private Lazy<ISettingEditor>[] _settingEditorsLazy;
        private IEnumerable<ISettingEditor> _readonlySettingEditors;
        private readonly IList<ISettingEditor> _settingEditors = new ObservableCollection<ISettingEditor>();

        public IEnumerable<ISettingEditor> GetEditors()
        {
            if (_settingEditorsLazy != null)
            {
                _settingEditorsLazy.DoForEach(x => Register(x.Value));
                _settingEditorsLazy = null;
            }

            return _readonlySettingEditors
                   ?? (_readonlySettingEditors =
                       new ReadOnlyCollection<ISettingEditor>(_settingEditors));
        }

        public void Register(ISettingEditor settingEditor)
        {
            Contract.Requires(settingEditor != null, "The setting must be not null");

            if (_settingEditors.Any(x => x.Name == settingEditor.Name))
            {
                throw new InvalidOperationException("The setting {0} already exist".StringFormat(settingEditor));
            }

            _settingEditors.Add(settingEditor);
        }
    }
}
