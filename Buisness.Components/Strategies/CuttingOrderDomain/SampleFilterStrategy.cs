// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleFilterStrategy.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the SampleFilterStrategy type.
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

    [FilterForEntity(typeof(Sample))]
    public class SampleFilterStrategy : FilteringStrategyBase<Sample, SampleFilter>
    {
        public override IQueryOver<Sample, Sample> Filtering(IQueryOver<Sample, Sample> query, SampleFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.CuttingOrderSpecification != null)
            {
                query.JoinQueryOver(x => x.CuttingOrderSpecification, JoinType.LeftOuterJoin);
                if (filter.CuttingOrderSpecification.Rn != 0)
                {
                    query.Where(x => x.CuttingOrderSpecification.Rn == filter.CuttingOrderSpecification.Rn );
                }
            }

            return query;
        }
    }

}
