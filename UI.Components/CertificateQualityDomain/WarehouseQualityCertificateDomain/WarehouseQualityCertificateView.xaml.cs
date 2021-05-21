namespace UI.Components.CertificateQualityDomain.WarehouseQualityCertificateDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Windows.Controls;
    using ReactiveUI;
    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.WarehouseQualityCertificateDomain;

    [Export(typeof(IViewFor<IWarehouseQualityCertificateViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class WarehouseQualityCertificateView : UserControl, IViewFor<IWarehouseQualityCertificateViewModel>
    {
        private readonly DisposableContext _disposableContext;
        private readonly MenuItem _takeMaterialMenuItem;
        private readonly MenuItem _removeMenuItem;

        public WarehouseQualityCertificateView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();

            _takeMaterialMenuItem =
                ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                    .First(x => x.Name == "TakeMaterialMenuItem");
            _removeMenuItem = ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                    .First(x => x.Name == "RemoveMenuItem");
        }

        public IWarehouseQualityCertificateViewModel ViewModel
        {
            get { return this.DataContext as IWarehouseQualityCertificateViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IWarehouseQualityCertificateViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.IsBusy,
                    v => v.BusyControl.IsActive);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.IsBusy,
                    v => v.RootGrid.IsEnabled,
                    isBusy => !isBusy);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.WarehouseQualityCertificateFilterViewModel.Result,
                    v => v.DtGridManufacturersCertificates.ItemsSource);

            yield return this.BindCommand(ViewModel, vm => vm.NavigateToScanCommand, v => v._takeMaterialMenuItem);
            yield return this.BindCommand(ViewModel, vm => vm.RemoveCommand, v => v._removeMenuItem);
            
                this.Bind(ViewModel, vm => vm.SelectedWarehouseQualityCertificate,
                    v => v.DtGridManufacturersCertificates.SelectedItem);
        }
    }
}
