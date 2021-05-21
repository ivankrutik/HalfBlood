// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManufacturersCertificateView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Логика взаимодействия для ManufacturersCertificateView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Windows.Controls;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.CertificateQualityServiceDomain.ManufacturersCertificateDomain;

    [Export(typeof(IViewFor<IManufacturersCertificateViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ManufacturersCertificateView : UserControl, IViewFor<IManufacturersCertificateViewModel>
    {
        private readonly DisposableContext _disposableContext;
        private MenuItem _takeMenuItem;
        private MenuItem _dealMenuItem;
        private MenuItem _showMeTheScanMenuItem;
        private MenuItem _setStateMenuItem;
        private MenuItem _createPermissionMaterialMenuItem;
        private MenuItem _createActSelectionProbeMenuItem;

        public ManufacturersCertificateView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
            _dealMenuItem =
                ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                    .First(x => x.Name == "DealMenuItem");
            _takeMenuItem =
                ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                    .First(x => x.Name == "TakeMaterialMenuItem");
            _showMeTheScanMenuItem =
                ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                    .First(x => x.Name == "ShowMeTheScanMenuItem");
            _setStateMenuItem =
                ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                    .First(x => x.Name == "StatusRowMenuItem");
            _createPermissionMaterialMenuItem =
                ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                    .First(x => x.Name == "CreatePermissionMaterialMenuItem");
            _createActSelectionProbeMenuItem =
                  ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                    .First(x => x.Name == "CreateActSelectionProbeMenuItem");
        }

        public IManufacturersCertificateViewModel ViewModel
        {
            get { return this.DataContext as IManufacturersCertificateViewModel; }
            set
            {
                this.DataContext = value;
                this._disposableContext.Dispose();
                this._disposableContext.Add(this.Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IManufacturersCertificateViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.BindCommand(ViewModel, vm => vm.ShowScanCertificateCommand, v => v._showMeTheScanMenuItem);
            yield return this.BindCommand(this.ViewModel, vm => vm.TakeMaterialCommand, v => v._takeMenuItem);
            yield return this.BindCommand(this.ViewModel, vm => vm.NavigateToDealCommand, v => v._dealMenuItem);
            yield return this.BindCommand(this.ViewModel, vm => vm.SetStateCommand, v => v._setStateMenuItem);
            yield return this.BindCommand(this.ViewModel, vm => vm.CreatePermissionMaterialCommand, v => v._createPermissionMaterialMenuItem);
            yield return this.BindCommand(this.ViewModel, vm => vm.CreateActSelectionProbeCommand, v => v._createActSelectionProbeMenuItem);

            yield return this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.BusyControl.IsActive);
            yield return this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.Root.IsEnabled, isBusy => !isBusy);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.WarehouseQualityCertificateViewModel,
                    v => v.ModelViewHost.ViewModel);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.CertificateQualityRestFilterViewModel,
                    v => v.ManufacturersCertificateFilterView.ViewModel);

            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.CertificateQualityRestFilterViewModel.Result,
                    v => v.DtGridManufacturersCertificates.ItemsSource);

            yield return
                this.Bind(
                    this.ViewModel,
                    vm => vm.SelectedCertificateQuality,
                    v => v.DtGridManufacturersCertificates.SelectedItem);

            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.CertificateQualityRestFilterViewModel.IsBusy,
                    v => v.BusyIndicator.IsActive);
        }
    }
}