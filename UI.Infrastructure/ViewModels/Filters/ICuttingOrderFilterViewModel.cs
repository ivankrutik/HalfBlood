// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICuttingOrderFilterViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ICuttingOrderFilterViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Filters;

namespace UI.Infrastructure.ViewModels.Filters
{
    using Entities.CuttingOrderDomain;
    using ReactiveUI;

    public interface ICuttingOrderFilterViewModel : IFilterViewModel<CuttingOrderFilter, CuttingOrder>, IReactiveNotifyPropertyChanged
    {
    }
}
