namespace UI.Infrastructure.ViewModels.Settings
{
    using System.Collections.Generic;
    using System.Windows.Input;

    using Halfblood.Common.Settings.Editors;

    using ReactiveUI;

    public interface IEditorSettingViewModel : IRoutableViewModel
    {
        bool IsBusy { get; }
        ICommand FlushCommand { get; }
        IList<ISettingEditor> SettingEditors { get; }
        ISettingEditor SelectedSettingsEditor { get; set; }
    }
}
