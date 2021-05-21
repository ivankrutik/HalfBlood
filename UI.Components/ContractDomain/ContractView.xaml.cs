// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractView.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ContractView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.ContractDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Controls;

    using Halfblood.Common;
    using ReactiveUI;
    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.ContractDomain;

    [Export(typeof(IViewFor<IContractViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ContractView : UserControl, IViewFor<IContractViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public ContractView()
        {
            InitializeComponent();

            _disposableContext = new DisposableContext(this);
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IContractViewModel ViewModel
        {
            get { return DataContext as IContractViewModel; }
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
            set { this.ViewModel = (IContractViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.ContractFilterViewModel.Result,
                    v => v.DtGridContract.ItemsSource);
            yield return this.Bind(this.ViewModel, vm => vm.SelectedSContract, v => v.DtGridContract.SelectedItem);
            yield return
                this.OneWayBind(this.ViewModel, vm => vm.ContractFilterViewModel.IsBusy, v => v.BusyIndicator.IsActive);
            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.StagesOfTheContractFilterViewModel.IsBusy,
                    v => v.BusyIndicatorStage.IsActive);
            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.PlanAndSpecificationFilterViewModel.IsBusy,
                    v => v.BusyIndicatorPlanAndSpecification.IsActive);
            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.StagesOfTheContractFilterViewModel.Result,
                    v => v.DtGridStage.ItemsSource);
            yield return
                this.Bind(this.ViewModel, vm => vm.SelectedStagesOfTheContract, v => v.DtGridStage.SelectedItem);
            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.PlanAndSpecificationFilterViewModel.Result,
                    v => v.DtGridPlanAndSpecification.ItemsSource);
        }
        private void CkbShowCloseContracts_Checked(object sender, RoutedEventArgs e)
        {
            this.ViewModel.ContractFilterViewModel.Filter.State = (bool)((CheckBox)sender).IsChecked
                                                                      ? ContractStatusState.Cloused
                                                                      : ContractStatusState.Approved;
            this.ViewModel.ContractFilterViewModel.InvokeCommand.Execute(null);
        }
        private void CkbShowCloseStages_Unchecked(object sender, RoutedEventArgs e)
        {
            this.ViewModel.StagesOfTheContractFilterViewModel.Filter.State = (bool)((CheckBox)sender).IsChecked
                                                                                 ? StageStatusState.Close
                                                                                 : StageStatusState.Open;
            
            if (ViewModel.SelectedSContract == null)
            {
                return;
            }
            this.ViewModel.StagesOfTheContractFilterViewModel.InvokeCommand.Execute(null);
        }
    }
}
