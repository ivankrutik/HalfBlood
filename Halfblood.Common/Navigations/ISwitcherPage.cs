// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISwitcherPage.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The SwitcherPage interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Navigations
{
    using System.Collections.Generic;

    /// <summary>
    /// The SwitcherPage interface.
    /// </summary>
    public interface ISwitcherPage
    {
        /// <summary>
        /// Gets the pages.
        /// </summary>
        IList<IPage> Pages { get; }

        /// <summary>
        /// Gets the active page.
        /// </summary>
        IPage ActivePage { get; }

        /// <summary>
        /// The add page.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        void AddPage(IPage page);

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        void Switch(IPage page);
    }
}