// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlanReceiptOrderPersonalAccountFilterViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IPlanReceiptOrderPersonalAccountFilterViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.Filters
{
    using Buisness.Filters;

    using ParusModelLite.PlanReceiptOrderDomain;

    /// <summary>
    /// The PlanReceiptOrderPersonalAccountFilterViewModel interface.
    /// </summary>
    public interface IPlanReceiptOrderPersonalAccountFilterViewModel
        : IFilterViewModel<PlanReceiptOrderPersonalAccountFilter, PersonalAccountOfPlanReceiptOrderLiteDto>
    {
    }
}
