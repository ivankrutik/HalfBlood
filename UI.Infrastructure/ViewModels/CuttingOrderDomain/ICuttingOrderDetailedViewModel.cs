// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICuttingOrderDetailedViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ICuttingOrderDetailedViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.CuttingOrderDomain
{
    using ReactiveUI;
    using UI.Entities.CuttingOrderDomain;

    /// <summary>
    /// The CuttingOrderDetailedViewModel interface.
    /// </summary>
    public interface ICuttingOrderDetailedViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        bool IsBusy { get; }

        /// <summary>
        /// Gets the cutting order.
        /// </summary>
        CuttingOrder CuttingOrder { get; }

        /// <summary>
        /// The set cutting order.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void SetCuttingOrder(CuttingOrder entity);
    }
}
