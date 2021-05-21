// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentOrderFilterStrategy.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DepartmentOrderFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.DepartmentOrderDomain
{
    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using ParusModel.Entities.DepartmentOrderDomain;

    [FilterForEntity(typeof(DepartmentOrder))]
    public class DepartmentOrderFilterStrategy : FilteringStrategyBase<DepartmentOrder, DepartmentOrderFilter>
    {
        public override IQueryOver<DepartmentOrder, DepartmentOrder> Filtering(IQueryOver<DepartmentOrder, DepartmentOrder> query, DepartmentOrderFilter filter)
        {
            //query.FindByRn(filter.Rn);

            //if (!string.IsNullOrWhiteSpace(filter.Pref))
            //{
            //    query.Where(x => x.Pref == filter.Pref);
            //}

     
            //query.IsBetween(x => x.StateDate, filter.StateDate);


            //if (filter.WarehouseReceiver != null)
            //{
            //    if (!string.IsNullOrWhiteSpace(filter.WarehouseReceiver.AzsNumber))
            //    {
            //        query.WhereRestrictionOn(x => x.WarehouseReceiver)
            //            .IsLike(filter.WarehouseReceiver.AzsNumber.ReplaceStar());
            //    }
            //}

            //if (filter.WarehouseSource != null)
            //{
            //    if (!string.IsNullOrWhiteSpace(filter.WarehouseSource.AzsNumber))
            //    {
            //        query.WhereRestrictionOn(x => x.WarehouseSource)
            //            .IsLike(filter.WarehouseSource.AzsNumber.ReplaceStar());
            //    }
            //}

            return query;
        }
    }
}
