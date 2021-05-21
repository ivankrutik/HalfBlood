namespace UI.Infrastructure
{
    using System;
    using System.Windows.Input;

    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using Halfblood.Common;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    using ReactiveUI;

    using UI.Infrastructure.ViewModels;

    public interface IDummyViewModel : IRoutableViewModel, IAwaitable
    {
        bool IsBusy { get; }
        IFilterViewModel<StoreGasStationOilDepotFilter, StoreGasStationOilDepotDto> StoreSearcher { get; }
        StoreGasStationOilDepotDto InStoreGasStationOilDepot { get; set; }
        decimal Quantity { get; set; }
        ICommand DealCommand { get; }
        string NumberOfBook { get; set; }
        DateTime? DateOfBook { get; set; }
        CertificateQualityRestLiteDto CertificateQuality { get; set; }
        IFilterViewModel<EmployeeFilter, EmployeeDto> EmployeeOTKFilterViewModel { get; }
        IFilterViewModel<EmployeeFilter, EmployeeDto> EmployeeStoreFilterViewModel { get; }
        EmployeeDto SelectedEmployeeOtk { get; set; }
        EmployeeDto SelectedEmployeeStore { get; set; }
    }
}
