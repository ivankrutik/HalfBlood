// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsEditableToVisibilityConverter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IsEditableToVisibilityConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Converters
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;

    using Halfblood.Common;

    /// <summary>
    /// The is editable to visibility converter.
    /// </summary>
    public sealed class NameOfSectionSystemConverter : IValueConverter
    {
        private static NameOfSectionSystemConverter _instance;

        private NameOfSectionSystemConverter()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static NameOfSectionSystemConverter Instance
        {
            get { return _instance ?? (_instance = new NameOfSectionSystemConverter()); }
        }

        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var elem in NamesOfSectionSystem.Names.Where(elem => elem.Key == (string)value))
            {
                return elem.Value;
            }

            return value;
        }

        /// <summary>
        /// The convert back.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
