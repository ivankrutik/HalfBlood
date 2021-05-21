// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderDetailedView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Логика взаимодействия для EditableCuttingOrderView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.CuttingOrderDomain.CuttingOrder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    using ReactiveUI;
    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.CuttingOrderDomain;

    /// <summary>
    /// The cutting order detailed view.
    /// </summary>
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IViewFor<ICuttingOrderDetailedViewModel>))]
    public partial class CuttingOrderDetailedView : UserControl, IViewFor<ICuttingOrderDetailedViewModel>
    {
        private readonly DisposableContext _disposableContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CuttingOrderDetailedView"/> class.
        /// </summary>
        public CuttingOrderDetailedView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public ICuttingOrderDetailedViewModel ViewModel
        {
            get { return DataContext as ICuttingOrderDetailedViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
            }
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (ICuttingOrderDetailedViewModel)value; }
        }

        /// <summary>
        /// The binding.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        private IEnumerable<IDisposable> Binding()
        {
            var cuttingOrderSpecificationViewModel = (ICuttingOrderSpecificationViewModel)this.CuttingOrderSpecificationView.ViewModel;
            var CertificationViewModel = (ICertificationViewModel)this.CertificationView.ViewModel;
            var sampleViewModel = (ISampleViewModel)this.SampleView.ViewModel;
            var sampleCertificationViewModel = (ISampleCertificationViewModel)this.SampleCertificationView.ViewModel;

            yield return
               this.OneWayBind(
                   this.ViewModel, vm => vm.IsBusy, v => v.BusyIndicator.IsActive);

            yield return
               ViewModel.WhenAny(x => x.IsBusy, x => x.Value)
                        .Subscribe(isBusy => Root.IsEnabled = !isBusy);

            yield return
                cuttingOrderSpecificationViewModel.WhenAny(x => x.SelectedCuttingOrderSpecification, x => x.Value)
                                        .Subscribe(spec =>
                                        {
                                            CertificationViewModel.SelectedCuttingOrderSpecification = spec;
                                            sampleViewModel.SelectedCuttingOrderSpecification = spec;
                                        });

            yield return
                sampleViewModel.WhenAny(x => x.SelectedSample, x => x.Value)
                            .Subscribe(sam => sampleCertificationViewModel.SelectedSample = sam);
        }
    }
}
