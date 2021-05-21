namespace UI.Components.Filters
{
    using Halfblood.Common;
    using Helpers;
    using Infrastructure.ViewModels.Filters;
    using ReactiveUI;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Controls;

    [Export(typeof(IViewFor<IPermissionMaterialFilterViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]

    public partial class PermissionMaterialFilterView : UserControl, IViewFor<IPermissionMaterialFilterViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public PermissionMaterialFilterView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        public IPermissionMaterialFilterViewModel ViewModel
        {
            get { return this.DataContext as IPermissionMaterialFilterViewModel; }
            set
            {
                this.DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IPermissionMaterialFilterViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.BindCommand(ViewModel, vm => vm.InvokeCommand, v => v.BtnLoad);
            yield return this.BindCommand(ViewModel, vm => vm.ClearFilterCommand, v => v.BtnClear);
        }


        private void PermissionMaterialStateOnChecked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var state = (PermissionMaterialState)checkBox.Content;

            ViewModel.Filter.States.Remove(state);

            if ((bool)checkBox.IsChecked)
            {
                ViewModel.Filter.States.Add(state);
            }
        }
    }
}