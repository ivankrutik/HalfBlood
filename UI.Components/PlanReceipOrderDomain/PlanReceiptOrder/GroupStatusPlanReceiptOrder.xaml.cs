// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GroupStatusPlanReceiptOrder.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Interaction logic for GroupStatusPlanReceiptOrder.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.PlanReceipOrderDomain.PlanReceiptOrder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using System.Windows.Controls;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;

    /// <summary>
    /// Interaction logic for GroupStatusPlanReceiptOrder.xaml
    /// </summary>
    [Export(typeof(IViewFor<IChangeGroupStateViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class GroupStatusPlanReceiptOrder : UserControl, IViewFor<IChangeGroupStateViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public GroupStatusPlanReceiptOrder()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        public IChangeGroupStateViewModel ViewModel
        {
            get { return DataContext as IChangeGroupStateViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(this.Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IChangeGroupStateViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return
                this.ViewModel.WhenAny(x => x.IsBusy)
                    .ObserveOnUiSafeScheduler()
                    .Subscribe(isBusy => Root.IsEnabled = !isBusy);
            
            yield return this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.ProgressRing.IsActive);
            
            yield return this.BindCommand(ViewModel, vm => vm.ChangeGroupStatusCommand, v => v.ChangeStateButton);

            yield return
                PersonalAccountsCompleteBox.Binding(
                    ViewModel.FilteringObject,
                    (vm, value) => vm.Filter.Numb = value,
                    isBusy => BusyPersonalAccounts.IsIndeterminate = isBusy);
        }
    }
}
