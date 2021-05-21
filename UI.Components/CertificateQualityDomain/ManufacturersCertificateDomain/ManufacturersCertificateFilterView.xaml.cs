namespace UI.Components.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.Filters;

    [Export(typeof(IViewFor<ICertificateQualityRestFilterViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ManufacturersCertificateFilterView : UserControl, IViewFor<ICertificateQualityRestFilterViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public ManufacturersCertificateFilterView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        public ICertificateQualityRestFilterViewModel ViewModel
        {
            get { return this.DataContext as ICertificateQualityRestFilterViewModel; }
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
            set { this.ViewModel = (ICertificateQualityRestFilterViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.BindCommand(this.ViewModel, vm => vm.InvokeCommand, v => v.BtnLoad);

            yield return
                this.AcbGostCast.Binding(
                    this.ViewModel.GostCast,
                    (model, s) => model.Filter.GostMarka = s,
                    isBusy => this.BusyGostCast.Visibility = isBusy.ToVisibility());

            yield return
                this.AcbGostMix.Binding(
                    this.ViewModel.GostMix,
                    (model, s) => model.Filter.GostMix = s,
                    isBusy => this.BusyGostMix.Visibility = isBusy.ToVisibility());

            yield return
                this.AcbMarka.Binding(
                    this.ViewModel.Marka,
                    (model, s) => model.Filter.Marka = s,
                    isBusy => this.BusyMarka.Visibility = isBusy.ToVisibility());

            yield return
                this.AcbMix.Binding(
                    this.ViewModel.Mix,
                    (model, s) => model.Filter.Mix = s,
                    isBusy => this.BusyMix.Visibility = isBusy.ToVisibility());
        }
    }
}
