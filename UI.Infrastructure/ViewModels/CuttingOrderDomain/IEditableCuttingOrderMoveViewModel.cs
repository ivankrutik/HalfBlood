// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditableCuttingOrderMoveViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IEditableCuttingOrderMoveViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.CuttingOrderDomain
{
    using ReactiveUI;

    using UI.Entities.CuttingOrderDomain;

    public interface IEditableCuttingOrderMoveViewModel : IRoutableViewModel,
                                                          IEditableViewModel<CuttingOrderMove>,
                                                          IHasAccessCatalog
    {
    }
}
