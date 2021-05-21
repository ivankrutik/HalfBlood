namespace UI.Components.CertificateQualityDomain.PermissionMaterialDomain.StatusPermissionMaterialDomain
{
    using Halfblood.Common;
    using ReactiveUI;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Controls;
    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.PermissionMaterialDomain;

    [Export(typeof(IViewFor<IStatusPermissionMaterialUserViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class StatusPermissionMaterialUserView : UserControl, IViewFor<IStatusPermissionMaterialUserViewModel>
    {
        private readonly DisposableContext _disposableContext;


        public StatusPermissionMaterialUserView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }


        public IStatusPermissionMaterialUserViewModel ViewModel
        {
            get { return DataContext as IStatusPermissionMaterialUserViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (IStatusPermissionMaterialUserViewModel)value; }
        }


        private IEnumerable<IDisposable> Binding()
        {
            yield return this.BindCommand(ViewModel, vm => vm.InvokeCommand, v => v.SetExpectingState);
            yield return this.BindCommand(ViewModel, vm => vm.InvokeCommand, v => v.SetConfirmedState);
            yield return this.BindCommand(ViewModel, vm => vm.InvokeCommand, v => v.SetNotConfirmedState);
            yield return this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.BusyControl.IsActive);
            yield return ViewModel.WhenAny(x => x.IsBusy, x => x.Value).Subscribe(isBusy => Root.IsEnabled = !isBusy);
        }


        private void ChangeStatusClick(object sender, RoutedEventArgs e)
        {
            ViewModel.State = (PermissionMaterialUserState)((FrameworkElement)sender).Tag;
        }
    }
}