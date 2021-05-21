namespace UI.Infrastructure.ViewModels.PermissionMaterialDomain
{
    using Buisness.Entities.PermissionMaterialDomain;
    using Buisness.Filters;
    using ParusModelLite.CertificateQualityDomain.PermissionMaterialDomain;
    using ReactiveUI;
    using System.Windows.Input;
    using UI.Infrastructure.ViewModels.Filters;

    public interface IPermissionMaterialViewModel : IRoutableViewModel
    {
        PermissionMaterialLiteDto SelectedPermissionMaterial { get; }
        PermissionMaterialExtensionDto SelectedPermissionMaterialEx { get; }

        ICommand PreparingForEditPermissionMaterialCommand { get; }
        ICommand PreparingForStatusPermissionMaterialCommand { get; }
        ICommand PreparingForRemovingPermissionMaterialCommand { get; }

        ICommand PreparingForAddingPermissionMaterialExCommand { get; }
        ICommand PreparingForEditPermissionMaterialExCommand { get; }
        ICommand PreparingForRemovingPermissionMaterialExCommand { get; }

        IPermissionMaterialFilterViewModel PermissionMaterialFilterViewModel { get; }
        IFilterViewModel<PermissionMaterialUserFilter, PermissionMaterialUserDto> PermissionMaterialUserFilterViewModel { get; }
        IFilterViewModel<PermissionMaterialExtensionFilter, PermissionMaterialExtensionDto> PermissionMaterialExtensionFilterViewModel { get; }
    }
}