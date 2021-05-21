// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPageViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the MainPageViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents
{
    using System.ComponentModel.Composition;

    using Halfblood.Common.Navigations;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.Messages;
    using UI.Infrastructure.ViewModels;

    [Export(typeof(IMainPageViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainPageViewModel : ReactiveObject, IMainPageViewModel
    {
        private readonly IBarcodeReader _barcodeReader;
        private readonly IMessageBus _messageBus;

        [ImportingConstructor]
        public MainPageViewModel(
            IBarcodeReader barcodeReader,
            IRoutableViewModelManager routableViewModelManager,
            IScreen hostScreen,
            IMessageBus messageBus,
            ITitleBarHostScreen titleBarHostScreen)
        {
            HostScreen = hostScreen;
            _barcodeReader = barcodeReader;
            _messageBus = messageBus;
            _barcodeReader.EnteredBarcode += BarcodeReaderEnteredBarcode;
            _barcodeReader.Start();

            HostScreen.Router.Navigate.Execute(routableViewModelManager.Get<ISwitcherViewModel>());
            titleBarHostScreen.Router.Navigate.Execute(routableViewModelManager.Get<ITitleBarViewModel>());
        }

        public IScreen HostScreen
        {
            get; 
            private set;
        }
        public string UrlPathSegment
        {
            get;
            private set;
        }

        public void Dispose()
        {
            _barcodeReader.EnteredBarcode -= BarcodeReaderEnteredBarcode;
            _barcodeReader.Dispose();
        }

        private void BarcodeReaderEnteredBarcode(string barcode)
        {
            _messageBus.SendMessage(new EnteredBarcodeMessage(barcode));
        }
    }
}