// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwitcherPage.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the SwitcherPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Navigation
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.Composition;
    using System.Linq;

    using Halfblood.Common.Navigations;

    /// <summary>
    /// The switcher page.
    /// </summary>
    [Export(typeof(ISwitcherPage))]
    public class SwitcherPage : ISwitcherPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitcherPage"/> class.
        /// </summary>
        public SwitcherPage()
        {
            Pages = new ObservableCollection<IPage>();
        }

        /// <summary>
        /// Gets the pages.
        /// </summary>
        public IList<IPage> Pages { get; private set; }

        /// <summary>
        /// Gets the active page.
        /// </summary>
        public IPage ActivePage { get; private set; }

        /// <summary>
        /// The add page.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        public void AddPage(IPage page)
        {
            Pages.Add(page);
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        public void Switch(IPage page)
        {
            ActivePage = Pages.First(x => x.Equals(page));
        }
    }
}