// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IImageManager.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The ImageManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Helpers
{
    using System.Drawing;

    /// <summary>
    /// The ImageManager interface.
    /// </summary>
    public interface IImageManager
    {
        /// <summary>
        /// Gets the image.
        /// </summary>
        Image Image { get; }

        /// <summary>
        /// The rotateFlipType.
        /// </summary>
        /// <param name="rotateFlipType">
        /// The rotate flip type.
        /// </param>
        void Rotate(RotateFlipType rotateFlipType);

        /// <summary>
        /// The crop.
        /// </summary>
        void Crop();
    }
}
