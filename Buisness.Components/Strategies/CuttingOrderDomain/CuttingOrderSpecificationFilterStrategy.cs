// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderSpecificationFilterStrategy.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the CuttingOrderSpecificationFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CuttingOrderDomain
{
    using Buisness.Filters;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.SqlCommand;

    using ParusModel.Entities.CuttingOrderDomain;

    [FilterForEntity(typeof(CuttingOrderSpecification))]
    public class CuttingOrderSpecificationFilterStrategy : FilteringStrategyBase<CuttingOrderSpecification, CuttingOrderSpecificationFilter>
    {
        public override IQueryOver<CuttingOrderSpecification, CuttingOrderSpecification> Filtering(IQueryOver<CuttingOrderSpecification, CuttingOrderSpecification> query, CuttingOrderSpecificationFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.CuttingOrder != null)
            {
                query.JoinQueryOver(x => x.CuttingOrder, JoinType.LeftOuterJoin);
                if (filter.CuttingOrder.Rn != 0)
                {
                    query.Where(x => x.CuttingOrder.Rn == filter.CuttingOrder.Rn );
                }
            }

            return query;
        }
    }

}
