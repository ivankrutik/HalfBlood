namespace UI.ProcessComponents.FilterViewModels.CertificateQualityDomain.PermissionMaterialDomain
{
    using Buisness.Filters;
    using ParusModelLite.CertificateQualityDomain.PermissionMaterialDomain;
    using ServiceContracts;
    using System.ComponentModel.Composition;
    using UI.Infrastructure.ViewModels.Filters;

    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IPermissionMaterialFilterViewModel))]
    public class PermissionMaterialFilterViewModel : GenericFilterViewModel<PermissionMaterialFilter, PermissionMaterialLiteDto>, IPermissionMaterialFilterViewModel
    {
        [ImportingConstructor]
        public PermissionMaterialFilterViewModel(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
            Filter = PermissionMaterialFilter.Default;
        }
    }
}