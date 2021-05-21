// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICopyStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The CopyStrategy interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Navigations
{
    using System;

    /// <summary>
    /// The CopyStrategy interface.
    /// </summary>
    public interface ICopyStrategy
    {
        /// <summary>
        /// The make copy.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object MakeCopy(Type type);
    }
}