// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditableCuttingOrderSpecificztionViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IEditableCuttingOrderSpecificationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.CuttingOrderDomain
{
    using ReactiveUI;

    using UI.Entities.CuttingOrderDomain;

    public interface IEditableCuttingOrderSpecificationViewModel : IRoutableViewModel,
                                                                   IEditableViewModel<CuttingOrderSpecification>,
                                                                   IHasAccessCatalog
    {
    }
}
