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
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Common;

    [Export(typeof(IViewFor<IPrintTheDemandViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class PrintTheDemandView : UserControl, IViewFor<IPrintTheDemandViewModel>
    {
        private readonly DisposableContext disposableContext;

        public PrintTheDemandView()
        {
            disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        public IPrintTheDemandViewModel ViewModel
        {
            get { return DataContext as IPrintTheDemandViewModel; }
            set
            {
                DataContext = value;
                disposableContext.Add(Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IPrintTheDemandViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return
                this.OneWayBind(ViewModel, vm => vm.WarehouseQualityCertificateViewModel, v => v.ViewHost.ViewModel);

            yield return this.BindCommand(ViewModel, vm => vm.PrintCommand, v => v.PrintButton);

            yield return
                DeficiencyAcb.Binding(
                    ViewModel.DeficiencySearcher,
                    (model, s) => model.Filter.DSE = s,
                    isBusy => DeficiencyProgressBar.Visibility = isBusy.ToVisibility());

            yield return
                this.AcbDepartmentOtk.Binding(
                    ViewModel.EmployeeOtkFilterViewModel,
                    SetAcbUserFilter,
                    isBusy => BusyUserOtk.Visibility = isBusy.ToVisibility());

            yield return
                AcbReceiver.Binding(
                    ViewModel.EmployeeReceiverFilterViewModel,
                    SetAcbUserFilter,
                    isBusy => BusyUserReciver.Visibility = isBusy.ToVisibility());

            yield return
                AcbGiver.Binding(
                    ViewModel.EmployeeGiverFilterViewModel,
                    SetAcbUserFilter,
                    isBusy => BusyUserGiver.Visibility = isBusy.ToVisibility());

            yield return this.Bind(ViewModel, vm => vm.SelectedDeficiency, v => v.DeficiencyAcb.SelectedItem);
        }

        private void SetAcbUserFilter(
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
