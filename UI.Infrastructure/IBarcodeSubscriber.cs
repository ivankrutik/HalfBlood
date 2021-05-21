// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBarcodeSubscriber.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The Subscriber interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure
{
    /// <summary>
    /// The Subscriber interface.
    /// </summary>
    public interface IBarcodeSubscriber
    {
        /// <summary>
        /// The entered barcode.
        /// </summary>
        /// <param name="barcode">
        /// The barcode.
        /// </param>
        void EnteredBarcode(string barcode);
    }
}
