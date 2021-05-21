// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileSystemStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The file system strategy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Helpers.FileManagers
{
    using System.IO;

    /// <summary>
    /// The file system strategy.
    /// </summary>
    public class FileSystemStrategy : IGetFileStrategy
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemStrategy"/> class.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public FileSystemStrategy(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// The get file.
        /// </summary>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        public byte[] GetFile()
        {
            return File.ReadAllBytes(_filePath);
        }

        public void SetParams(double dpi, double brid, bool withAdvancedSettings)
        {
           
        }
    }
}
