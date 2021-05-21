// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBarcodeReader.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The BarcodeScanner interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure
{
    using System;

    /// <summary>
    /// The BarcodeScanner interface.
    /// </summary>
    public interface IBarcodeReader : IDisposable
    {
        /// <summary>
        /// The entered barcode.
        /// </summary>
        event Action<string> EnteredBarcode;

        /// <summary>
        /// The start.
        /// </summary>
        void Start();

        /// <summary>
        /// The stop.
        /// </summary>
        void Stop();
    }
}
