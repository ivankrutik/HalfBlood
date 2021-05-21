// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDepartmentOrderViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IDepartmentOrderViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.DepartmentOrderDomain
{
    using System.Windows.Input;

    using ParusModelLite.DepartmentOrderDomain;

    using ReactiveUI;

    using UI.Infrastructure.ViewModels.Filters;

    public interface IDepartmentOrderViewModel : IRoutableViewModel, IBarcodeSubscriber
    {
        bool IsBusy { get; }
        DepartmentOrderLiteDto SelectedDepartmentOrder { get; set; }
        ICommand PreparingForEditDepartmentOrderCommand { get; }
        ICommand PreparingForStatusDepartmentOrderCommand { get; }
        ICommand PreparingForAddDepartmentOrderCommand { get; }
        ICommand PreparingForRemoveDepartmentOrderCommand { get; }
        IDepartmentOrderFilterViewModel DepartmentOrderFilteringObject { get; }
    }
}