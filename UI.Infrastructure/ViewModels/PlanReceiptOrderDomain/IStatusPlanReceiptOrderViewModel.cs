// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStatusPlanReceiptOrderViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The StatusPlanReceiptOrderViewModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.PlanReceiptOrderDomain
{
    using System.Collections.Generic;

    using Halfblood.Common;

    using JetBrains.Annotations;

    using ReactiveUI;

    using UI.Entities.PlanReceiptOrderDomain;

    public interface IStatusPlanReceiptOrderViewModel : IRoutableViewModel,
                                                        IChangeStateViewModel<PlanReceiptOrder, PlanReceiptOrderState>
    {
        void SetActionObjectCollection([NotNull] IList<PlanReceiptOrder> objects);
    }
}