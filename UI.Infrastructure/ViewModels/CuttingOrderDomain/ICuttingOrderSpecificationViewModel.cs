// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICuttingOrderSpecificationViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The CuttingOrderSpecificationViewModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Filters;

namespace UI.Infrastructure.ViewModels.CuttingOrderDomain
{
    using System.Windows.Input;
    using ParusModelLite.CuttingOrderDomain;

    using ReactiveUI;

    using UI.Entities.CuttingOrderDomain;

    /// <summary>
    /// The CuttingOrderSpecificationViewModel interface.
    /// </summary>
    public interface ICuttingOrderSpecificationViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        bool IsBusy { get; }

        /// <summary>
        /// Gets or sets the selected cuttingOrder.
        /// </summary>
        CuttingOrder SelectedCuttingOrder { get; set; }
        
        /// <summary>
        /// Gets or sets the selected cutting order specification.
        /// </summary>
        CuttingOrderSpecification SelectedCuttingOrderSpecification { get; set; }

        /// <summary>
        /// Gets the preparing for edit plan receipt order command.
        /// </summary>
        ICommand PreparingForEditCuttingOrderSpecificationCommand { get; }

        /// <summary>
        /// Gets the cutting order specification filter view model.
        /// </summary>
        IFilterViewModel<CuttingOrderSpecificationFilter, CuttingOrderSpecificationLiteDto> CuttingOrderSpecificationFilterViewModel { get; }
    }
}
