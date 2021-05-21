// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPage.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Navigations
{
    using System.Collections.Generic;

    /// <summary>
    /// The Page interface.
    /// </summary>
    public interface IPage
    {
        /// <summary>
        /// Gets the subpages.
        /// </summary>
        IList<IPage> Subpages { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        /// Gets the url.
        /// </summary>
        string Url { get; }
    }
}