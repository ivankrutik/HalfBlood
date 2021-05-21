// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ImageManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Helpers
{
    using System;
    using System.Drawing;

    /// <summary>
    /// The image manager.
    /// </summary>
    public class ImageManager : IImageManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageManager"/> class.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        public ImageManager(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            Image = image;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        public Image Image { get; private set; }

        /// <summary>
        /// The rotateFlipType.
        /// </summary>
        /// <param name="rotateFlipType">
        /// The rotate flip type.
        /// </param>
        public virtual void Rotate(RotateFlipType rotateFlipType)
        {
            Image.RotateFlip(rotateFlipType);
        }

        /// <summary>
        /// The crop.
        /// </summary>
        public virtual void Crop()
        {
            throw new System.NotImplementedException();
        }
    }
}
