using System.Collections.Generic;
using Buisness.Entities.PlanReceiptOrderDomain;
using ParusModel.WorkOrderDomain;

namespace Buisness.Components.Infrastructure
{
    public interface IPlanReceiptOrderRepository
    {
        IEnumerable<PlanReceiptOrderDto> GetPlanReceiptOrderFilter(
            PlanReceiptOrderDto filter,
            int skip,
            int take,
            out int total);
    }
}
