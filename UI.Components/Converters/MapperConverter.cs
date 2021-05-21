// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapperConverter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the MapperConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using Halfblood.Common.Mappers;

    /// <summary>
    /// The mapper converter.
    /// </summary>
    public class MapperConverter : IValueConverter
    {
        private static MapperConverter _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static MapperConverter Instance
        {
            get { return _instance ?? (_instance = new MapperConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            if (parameter is Type)
            {
                return value.MapTo((Type)parameter);
            }

            return value.MapTo(targetType);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {   
                return null;
            }

            return value.MapTo(targetType);
        }
    }
}
