// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHasBinary.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The HasBinary interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities
{
    /// <summary>
    /// The HasBinary interface.
    /// </summary>
    public interface IHasBinary
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        byte[] Content { get; set; }
    }
}
