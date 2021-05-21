// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Infrastructure
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
    public interface IRepository<TEntity, TKey>
        where TEntity : IHasUid<TKey>
    {
        TKey Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey id);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> predicate);
    } 
}