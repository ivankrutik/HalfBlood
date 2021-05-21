// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocumentFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AttachedDocumentFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModel.Entities.AttachedDocumentDomain;

    /// <summary>
    /// The attached document link section of system filter strategy.
    /// </summary>
    [FilterForEntity(typeof(AttachedDocumentType))]
    public class AttachedDocumentTypeFilterStrategy
        : FilteringStrategyBase<AttachedDocumentType, AttachedDocumentTypeFilter>
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
        public override IQueryOver<AttachedDocumentType, AttachedDocumentType>
            Filtering(
                IQueryOver<AttachedDocumentType, AttachedDocumentType> query,
                AttachedDocumentTypeFilter filter)
        {
            query.FindByRn(filter.Rn);

            query = query.OrderBy(x => x.Code).Asc;

            return query;
        }
    }
}
