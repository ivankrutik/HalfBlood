// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFilterStrategyFactory.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IFilterStrategyFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper.Filter
{
    using Halfblood.Common;

    /// <summary>
    /// The FilterStrategyFactory interface.
    /// </summary>
    public interface IFilterStrategyFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <typeparam name="TEntity">
        /// The type of entity.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFilteringStrategy"/>.
        /// </returns>
        IFilteringStrategy<TEntity> Create<TEntity>() where TEntity : IHasUid;
    }
}