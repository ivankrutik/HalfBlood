namespace UI.Components.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using Halfblood.Common;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;

    [Export(typeof(IViewFor<IDummyViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DummyView : UserControl, IViewFor<IDummyViewModel>
    {
        private DisposableContext disposableContext;

        public DummyView()
        {
            disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        public IDummyViewModel ViewModel
        {
            get { return DataContext as IDummyViewModel; }
            set
            {
                DataContext = value;
                disposableContext.Dispose();
                disposableContext.Add(Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IDummyViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.Bind(ViewModel, vm => vm.Quantity, v => v.QuantityTextBox.Text);
            yield return this.Bind(ViewModel, vm => vm.DateOfBook, v => v.DatePickerTextBox.SelectedDate);
            yield return this.Bind(ViewModel, vm => vm.NumberOfBook, v => v.NumberOfBookTextBox.Text);
            yield return this.Bind(ViewModel, vm => vm.InStoreGasStationOilDepot, v => v.DepartmenAcb.SelectedItem);
            yield return this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.ProgressRing.IsActive);
            yield return this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.RootGroupBox.IsEnabled, isBusy => !isBusy);
            yield return this.BindCommand(ViewModel, vm => vm.DealCommand, v => v.DealButton);
            yield return
                this.DepartmenAcb.Binding(
                    this.ViewModel.StoreSearcher,
                    (model, s) => model.Filter.AzsNumber = s,
                    isBusy => this.StoreProgressBar.Visibility = isBusy.ToVisibility());
            yield return
                this.StoreEmployeeAcb.Binding(
                    ViewModel.EmployeeStoreFilterViewModel,
                    this.SetFilterForUser,
                    isBusy => this.StoreEmployeeBusy.Visibility = isBusy.ToVisibility());
            yield return
                this.OtkEmployeeAcb.Binding(
                    ViewModel.EmployeeOTKFilterViewModel,
                    this.SetFilterForUser,
                    isBusy => this.OtkEmployeeBusy.Visibility = isBusy.ToVisibility());
        }

        private void SetFilterForUser(
            IFilterViewModel<EmployeeFilter, EmployeeDto> filterViewModel,
            AutoCompleteBox autoCompleteBox,
            string enteredText)
        {
            filterViewModel.Filter.Fullname = string.Empty;

            autoCompleteBox.ValueMemberPath = HelperExtensions.GetName<EmployeeDto>(x => x.Fullname);
            filterViewModel.Filter.Fullname = enteredText;
        }
    }
}
