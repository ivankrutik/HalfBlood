// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper.Repository
{
    using System;
    using System.Linq.Expressions;

    using Halfblood.Common;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    /// <typeparam name="TKey">
    /// </typeparam>
    public interface IRepository<TEntity> : IRepository
        where TEntity : IHasUid
    {
        object Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> predicate);
    }

    /// <summary>
    /// The Repository interface.
    /// </summary>
    public interface IRepository
    {
    }
}