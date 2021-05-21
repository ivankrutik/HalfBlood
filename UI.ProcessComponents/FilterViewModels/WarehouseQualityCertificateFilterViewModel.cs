namespace UI.ProcessComponents.FilterViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive.Linq;

    using Buisness.Filters;

    using ParusModelLite.CertificateQualityDomain.WarehouseQualityCertificateDomain;

    using ReactiveUI;

    using ServiceContracts;

    using UI.Infrastructure.Messages;
    using UI.Infrastructure.ViewModels.Filters;

    [Export(typeof(IWarehouseQualityCertificateFilterViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class WarehouseQualityCertificateFilterViewModel :
        GenericFilterViewModel<WarehouseQualityCertificateRestFilter, WarehouseQualityCertificateRestLiteDto>,
        IWarehouseQualityCertificateFilterViewModel
    {
        private readonly IMessageBus _messageBus;

        [ImportingConstructor]
        public WarehouseQualityCertificateFilterViewModel(
            IScreen screen,
            IUnitOfWorkFactory unitOfWorkFactory,
            IMessageBus messageBus)
            : base(unitOfWorkFactory)
        {
            _messageBus = messageBus;
            HostScreen = screen;
            Binding().ToList();
        }

        public string UrlPathSegment { get; private set; }
        public IScreen HostScreen { get; private set; }

        private void EnteredBarcode(string barcode)
        {
            long rn;
            if (TryParseBarcode(barcode, out rn))
            {
                Filter.Rn = rn;
                InvokeCommand.Execute(null);
            }
        }
        private bool TryParseBarcode(string barcode, out long rn)
        {
            //return long.TryParse(Regex.Replace(barcode, @"\d+z(?=\d+)", string.Empty), out rn);
            return long.TryParse(barcode.Remove(0, 2), out rn);
        }
        private IEnumerable<IDisposable> Binding()
        {
            yield return
                _messageBus.Listen<EnteredBarcodeMessage>().Select(msg => msg.Barcode).Subscribe(EnteredBarcode);
        }
    }
}
