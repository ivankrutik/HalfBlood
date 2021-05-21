// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleSertificationFilterStrategy.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the SampleCertificationFilterStrategy type.
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

    [FilterForEntity(typeof(SampleCertification))]
    public class SampleCertificationFilterStrategy : FilteringStrategyBase<SampleCertification, SampleCertificationFilter>
    {
        public override IQueryOver<SampleCertification, SampleCertification> Filtering(IQueryOver<SampleCertification, SampleCertification> query, SampleCertificationFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.Sample != null)
            {
                query.JoinQueryOver(x => x.Sample, JoinType.LeftOuterJoin);
                if (filter.Sample.Rn != 0)
                {
                    query.Where(x => x.Sample.Rn == filter.Sample.Rn );
                }
            }

            return query;
        }
    }

}
