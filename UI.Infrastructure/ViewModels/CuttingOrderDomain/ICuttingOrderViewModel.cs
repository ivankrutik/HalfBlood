// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICuttingOrderViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ICuttingOrderViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Filters;

namespace UI.Infrastructure.ViewModels.CuttingOrderDomain
{
    using System.Windows.Input;

    using Buisness.Entities.CuttingOrderDomain;
    using ReactiveUI;

    using UI.Entities.CuttingOrderDomain;

    /// <summary>
    /// The CuttingOrderViewModel interface.
    /// </summary>
    public interface ICuttingOrderViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        bool IsBusy { get; }

        /// <summary>
        /// Gets or sets the selected plan receipt order.
        /// </summary>
        CuttingOrder SelectedCuttingOrder { get; set; }

        /// <summary>
        /// Gets the preparing for edit plan receipt order command.
        /// </summary>
        ICommand PreparingForDetailedCuttingOrderCommand { get; }

        /// <summary>
        /// Gets the preparing for status cutting order command.
        /// </summary>
        ICommand PreparingForStatusCuttingOrderCommand { get; }

        /// <summary>
        /// Gets the cutting order filter view model.
        /// </summary>
        IFilterViewModel<CuttingOrderFilter, CuttingOrderDto> CuttingOrderFilterViewModel { get; }
    }
}
