using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace UI.Components.Converters
{
    public sealed class BoolToVisibilityConverter : IValueConverter
    {
        private static BoolToVisibilityConverter _instance;

        public static BoolToVisibilityConverter Instance
        {
            get { return _instance ?? (_instance = new BoolToVisibilityConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;
            return ((bool) value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}