// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderPersonalAccountFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderPersonalAccountFilterStrategy type.
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
    /// The plan receipt order personal account filter strategy.
    /// </summary>
    [FilterForEntity(typeof(PlanReceiptOrderPersonalAccount))]
    public class PlanReceiptOrderPersonalAccountFilterStrategy : FilteringStrategyBase<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountFilter>
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
        public override IQueryOver<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccount> 
            Filtering(IQueryOver<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccount> query, PlanReceiptOrderPersonalAccountFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.PlanCertificate != null)
            {
                if (filter.PlanCertificate.Rn > 0)
                {
                    query.JoinQueryOver(x => x.PlaneCertificate, JoinType.LeftOuterJoin)
                        .Where(x => x.Rn == filter.PlanCertificate.Rn);
                }
            }

            return query;
        }
    }
}
