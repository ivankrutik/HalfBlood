namespace UI.Infrastructure.ViewModels.PermissionMaterialDomain
{
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;
    using ReactiveUI;
    using System.Windows.Input;
    using UI.Entities.PermissionMaterialDomain;

    public interface IEditablePermissionMaterialExtensionViewModel : IRoutableViewModel, IEditableViewModel<PermissionMaterialExtension>
    {
        EmployeeDto SelectedEmployee { get; }
        PermissionMaterialExtensionUser SelectedDgPermisMatUser { get; }

        ICommand PreparingForAddingPermissionMaterialCommand { get; }
        ICommand PreparingForRemovingPermisMatUserCommand { get; }

        IFilterViewModel<EmployeeFilter, EmployeeDto> EmployeeFilterViewModel { get; }
    }
}