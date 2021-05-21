// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlanReceiptOrderViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IPlanReceiptOrderViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.PlanReceiptOrderDomain
{
    using System.Windows.Input;

    using ParusModelLite.PlanReceiptOrderDomain;
    using ReactiveUI;

    using UI.Infrastructure.ViewModels.Filters;

    /// <summary>
    /// The PlanReceiptOrderViewModel interface.
    /// </summary>
    public interface IPlanReceiptOrderViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        bool IsBusy { get; }

        /// <summary>
        /// Gets the plan receipt order filter view model.
        /// </summary>
        IProFilterViewModel PlanReceiptOrderFilterViewModel { get; }
        
        /// <summary>
        /// Gets or sets the selected plan receipt order.
        /// </summary>
        PlanReceiptOrderLiteDto SelectedPlanReceiptOrder { get; set; }

        /// <summary>
        /// Gets the preparing change group state command.
        /// </summary>
        ICommand PreparingChangeGroupStateCommand { get; }

        /// <summary>
        /// Gets the preparing for edit plan receipt order command.
        /// </summary>
        ICommand PreparingForEditPlanReceiptOrderCommand { get; }

        /// <summary>
        /// Gets the preparing for status plan receipt order command.
        /// </summary>
        ICommand PreparingForStatusPlanReceiptOrderCommand { get; }

        /// <summary>
        /// Gets the preparing for add plan receipt order command.
        /// </summary>
        ICommand PreparingForAddPlanReceiptOrderCommand { get; }

        /// <summary>
        /// Gets the preparing for add plan receipt order command.
        /// </summary>
        ICommand PreparingForRemovePlanReceiptOrderCommand { get; }
    }
}
