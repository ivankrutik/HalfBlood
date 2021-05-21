// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeDestinationFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The act selection of probe destination filter strategy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Buisness.Components.Strategies.CertificateQualityDomain.ActSelectionOfProbeDomain
{
    using Buisness.Filters;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModelLite.CertificateQualityDomain.ActSelectionOfProbeDomain;

    /// <summary>
    /// The act selection of probe destination filter strategy.
    /// </summary>
    [FilterForEntity(typeof(ActSelectionOfProbeLiteDto))]
    public class ActSelectionOfProbeLiteDtoFilterStrategy : FilteringStrategyBase<ActSelectionOfProbeLiteDto, ActSelectionOfProbeFilter>
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
        public override IQueryOver<ActSelectionOfProbeLiteDto, ActSelectionOfProbeLiteDto>
            Filtering(IQueryOver<ActSelectionOfProbeLiteDto, ActSelectionOfProbeLiteDto> query, ActSelectionOfProbeFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.CertificateQualityFilter.NomerCertificata != null)
            {
                query.Where(x => x.NumbCertificate == filter.CertificateQualityFilter.NomerCertificata);

            }

            if (filter.CertificateQualityFilter.Cast != null)
            {
                query.Where(x => x.Cast == filter.CertificateQualityFilter.Cast);
            }

            if (filter.RnDepartmentCreator > 0)
            {
                query.Where(x => x.RnDepartmentCreator == filter.RnDepartmentCreator);
            }

            if (filter.CreationDate.From != null || filter.CreationDate.To != null)
            {
                query.IsBetween(x => x.CreationDate, filter.CreationDate);
            }

            return query;
        }
    }
}
