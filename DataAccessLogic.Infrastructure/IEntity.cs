// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntity.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The Entity interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessLogic.Infrastructure
{
    using Halfblood.Common;

    /// <summary>
    /// The Entity interface.
    /// </summary>
    /// <typeparam name="TKey">
    /// The type of the key of entity
    /// </typeparam>
    public interface IEntity<out TKey> : IEntity, IHasUid<TKey>
    {
    }

    /// <summary>
    /// The Entity interface.
    /// </summary>
    public interface IEntity : IHasCatalog
    {
        /// <summary>
        /// Gets the name section of system.
        /// </summary>
        string NameSectionOfSystem { get; }
    }
}