namespace UI.Infrastructure.ViewModels.Filters
{
    using Buisness.Filters;
    using ParusModelLite.CertificateQualityDomain.WarehouseQualityCertificateDomain;
    using ReactiveUI;

    public interface IWarehouseQualityCertificateFilterViewModel :
        IFilterViewModel<WarehouseQualityCertificateRestFilter, WarehouseQualityCertificateRestLiteDto>, IRoutableViewModel
    {
    }
}
