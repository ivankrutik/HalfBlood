// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringMixin.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The string mixin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Helpers
{
    /// <summary>
    /// The string mixin.
    /// </summary>
    public static class StringMixin
    {
        /// <summary>
        /// The format.
        /// </summary>
        /// <param name="string">
        /// The string.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string StringFormat(this string @string, params object[] parameters)
        {
            return string.Format(@string, parameters);
        }

        /// <summary>
        /// The replace star.
        /// </summary>
        /// <param name="text">
        /// The text. If text is null then returning empty string.
        /// </param>
        /// <param name="chr">
        /// The char.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ReplaceStar(this string text, string chr = "%")
        {
            return string.IsNullOrWhiteSpace(text) ? string.Empty : text.Replace("*", chr);
        }
     }
}
