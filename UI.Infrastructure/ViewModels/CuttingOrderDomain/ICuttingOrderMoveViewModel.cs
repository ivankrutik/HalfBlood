// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICuttingOrderMoveViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ICuttingOrderMoveViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Filters;

namespace UI.Infrastructure.ViewModels.CuttingOrderDomain
{
    using System;
    using System.Windows.Input;
    using ParusModelLite.CuttingOrderDomain;

    using ReactiveUI;

    using UI.Entities.CuttingOrderDomain;

    /// <summary>
    /// The CuttingOrderMoveViewModel interface.
    /// </summary>
    public interface ICuttingOrderMoveViewModel : IRoutableViewModel, IDisposable
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
        /// Gets or sets the selected cuttingOrderMove.
        /// </summary>
        CuttingOrderMove SelectedCuttingOrderMove { get; set; }


        /// <summary>
        /// Gets the preparing for edit plan receipt order command.
        /// </summary>
        ICommand PreparingForEditCuttingOrderMoveCommand { get; }

        /// <summary>
        /// Gets the preparing for status cutting order move command.
        /// </summary>
        ICommand PreparingForStatusCuttingOrderMoveCommand { get; }

        /// <summary>
        /// Gets the cutting order move filter view model.
        /// </summary>
        IFilterViewModel<CuttingOrderMoveFilter, CuttingOrderMoveLiteDto> CuttingOrderMoveFilterViewModel { get; }
    }
}
