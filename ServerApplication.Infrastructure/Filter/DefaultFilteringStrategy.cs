// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultFilteringStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the DefaultFilteringStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper.Filter
{
    using Filtering.Infrastructure;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;
    using Halfblood.Common.Log;

    using NHibernate.Helper.Filter.Specification;

    /// <summary>
    /// The default filtering strategy.
    /// </summary>
    /// <typeparam name="TEntity">
    /// type of entity
    /// </typeparam>
    public class DefaultFilteringStrategy<TEntity> : IFilteringStrategy<TEntity>
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
        public IQueryOver<TEntity, TEntity> Filtering(IQueryOver<TEntity, TEntity> query, IUserFilter filter)
        {
            LogManager.Log.Debug("Default filter for entity {0}".StringFormat(typeof(TEntity)));

            if (filter != null)
            {
                return query.FindByRn(filter.Rn);
            }

            return query;
        }
    }
}