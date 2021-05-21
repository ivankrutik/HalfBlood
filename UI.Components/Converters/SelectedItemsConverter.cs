namespace UI.Components.Converters
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Globalization;
    using System.Windows.Data;

    public class SelectedItemsConverter<T> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var collection = value as IList;
            return collection == null ? Enumerable.Empty<T>() : collection.Cast<T>();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
