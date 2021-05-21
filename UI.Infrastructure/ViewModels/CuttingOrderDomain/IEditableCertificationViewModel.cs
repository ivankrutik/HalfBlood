// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditableCertificationViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The EditableCertificationViewModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.CuttingOrderDomain
{
    using ReactiveUI;

    using UI.Entities.CuttingOrderDomain;

    /// <summary>
    /// The EditableCertificationViewModel interface.
    /// </summary>
    public interface IEditableCertificationViewModel : IRoutableViewModel, IEditableViewModel<Certification>, IHasAccessCatalog
    {
    }
}
