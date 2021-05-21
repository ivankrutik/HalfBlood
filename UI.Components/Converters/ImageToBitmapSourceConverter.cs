namespace UI.Components.Converters
{
    using System;
    using System.Windows.Data;
    using Halfblood.Common.Helpers.FileManagers.Converters;

    public class ImageToBitmapSourceConverter : IValueConverter
    {
        private static ImageToBitmapSourceConverter _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static ImageToBitmapSourceConverter Instance
        {
            get { return _instance ?? (_instance = new ImageToBitmapSourceConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            var image = ImagesConverter.ToImage((byte[])value);
            return ImageToBitmapSource.ToBitmapSource(image);
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
