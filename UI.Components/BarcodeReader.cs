// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BarcodeReader.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the BarcodeReader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components
{
    using System;
    using System.ComponentModel.Composition;
    using System.Globalization;
    using System.Reactive.Linq;
    using System.Windows;
    using System.Windows.Input;

    using Halfblood.Common.Log;

    using UI.Infrastructure;

    /// <summary>
    /// The WPF barcode reader.
    /// </summary>
    [Export(typeof(IBarcodeReader))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BarcodeReader : IBarcodeReader
    {
        private IDisposable _disposable;

        /// <summary>
        /// The entered barcode.
        /// </summary>
        public event Action<string> EnteredBarcode;

        /// <summary>
        /// The start. Default length of barcode is 12.
        /// </summary>
        public void Start()
        {
            this.Start(12);
        }

        /// <summary>
        /// The start.
        /// </summary>
        /// <param name="lengthBarcode">
        /// The length string of barcode.
        /// </param>
        public void Start(byte lengthBarcode)
        {
            if (Application.Current == null || Application.Current.MainWindow == null)
            {
                LogManager.Log.Debug("Application.Current == null || Application.Current.MainWindow == null");
                return;
            }

            this.Stop();

            string barcode = string.Empty;

            var keyDown =
                Observable.FromEventPattern<KeyEventHandler, KeyEventArgs>(
                    h => Application.Current.MainWindow.KeyDown += h,
                    h => Application.Current.MainWindow.KeyDown -= h).Select(args => args.EventArgs);

            var keyTilda =
                keyDown.Where(
                    args => (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift && args.Key == Key.OemTilde);

            var keyPipe = keyTilda.Select(_ => keyDown.Where(args => args.Key == Key.OemPipe)).Concat();

            _disposable = keyPipe
                .Do(_ => barcode = string.Empty)
                .Do(args => args.Handled = true)
                .Select(x =>
                    keyDown.Do(args => args.Handled = true)
                           .TakeUntil(keyDown.TimeInterval().Where(args => args.Value.Key == Key.Enter || args.Interval.TotalMilliseconds > 50))
                           .Select(args => ((char)KeyInterop.VirtualKeyFromKey(args.Key)).ToString(CultureInfo.InvariantCulture))
                           .Do(symbol => barcode += symbol)
                           .Finally(() =>
                               {
                                   if (barcode.Length == lengthBarcode)
                                   {
                                       this.OnEnteredBarcode(barcode);
                                   }

                                   barcode = string.Empty;
                               }))
                .Concat()
                .Subscribe();
        }

        /// <summary>
        /// The stop.
        /// </summary>
        public void Stop()
        {
            this.Dispose();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            if (this._disposable != null)
            {
                this._disposable.Dispose();
            }
        }

        /// <summary>
        /// The on entered barcode.
        /// </summary>
        /// <param name="barcode">
        /// The barcode.
        /// </param>
        protected void OnEnteredBarcode(string barcode)
        {
            Action<string> handler = EnteredBarcode;
            if (handler != null)
            {
                handler(barcode);
            }
        }
    }
}
