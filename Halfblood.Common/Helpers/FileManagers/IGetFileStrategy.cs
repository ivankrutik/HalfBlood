// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGetFileStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The GetFileStrategy interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Helpers.FileManagers
{
    /// <summary>
    /// The GetFileStrategy interface.
    /// </summary>
    public interface IGetFileStrategy
    {
        /// <summary>
        /// The get file.
        /// </summary>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        byte[] GetFile();

        void SetParams(double dpi, double brid, bool withAdvancedSettings);
    }
}
