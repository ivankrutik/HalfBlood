namespace UI.Infrastructure.ViewModels.WarehouseQualityCertificateDomain
{
    using ReactiveUI;

    public interface IHasFilteringObject<out TFilteringObject>
    {
        TFilteringObject FilteringObject { get; }
    }

    public interface IWarehouseQualityCertificateWithFilterViewModel :
        IRoutableViewModel
    {
        IWarehouseQualityCertificateViewModel WarehouseQualityCertificateViewModel { get; }
    }
}
