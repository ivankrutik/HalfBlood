// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusPlanReceiptOrderView.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the StatusPlanReceiptOrderView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.PlanReceipOrderDomain.PersonalAccount
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
    /// The status personal account view.
    /// </summary>
    [Export(typeof(IViewFor<IStatusPersonalAccountViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class StatusPersonalAccountView : UserControl, IViewFor<IStatusPersonalAccountViewModel>
    {
        private readonly DisposableContext _disposableContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusPersonalAccountView"/> class.
        /// </summary>
        public StatusPersonalAccountView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IStatusPersonalAccountViewModel ViewModel
        {
            get { return DataContext as IStatusPersonalAccountViewModel; }
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
            set { this.ViewModel = (IStatusPersonalAccountViewModel)value; }
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
            ViewModel.State = (PlanReceiptOrderPersonalAccountState)((FrameworkElement)sender).Tag;
        }
    }
}
