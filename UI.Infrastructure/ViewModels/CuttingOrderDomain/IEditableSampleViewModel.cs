// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditableSampleViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IEditableSampleViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.CuttingOrderDomain
{
    using ReactiveUI;

    using UI.Entities.CuttingOrderDomain;

    public interface IEditableSampleViewModel : IRoutableViewModel, IEditableViewModel<Sample>, IHasAccessCatalog
    {
    }
}
