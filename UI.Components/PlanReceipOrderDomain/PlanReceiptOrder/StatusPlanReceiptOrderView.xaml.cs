// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusPlanReceiptOrderView.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the StatusPlanReceiptOrderView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.PlanReceipOrderDomain.PlanReceiptOrder
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
    /// The status plan receipt order view.
    /// </summary>
    [Export(typeof(IViewFor<IStatusPlanReceiptOrderViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class StatusPlanReceiptOrderView : UserControl, IViewFor<IStatusPlanReceiptOrderViewModel>
    {
        private readonly DisposableContext _disposableContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusPlanReceiptOrderView"/> class.
        /// </summary>
        public StatusPlanReceiptOrderView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IStatusPlanReceiptOrderViewModel ViewModel
        {
            get { return DataContext as IStatusPlanReceiptOrderViewModel; }
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
            set { this.ViewModel = (IStatusPlanReceiptOrderViewModel)value; }
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
            ViewModel.State = (PlanReceiptOrderState)((FrameworkElement)sender).Tag;
        }
    }
}
