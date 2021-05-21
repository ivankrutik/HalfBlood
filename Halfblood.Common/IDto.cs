// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common
{
    /// <summary>
    /// The DTO interface.
    /// </summary>
    public interface IDto : IHasUid
    {
        //new object Rn { get; set; }
    }

    /// <summary>
    /// The DTO interface.
    /// </summary>
    /// <typeparam name="TKey">
    /// The type of key.
    /// </typeparam>
    public interface IDto<TKey> : IHasUid<long>, IDto
    {
        /// <summary>
        /// Gets or sets the RN.
        /// </summary>
        new TKey Rn { get; set; }
    }
}