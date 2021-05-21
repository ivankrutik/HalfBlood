// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConvertHelper.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ConvertHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Helpers
{
    using System.Windows;

    /// <summary>
    /// The convert helper.
    /// </summary>
    public static class ConvertHelper
    {
        /// <summary>
        /// The to visibility.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="Visibility"/>.
        /// </returns>
        public static Visibility ToVisibility(this bool value)
        {
            return value ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
