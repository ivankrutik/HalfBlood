namespace UI.Infrastructure.ViewModels.Filters
{
    using Buisness.Filters;
    using ParusModelLite.CertificateQualityDomain.PermissionMaterialDomain;

    public interface IPermissionMaterialFilterViewModel :
        IFilterViewModel<PermissionMaterialFilter, PermissionMaterialLiteDto>
    {
    }
}