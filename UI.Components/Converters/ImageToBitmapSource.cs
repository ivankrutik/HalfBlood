// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageToBitmapSource.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ImageToBitmapSource type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Converters
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// The image to bitmap source.
    /// </summary>
    public static class ImageToBitmapSource
    {
        /// <summary>
        /// The to bitmap source.
        /// </summary>
        /// <param name="Image">
        /// The image.
        /// </param>
        /// <returns>
        /// The <see cref="BitmapSource"/>.
        /// </returns>
        public static BitmapSource ToBitmapSource(Image Image)
        {
            if (Image == null)
            {
                throw new ArgumentNullException("Image");
            }

            //using (var ms = new MemoryStream())
            var ms = new MemoryStream();
            var bi = new BitmapImage();
            bi.BeginInit();
            Image.Save(ms, ImageFormat.Jpeg);
            ms.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ms;
            bi.EndInit();

            return bi;
        }
    }
}