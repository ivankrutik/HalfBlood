namespace UI.Components.Settings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using Halfblood.Common.Log;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.Settings;

    [Export(typeof(IViewFor<IEditorSettingViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditorSettingView : UserControl, IViewFor<IEditorSettingViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public EditorSettingView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        ~EditorSettingView()
        {
            LogManager.Log.Debug("EditorSettingView is DESTROYED");
        }

        public IEditorSettingViewModel ViewModel
        {
            get { return this.DataContext as IEditorSettingViewModel; }
            set
            {
                this.DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(this.Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (IEditorSettingViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return
                this.Bind(ViewModel, vm => vm.SelectedSettingsEditor, v => v.EditorsSettingListBox.SelectedItem);

            yield return
                this.OneWayBind(ViewModel, vm => vm.SelectedSettingsEditor, v => v.ConcreteSettingsEditorHost.ViewModel);

            yield return this.BindCommand(ViewModel, vm => vm.FlushCommand, v => v.FlushButton);
            yield return this.OneWayBind(ViewModel, vm => vm.SettingEditors, v => v.EditorsSettingListBox.ItemsSource);
            yield return this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.IsBusyComponent.IsActive);
            yield return this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.RootGrid.IsEnabled, isBusy => !isBusy);
        }
    }
}
