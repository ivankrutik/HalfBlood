// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeValueConverter.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DateTimeValueConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class DateTimeValueConverter : IValueConverter
    {
        private static DateTimeValueConverter _instance;

        public static DateTimeValueConverter Instance
        {
            get { return _instance ?? (_instance = new DateTimeValueConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace((string)value))
            {
                return null;
            }

            return value;
        }
    }
}
