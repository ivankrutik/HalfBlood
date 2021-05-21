namespace UI.Infrastructure.ViewModels.Filters
{
    using Buisness.Entities.PermissionMaterialDomain;
    using Buisness.Filters;
    using ReactiveUI;

    public interface IPermissionMaterialExtensionsFilterViewModel : IFilterViewModel<PermissionMaterialExtensionFilter, PermissionMaterialExtensionDto>, IReactiveNotifyPropertyChanged
    {
    }
}