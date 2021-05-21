// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanCertificateFilterStrategy.cs" company="VZ">
//   maratoss && offan
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
    using NHibernate.SqlCommand;

    using ParusModel.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The plan certificate filter strategy.
    /// </summary>
    [FilterForEntity(typeof(PlanCertificate))]
    public class PlanCertificateFilterStrategy : FilteringStrategyBase<PlanCertificate, PlanCertificateFilter>
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
        public override IQueryOver<PlanCertificate, PlanCertificate> Filtering(
            IQueryOver<PlanCertificate, PlanCertificate> query, PlanCertificateFilter filter)
        {
            if (filter != null)
            {
                query.FindByRn(filter.Rn);

                if (filter.RnPlanReceiptOrder != 0)
                {
                    query.JoinQueryOver(x => x.PlanReceiptOrder, JoinType.LeftOuterJoin)
                        .Where(x => x.Rn == filter.RnPlanReceiptOrder);
                }
            }

            return query;
        }
    }
}
