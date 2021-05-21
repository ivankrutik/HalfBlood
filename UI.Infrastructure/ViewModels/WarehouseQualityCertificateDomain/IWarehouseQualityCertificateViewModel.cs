using UI.Infrastructure.ViewModels.Filters;
namespace UI.Infrastructure.ViewModels.WarehouseQualityCertificateDomain
{
    using System.Windows.Input;
    using ParusModelLite.CertificateQualityDomain.WarehouseQualityCertificateDomain;

    using ReactiveUI;

    public interface IWarehouseQualityCertificateViewModel : IRoutableViewModel
    {
        bool IsBusy { get; }
        WarehouseQualityCertificateRestLiteDto SelectedWarehouseQualityCertificate { get; set; }
        ICommand PrintCommand { get; }
        ICommand NavigateToScanCommand { get; }
        ICommand RemoveCommand { get; }
        IWarehouseQualityCertificateFilterViewModel WarehouseQualityCertificateFilterViewModel { get; }
    }
}
