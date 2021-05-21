namespace UI.Infrastructure.ViewModels.Filters
{
    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.NomenclatorDomain;
    using Buisness.Filters;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    using ReactiveUI;

    public interface ICertificateQualityRestFilterViewModel :
        IFilterViewModel<CertificateQualityFilter, CertificateQualityRestLiteDto>,
        IRoutableViewModel
    {
        IFilterViewModel<CertificateQualityFilter, CertificateQualityDto> GostCast { get; }
        IFilterViewModel<CertificateQualityFilter, CertificateQualityDto> GostMix { get; }
        IFilterViewModel<CertificateQualityFilter, CertificateQualityDto> Marka { get; }
        IFilterViewModel<CertificateQualityFilter, CertificateQualityDto> Mix { get; }
        IFilterViewModel<NomenclatureNumberFilter, NomenclatureNumberDto> NomenclatureNumberFilterViewModel { get;  }
    }
}