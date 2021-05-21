// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InverseBoolConverter.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the InverseBoolConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class InverseBoolConverter : IValueConverter
    {
        private static InverseBoolConverter _instance;

        public static InverseBoolConverter Instance
        {
            get
            {
                return _instance ?? (_instance = new InverseBoolConverter());
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return !((bool)value);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return !((bool)value);
            }
            
            return value;
        }
    }
}
