namespace UI.Infrastructure.ViewModels.Common
{
    using System.Windows.Input;

    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using ParusModelLite;

    using ReactiveUI;

    using UI.Infrastructure.ViewModels.WarehouseQualityCertificateDomain;

    public interface IPrintTheDemandViewModel : IRoutableViewModel
    {
        ICommand PrintCommand { get; }
        EmployeeDto SelectedEmployeeOtk { get; set; }
        EmployeeDto SelectedEmployeeReceiver { get; set; }
        EmployeeDto SelectedEmployeeGiver { get; set; }
        DeficiencyLiteDto SelectedDeficiency { get; set; }
        long CountDSE { get; set; }
        IFilterViewModel<DeficiencyFilter, DeficiencyLiteDto> DeficiencySearcher { get; }
        IFilterViewModel<EmployeeFilter, EmployeeDto> EmployeeOtkFilterViewModel { get; }
        IFilterViewModel<EmployeeFilter, EmployeeDto> EmployeeReceiverFilterViewModel { get; }
        IFilterViewModel<EmployeeFilter, EmployeeDto> EmployeeGiverFilterViewModel { get; }
        IWarehouseQualityCertificateWithFilterViewModel WarehouseQualityCertificateViewModel { get; }
    }
}
