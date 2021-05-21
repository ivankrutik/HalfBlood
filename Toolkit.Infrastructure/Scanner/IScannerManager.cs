namespace Toolkit.Infrastructure.Scanner
{
    public interface IScannerManager
    {
        byte[] Scanning(ScanImageIntent wiaImageIntent, ScanImageBias wiaImageBias);
        byte[] Scanning();
    }
}
