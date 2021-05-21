// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MechanicIndicatorValueFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the MechanicIndicatorValueFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using Buisness.Filters;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.SqlCommand;

    using ParusModel.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    /// <summary>
    /// The mechanic indicator value filter strategy.
    /// </summary>
    [FilterForEntity(typeof(MechanicIndicatorValue))]
    public class MechanicIndicatorValueFilterStrategy : FilteringStrategyBase<MechanicIndicatorValue, MechanicIndicatorValueFilter>
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
        public override IQueryOver<MechanicIndicatorValue, MechanicIndicatorValue> Filtering(IQueryOver<MechanicIndicatorValue, MechanicIndicatorValue> query, MechanicIndicatorValueFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.CertificateQuality != null)
            {
                query.JoinQueryOver(x => x.CertificateQuality, JoinType.LeftOuterJoin);
            }

            if (filter.MechanicalIndicator != null)
            {
                query.JoinQueryOver(x => x.MechanicalIndicator, JoinType.LeftOuterJoin);
            }

            return query;
        }
    }
}
