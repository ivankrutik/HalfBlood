using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace UI.Components.Converters
{
    public sealed class IsEmptyToVisibilityConverter : IValueConverter
    {
        private static IsEmptyToVisibilityConverter _instance;

        public static IsEmptyToVisibilityConverter Instance
        {
            get { return _instance ?? (_instance = new IsEmptyToVisibilityConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;
            return string.IsNullOrEmpty(value.ToString()) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}