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
    using System.Windows;
    using System.Windows.Data;

    using UI.Infrastructure;

    /// <summary>
    /// The is editable to visibility converter.
    /// </summary>
    public sealed class IsEditableToVisibilityConverter : IValueConverter
    {
        private static IsEditableToVisibilityConverter _instance;

        private IsEditableToVisibilityConverter()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static IsEditableToVisibilityConverter Instance
        {
            get { return _instance ?? (_instance = new IsEditableToVisibilityConverter()); }
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
            var editState = (EditState)value;
            return editState == (EditState)parameter ? Visibility.Visible : Visibility.Collapsed;
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
