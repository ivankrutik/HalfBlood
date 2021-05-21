// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFilteringStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IFilteringStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper.Filter
{
    using Filtering.Infrastructure;

    using Halfblood.Common;

    /// <summary>
    /// The FilteringStrategy interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// type of entity
    /// </typeparam>
    public interface IFilteringStrategy<TEntity>
        where TEntity : IHasUid
    {
        /// <summary>
        /// The filtering.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="filter">
        /// filter
        /// </param>
        /// <returns>
        /// The <see cref="IQueryOver"/>.
        /// </returns>
        IQueryOver<TEntity, TEntity> Filtering(IQueryOver<TEntity, TEntity> query, IUserFilter filter);
    }
}