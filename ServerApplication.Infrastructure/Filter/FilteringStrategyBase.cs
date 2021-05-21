// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilteringStrategyBase.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FilteringStrategyBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper.Filter
{
    using Filtering.Infrastructure;

    using Halfblood.Common;

    /// <summary>
    /// The filtering strategy base.
    /// </summary>
    /// <typeparam name="TEntity">
    /// type of entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    /// type of filter
    /// </typeparam>
    public abstract class FilteringStrategyBase<TEntity, TFilter> : IFilteringStrategy<TEntity>
        where TFilter : IUserFilter
        where TEntity : IHasUid
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
        public abstract IQueryOver<TEntity, TEntity> Filtering(IQueryOver<TEntity, TEntity> query, TFilter filter);

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
        IQueryOver<TEntity, TEntity> IFilteringStrategy<TEntity>.Filtering(IQueryOver<TEntity, TEntity> query, IUserFilter filter)
        {
            if (filter == null)
            {
                return query;
            }

            return this.Filtering(query, (TFilter)filter);
        }
    }
}