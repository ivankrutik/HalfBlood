using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace UI.Components.Converters
{
    public sealed class IsEmptyCollectionToVisibilityConverter : IValueConverter
    {
        private static IsEmptyCollectionToVisibilityConverter _instance;

        public static IsEmptyCollectionToVisibilityConverter Instance
        {
            get { return _instance ?? (_instance = new IsEmptyCollectionToVisibilityConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;
            return ((ICollection) value).Count == 0 ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}