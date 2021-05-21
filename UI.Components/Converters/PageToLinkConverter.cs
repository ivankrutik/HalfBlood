// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageToLinkConverter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PageToLinkConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;
    using FirstFloor.ModernUI.Presentation;
    using Halfblood.Common.Navigations;

    /// <summary>
    /// The page to link converter.
    /// </summary>
    public class PageToLinkConverter : IValueConverter
    {
        private static PageToLinkConverter _instance;

        /// <summary>
        /// Gets the i.
        /// </summary>
        public static PageToLinkConverter I
        {
            get { return _instance ?? (_instance = new PageToLinkConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pages = value as IList<IPage>;
            var result = pages.Select(Convert);

            return new ObservableCollection<LinkGroup>(result);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private LinkGroup Convert(IPage page)
        {
            var linkGroup = new LinkGroup { DisplayName = page.Name };
            foreach (IPage subpage in page.Subpages)
            {
                linkGroup.Links.Add(new Link { DisplayName = subpage.Name });
            }

            return linkGroup;
        }
    }
}
