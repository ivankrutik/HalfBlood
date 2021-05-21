// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryFactory.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IRepositoryFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Infrastructure
{
    using Halfblood.Common;

    /// <summary>
    /// The RepositoryFactory interface.
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <typeparam name="TEntity">
        /// The type of entity.
        /// </typeparam>
        /// <returns>
        /// The <see cref="INhRepository"/>.
        /// </returns>
        INhRepository<TEntity, long> Create<TEntity>()
            where TEntity : class, IHasUid<long>;
    }
}