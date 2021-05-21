// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcatalogFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AcatalogFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;

    using DataAccessLogic.Infrastructure;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModel.Policy;

    /// <summary>
    /// The acatalog filter strategy.
    /// </summary>
    [FilterForEntity(typeof(Catalog))]
    public class CatalogFilterStrategy : FilteringStrategyBase<Acatalog, CatalogFilter>
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
        public override IQueryOver<Acatalog, Acatalog> Filtering(IQueryOver<Acatalog, Acatalog> query, CatalogFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                return query.WhereRestrictionOn(x => x.Name).IsLike(filter.Name);
            }
           
            return query;
        }
    }
}
