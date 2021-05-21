// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IManufacturersCertificateViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IManufacturersCertificateViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.CertificateQualityServiceDomain.ManufacturersCertificateDomain
{
    using System.Windows.Input;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    using ReactiveUI;

    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.WarehouseQualityCertificateDomain;

    public interface IManufacturersCertificateViewModel : IRoutableViewModel
    {
        bool IsBusy { get; }
        ICommand NavigateToDealCommand { get; }
        ICommand ShowScanCertificateCommand { get; }
        ICommand TakeMaterialCommand { get; }
        ICommand SetStateCommand { get; }
        ICommand CreatePermissionMaterialCommand { get; }
        ICommand CreateActSelectionProbeCommand { get; }
        ICertificateQualityRestFilterViewModel CertificateQualityRestFilterViewModel { get; }
        CertificateQualityRestLiteDto SelectedCertificateQuality { get; set; }
        IWarehouseQualityCertificateViewModel WarehouseQualityCertificateViewModel { get; }
    }
}