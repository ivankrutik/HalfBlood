// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderDetailedViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The posting of inventory at the warehouse view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.CuttingOrderDomain.CuttingOrderDomain
{
    using System.ComponentModel.Composition;

    using ReactiveUI;

    using ServiceContracts;

    using UI.Entities.CuttingOrderDomain;
    using UI.Infrastructure.ViewModels.CuttingOrderDomain;

    /// <summary>
    /// The posting of inventory at the warehouse view model.
    /// </summary>
    [Export(typeof(ICuttingOrderDetailedViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CuttingOrderDetailedViewModel : ReactiveObject, ICuttingOrderDetailedViewModel
    {
        private bool _isBusy;
        private CuttingOrder _cuttingOrder;

        [ImportingConstructor]
        public CuttingOrderDetailedViewModel(
            IScreen screen,
            IUnitOfWorkFactory unitOfWork)
        {
        }

        public string UrlPathSegment
        {
            get { return "/CuttingOrderDetailedView"; }
        }
        public IScreen HostScreen { get; private set; }
        public CuttingOrder CuttingOrder
        {
            get { return _cuttingOrder; }
            private set { this.RaiseAndSetIfChanged(ref _cuttingOrder, value); }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }

        public void SetCuttingOrder(CuttingOrder entity)
        {
            CuttingOrder = entity;
        }
    }
}
