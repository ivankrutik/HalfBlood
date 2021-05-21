namespace UI.Infrastructure.ViewModels.PermissionMaterialDomain
{
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;
    using ReactiveUI;
    using System.Windows.Input;
    using UI.Entities.PermissionMaterialDomain;

    public interface IEditablePermissionMaterialViewModel : IRoutableViewModel, IEditableViewModel<PermissionMaterial>, IHasAccessCatalog
    {
        long RnCertificateQuality { get; set; }

        EmployeeDto SelectedEmployee { get; }
        PermissionMaterialUser SelectedDgPermisMatUser { get; }

        ICommand PreparingForAddingPermissionMaterialCommand { get; }
        ICommand PreparingForRemovingPermisMatUserCommand { get; }
        
        IFilterViewModel<EmployeeFilter, EmployeeDto> EmployeeFilterViewModel { get; }
    }
}