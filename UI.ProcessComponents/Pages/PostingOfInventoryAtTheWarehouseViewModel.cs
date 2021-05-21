// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostingOfInventoryAtTheWarehouseViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PostingOfInventoryAtTheWarehouseViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Pages
{
    using System;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;

    using Halfblood.Common.Log;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;

    [Export(typeof(IPostingOfInventoryAtTheWarehouseViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PostingOfInventoryAtTheWarehouseViewModel
        : ReactiveObject, IPostingOfInventoryAtTheWarehouseViewModel
    {
        private readonly IRoutableViewModelManager _routableViewModelManager;
        private IPlanCertificateViewModel _planCertificateViewModel;
        private IPlanReceiptOrderViewModel _planReceiptOrderViewModel;
        private bool _isBusy;

        ~PostingOfInventoryAtTheWarehouseViewModel()
        {
            LogManager.Log.Debug("PostingOfInventoryAtTheWarehouseViewModel IS DESTROYED");
        }

        [ImportingConstructor]
        public PostingOfInventoryAtTheWarehouseViewModel(
            IScreen screen,
            IRoutableViewModelManager routableViewModelManager)
        {
            HostScreen = screen;
            _routableViewModelManager = routableViewModelManager;
            Binding();
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public IPlanCertificateViewModel PlanCertificateViewModel
        {
            get
            {
                return _planCertificateViewModel
                       ?? (_planCertificateViewModel =
                           _routableViewModelManager.Get<IPlanCertificateViewModel>());
            }
        }
        public IPlanReceiptOrderViewModel PlanReceiptOrderViewModel
        {
            get
            {
                return _planReceiptOrderViewModel
                       ?? (_planReceiptOrderViewModel = _routableViewModelManager.Get<IPlanReceiptOrderViewModel>());
            }
        }
        public IScreen HostScreen { get; private set; }
        public string UrlPathSegment
        {
            get { return "/PostingOfInventoryAtTheWarehouseView"; }
        }

        private void Binding()
        {
            PlanReceiptOrderViewModel.WhenAny(x => x.IsBusy, x => x.Value)
                .CombineLatest(PlanCertificateViewModel.WhenAny(x => x.IsBusy, x => x.Value), (pc, pro) => pro || pc)
                .ObserveOnUiSafeScheduler()
                .Subscribe(isBusy => IsBusy = isBusy);

            PlanReceiptOrderViewModel.WhenAny(x => x.SelectedPlanReceiptOrder, x => x.Value)
                .Subscribe(pro => PlanCertificateViewModel.SelectedPlanReceiptOrder = pro);
        }
    }
}
