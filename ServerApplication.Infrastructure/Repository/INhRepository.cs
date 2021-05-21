// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INhRepository.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the INhRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper.Repository
{
    using System.Collections.Generic;

    using Halfblood.Common;

    using NHibernate;

    /// <summary>
    /// The NhRepository interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The type of entity
    /// </typeparam>
    public interface INhRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IHasUid
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        TEntity Get(object id);

        /// <summary>
        /// The load.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        TEntity Load(object id);

        /// <summary>
        /// The specify.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryOver"/>.
        /// </returns>
        IQueryOver<TEntity, TEntity> Specify();

        IList<TRet> ExecuteSPResultList<TRet>(IStoredProcedure sp);

        TRet ExecuteSPUniqueResult<TRet>(IStoredProcedure sp);

        void Evict(TEntity entity);

    }
}