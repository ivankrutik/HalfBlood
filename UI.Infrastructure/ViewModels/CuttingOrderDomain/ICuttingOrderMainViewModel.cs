// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICuttingOrderMainViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ICuttingOrderMainViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.CuttingOrderDomain
{
    using ReactiveUI;

    /// <summary>
    /// The CuttingOrderMainViewModel interface.
    /// </summary>
    public interface ICuttingOrderMainViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets the cutting order view model.
        /// </summary>
        ICuttingOrderViewModel CuttingOrderViewModel { get; }
    }
}
