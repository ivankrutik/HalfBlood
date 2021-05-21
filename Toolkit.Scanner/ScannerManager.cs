namespace Toolkit.Scanner
{
    using System.ComponentModel.Composition;

    using Halfblood.Common.Helpers.FileManagers;

    using Infrastructure;
    using Infrastructure.Scanner;
    using WIA;

    /// <summary>
    /// The scanner.
    /// </summary>
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IScannerManager))]
    public class ScannerManager : ConnectDevice, IGetFileStrategy, IScannerManager
    {
        private double _dpi = 100;
        private double _brid = 100;
        private bool _withAdvancedSettings;

        // <summary>
        /// The scanning.
        /// <param name="wiaImageIntent">
        /// The wia image intent.
        /// </param>
        /// <param name="wiaImageBias">
        /// The wia image bias.
        /// </param>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        public byte[] Scanning(ScanImageIntent wiaImageIntent, ScanImageBias wiaImageBias)
        {
            var wiaImage = WiaDiag.ShowAcquireImage(
                WiaDeviceType.ScannerDeviceType,
                (WiaImageIntent)wiaImageIntent,
                (WiaImageBias)wiaImageBias,
                EnvFormatId.WiaFormatJpeg,
                false,
                true,
                false);
            return wiaImage != null ? wiaImage.FileData.get_BinaryData() : null;
        }

        /// <summary>
        /// The scanning.
        /// </summary>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        public byte[] Scanning()
        {
            ConnectScanner();
            
            Scaner.SetParams(_dpi, _brid);
            ImageFile wiaImage = WiaDiag.ShowTransfer(Scaner, EnvFormatId.WiaFormatJpeg, false);
            return wiaImage != null ? wiaImage.FileData.get_BinaryData() : null;
        }

        /// <summary>
        /// The get file.
        /// </summary>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        public byte[] GetFile()
        {
            return _withAdvancedSettings ? Scanning(ScanImageIntent.Grayscale, ScanImageBias.MinimizeSize) : Scanning();
        }

        public void SetParams(double dpi, double brid, bool withAdvancedSettings)
        {
            _dpi = dpi;
            _brid = brid;
            _withAdvancedSettings = withAdvancedSettings;
        }
    }
}