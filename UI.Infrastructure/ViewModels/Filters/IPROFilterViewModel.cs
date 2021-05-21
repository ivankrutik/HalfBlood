// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProFilterViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IProFilterViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.Filters
{
    using Buisness.Filters;

    using ParusModelLite.PlanReceiptOrderDomain;

    using ReactiveUI;

    public interface IProFilterViewModel : IFilterViewModel<PlanReceiptOrderFilter, PlanReceiptOrderLiteDto>,
                                           IRoutableViewModel
    {
    }
}