// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImagesConverter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ImagesConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Halfblood.Common.Helpers.FileManagers.Converters
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Drawing.Imaging;

    /// <summary>
    /// The image converter.
    /// </summary>
    public static class ImagesConverter
    {
        /// <summary>
        /// The byte array to image.
        /// </summary>
        /// <param name="imageData">
        /// The image data.
        /// </param>
        /// <returns>
        /// The <see cref="Image"/>.
        /// </returns>
        public static Image ToImage(byte[] imageData)
        {
            //using (var ms = new MemoryStream(imageData))
            if (imageData == null) return null;
            var ms = new MemoryStream(imageData);
            {
                return Image.FromStream(ms);
            }
        }

        public static Image ConvertInFormat(Image imageOriginal, ImageFormat formatTarget)
        {
            if (imageOriginal == null) return null;
            Image imageConverted;

            using (var ms = new MemoryStream())
            {
                imageOriginal.Save(ms, formatTarget);
                ms.Position = 0; 
                imageConverted = Image.FromStream(ms);
            }

            return imageConverted;
        }
        /// <summary>
        /// The to byte array.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        public static byte[] ToByteArray(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static Image ThumbnailImage (this Image image)
        {
            return image != null ? image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero) : null;
        }
    }
}