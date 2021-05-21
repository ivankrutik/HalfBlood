// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanCertificateLiteDtoFilterStrategy.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The plan certificate filter strategy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using Buisness.Filters;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModelLite.PlanReceiptOrderDomain;

    /// <summary>
    /// The plan certificate filter strategy.
    /// </summary>
    [FilterForEntity(typeof(PlanCertificateLiteDto))]
    public class PlanCertificateLiteDtoFilterStrategy : FilteringStrategyBase<PlanCertificateLiteDto, PlanCertificateFilter>
    {
        /// <summary>
        /// The filtering.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryOver"/>.
        /// </returns>
        public override IQueryOver<PlanCertificateLiteDto, PlanCertificateLiteDto> 
            Filtering(IQueryOver<PlanCertificateLiteDto, PlanCertificateLiteDto> query, PlanCertificateFilter filter)
        {
            if (filter != null)
            {
                query.FindByRn(filter.Rn);

                if (filter.RnPlanReceiptOrder > 0)
                {
                    query.Where(x => x.Prn == filter.RnPlanReceiptOrder);
                }
            }

            return query;
        }
    }
}
