// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificationView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Логика взаимодействия для CertificationView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.CuttingOrderDomain.Certification
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    using ReactiveUI;
    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.CuttingOrderDomain;

    /// <summary>
    /// The certification view.
    /// </summary>
    [Export(typeof(IViewFor<ICertificationViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class CertificationView : UserControl, IViewFor<ICertificationViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public CertificationView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        public ICertificationViewModel ViewModel
        {
            get { return DataContext as ICertificationViewModel; }
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
            set { this.ViewModel = (ICertificationViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.Bind(
                  this.ViewModel, vm => vm.SelectedCertification, v => v.DtGridCertifications.SelectedItem);

            yield return
                this.OneWayBind(
                    this.ViewModel, vm => vm.CertificationFilterViewModel.Result, v => v.DtGridCertifications.ItemsSource);

            yield return
                this.OneWayBind(
                        this.ViewModel, vm => vm.CertificationFilterViewModel.IsBusy, v => v.BusyIndicator.IsActive);
        }
    }
}
