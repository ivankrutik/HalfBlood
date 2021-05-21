// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRegisterAttribute.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The RegisterAttribute interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common
{
    using System;

    /// <summary>
    /// The RegisterAttribute interface.
    /// </summary>
    public interface IRegisterAttribute
    {
        /// <summary>
        /// Gets the register as type.
        /// </summary>
        Type RegisterAsType { get; }
    }
}