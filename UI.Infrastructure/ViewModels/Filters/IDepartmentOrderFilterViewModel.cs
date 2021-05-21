namespace UI.Infrastructure.ViewModels.Filters
{
    using Buisness.Filters;

    using ParusModelLite.DepartmentOrderDomain;

    using ReactiveUI;

    public interface IDepartmentOrderFilterViewModel : IFilterViewModel<DepartmentOrderFilter, DepartmentOrderLiteDto>,
                                                       IRoutableViewModel
    {
    }
}