// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHasUid.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The has UID interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common
{
    /// <summary>
    /// The has id interface.
    /// </summary>
    public interface IHasUid
    {
        /// <summary>
        /// Gets the RN.
        /// </summary>
        object Rn { get; }
    }

    /// <summary>
    /// The has UID interface.
    /// </summary>
    /// <typeparam name="TKey">
    /// The type of key.
    /// </typeparam>
    public interface IHasUid<out TKey> : IHasUid
    {
        /// <summary>
        /// Gets the RN.
        /// </summary>
        new TKey Rn { get; }
    }
}
