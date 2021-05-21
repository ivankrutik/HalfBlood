namespace Toolkit.Scanner
{
    using WIA;

    class ConvertImage
    {
        private  ImageProcess _ip;
        public ConvertImage()
        {
            _ip = new ImageProcess();
        }
        public ImageFile Filter(ImageFile image, string filter)
        {
            _ip.Filters.Add(_ip.FilterInfos["Convert"].FilterID);
            _ip.Filters[1].Properties["FormatID"].set_Value(filter);
            return _ip.Apply(image);
        }
    }
}
