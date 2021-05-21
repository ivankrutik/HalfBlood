namespace UI.ProcessComponents.WarehouseQualityCertificateDomain
{
    using System.ComponentModel.Composition;
    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.WarehouseQualityCertificateDomain;

    [Export(typeof(IWarehouseQualityCertificateWithFilterViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class WarehouseQualityCertificateWithFilterViewModel 
        : ReactiveObject, IWarehouseQualityCertificateWithFilterViewModel
    {
        private readonly IRoutableViewModelManager _routableViewModelManager;
        private IWarehouseQualityCertificateViewModel _warehouseQualityCertificateViewModel;

        [ImportingConstructor]
        public WarehouseQualityCertificateWithFilterViewModel(
            IScreen screen,
            IRoutableViewModelManager routableViewModelManager)
        {
            _routableViewModelManager = routableViewModelManager;
            HostScreen = screen;
        }

        public string UrlPathSegment 
        { 
            get; 
            private set; 
        }
        public IScreen HostScreen
        {
            get;
            private set;
        }
        public IWarehouseQualityCertificateViewModel WarehouseQualityCertificateViewModel
        {
            get
            {
                return _warehouseQualityCertificateViewModel
                       ?? (_warehouseQualityCertificateViewModel =
                           _routableViewModelManager.Get<IWarehouseQualityCertificateViewModel>());
            }
        }
    }
}