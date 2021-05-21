namespace UI.Components.CertificateQualityDomain.WarehouseQualityCertificateDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.WarehouseQualityCertificateDomain;

    [Export(typeof(IViewFor<IWarehouseQualityCertificateWithFilterViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class WarehouseQualityCertificateWithFilterView 
        : UserControl, IViewFor<IWarehouseQualityCertificateWithFilterViewModel>
    {
        private DisposableContext _disposableContext;

        public WarehouseQualityCertificateWithFilterView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        public IWarehouseQualityCertificateWithFilterViewModel ViewModel
        {
            get { return DataContext as IWarehouseQualityCertificateWithFilterViewModel; }
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
            set { this.ViewModel = (IWarehouseQualityCertificateWithFilterViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.WarehouseQualityCertificateViewModel,
                    v => v.WarehouseModelViewHost.ViewModel);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.WarehouseQualityCertificateViewModel.WarehouseQualityCertificateFilterViewModel,
                    v => v.WarehouseQualityCertificateFilterView.ViewModel);

            yield return
                this.OneWayBind(ViewModel,
                    vm => vm.WarehouseQualityCertificateViewModel.WarehouseQualityCertificateFilterViewModel.IsBusy,
                    v => v.BusyControl.IsActive);
        }
    }
}
