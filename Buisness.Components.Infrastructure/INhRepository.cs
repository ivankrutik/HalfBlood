// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INhRepository.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the INhRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DataAccessLogic.Infrastructure;

namespace Buisness.Components.Infrastructure
{
    using System.Collections;

    using Halfblood.Common;

    using NHibernate;
    using ParusModel;
    using ParusModel.StoredProcedure;

    /// <summary>
    /// The NhRepository interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The type of entity
    /// </typeparam>
    /// <typeparam name="TKey">
    /// The type of key
    /// </typeparam>
    public interface INhRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : IHasUid<TKey>
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
        TEntity Get(TKey id);

        /// <summary>
        /// The load.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        TEntity Load(TKey id);

        /// <summary>
        /// The specify.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryOver"/>.
        /// </returns>
        IQueryOver<TEntity, TEntity> Specify();

        /// <summary>
        /// The execute stored procedure.
        /// </summary>
        /// <param name="sp">
        /// The stored procedure.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList ExecuteStoredProcedure(IStoredProcedure sp);

        /// <summary>
        /// The execute stored procedure.
        /// </summary>
        /// <param name="sp">
        /// The stored procedure.
        /// </param>
        /// <typeparam name="TRet">
        /// The return type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="TRet"/>.
        /// </returns>
        TRet ExecuteStoredProcedure<TRet>(IStoredProcedure sp);

        /// <summary>
        /// The get current user.
        /// </summary>
        /// <returns>
        /// The <see cref="Agnlist"/>.
        /// </returns>
        Agnlist GetCurrentUser();
    }
}