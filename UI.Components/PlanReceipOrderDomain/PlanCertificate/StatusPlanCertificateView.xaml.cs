// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusPlanCertificateView.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Interaction logic for StatusPlanCertificateView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.PlanReceipOrderDomain.PlanCertificate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Controls;

    using Halfblood.Common;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;

    /// <summary>
    /// Interaction logic for StatusPlanCertificateView.xaml
    /// </summary>
    [Export(typeof(IViewFor<IStatusPlanCertificateViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class StatusPlanCertificateView : UserControl, IViewFor<IStatusPlanCertificateViewModel>
    {
        private readonly DisposableContext _disposableContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusPlanCertificateView"/> class.
        /// </summary>
        public StatusPlanCertificateView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IStatusPlanCertificateViewModel ViewModel
        {
            get { return DataContext as IStatusPlanCertificateViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(this.Binding());
            }
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IStatusPlanCertificateViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.BindCommand(ViewModel, vm => vm.InvokeCommand, v => v.SetCloseState);
            yield return this.BindCommand(ViewModel, vm => vm.InvokeCommand, v => v.SetConfirmState);
            yield return this.BindCommand(ViewModel, vm => vm.InvokeCommand, v => v.SetNotConfirmState);
            yield return this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.BusyControl.IsActive);
            yield return ViewModel.WhenAny(x => x.IsBusy, x => x.Value).Subscribe(isBusy => Root.IsEnabled = !isBusy);
        }
        private void ChangeStatusClick(object sender, RoutedEventArgs e)
        {
            ViewModel.State = (PlanCertificateState)((FrameworkElement)sender).Tag;
        }
    }
}
