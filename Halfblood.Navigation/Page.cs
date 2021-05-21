// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Page.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the Page type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Navigation
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Halfblood.Common.Navigations;

    /// <summary>
    /// The page.
    /// </summary>
    public class Page : IPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="url">
        /// The url.
        /// </param>
        public Page(string name, string url)
        {
            Name = name;
            Subpages = new ObservableCollection<IPage>();
            Url = url;
        }

        /// <summary>
        /// Gets or sets the subpages.
        /// </summary>
        public IList<IPage> Subpages { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets a value indicating whether is active.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Gets the url.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Page == false)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
            {
                return false;
            }

            var page = obj as Page;

            return page.Name == this.Name && page.Url == this.Url;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            int hashName = this.Name == null ? 0 : this.Name.GetHashCode();
            int hashUrl = this.Url == null ? 0 : this.Url.GetHashCode();

            //Calculate the hash code for the product.
            return hashName ^ hashUrl;
        }
    }
}