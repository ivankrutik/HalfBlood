// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPostingOfInventoryAtTheWarehouseViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The PostingOfInventoryAtTheWarehouseViewModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.PlanReceiptOrderDomain
{
    using ReactiveUI;

    /// <summary>
    /// The PostingOfInventoryAtTheWarehouseViewModel interface.
    /// </summary>
    public interface IPostingOfInventoryAtTheWarehouseViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        bool IsBusy { get; }

        /// <summary>
        /// Gets the plan certificate view model.
        /// </summary>
        IPlanCertificateViewModel PlanCertificateViewModel { get; }

        /// <summary>
        /// Gets the plan receipt order view model.
        /// </summary>
        IPlanReceiptOrderViewModel PlanReceiptOrderViewModel { get; }
    }
}
