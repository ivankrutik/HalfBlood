namespace Toolkit.Infrastructure.Scanner
{
    public enum ScanImageIntent
    {
        None = 0,
        Color = 1,
        Grayscale = 2,
        Text = 4
    }
    public enum ScanImageBias
    {
        None = 0,
        MinimizeSize = 65536,
        MaximizeQuality = 131072,
        BestPreview = 262144
    }
}
