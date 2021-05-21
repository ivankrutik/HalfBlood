// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The posting of inventory at the warehouse view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.CuttingOrderDomain.CuttingOrderDomain
{
    using System;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using System.Windows.Input;

    using Buisness.Entities.CuttingOrderDomain;
    using Buisness.Filters;

    using Halfblood.Common.Mappers;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.CuttingOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.CuttingOrderDomain;
    using UI.Infrastructure.ViewModels.Filters;

    /// <summary>
    /// The posting of inventory at the warehouse view model.
    /// </summary>
    [Export(typeof(ICuttingOrderViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CuttingOrderViewModel : ReactiveObject, ICuttingOrderViewModel
    {
        #region private fields
        private ReactiveCommand _preparingForDetailedCuttingOrderCommand;
        private CuttingOrder _selectedCuttingOrder;
        private readonly IRoutableViewModelManager routableViewModelManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private bool _isBusy;
        private IFilterViewModel<CuttingOrderFilter, CuttingOrderDto> _filterStrategy;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CuttingOrderViewModel"/> class.
        /// </summary>
        /// <param name="screen">
        /// The screen.
        /// </param>
        /// <param name="messenger">
        /// The Messenger.
        /// </param>
        /// <param name="routableViewModelManager">
        /// The view model manager.
        /// </param>
        /// <param name="unitOfWorkFactory">
        /// The unit of work factory.
        /// </param>
        /// <param name="filterViewModelFactory">
        /// The filter view model factory.
        /// </param>
        [ImportingConstructor]
        public CuttingOrderViewModel(
            IScreen screen,
            IMessenger messenger,
            IRoutableViewModelManager routableViewModelManager,
            IUnitOfWorkFactory unitOfWorkFactory,
            IFilterViewModelFactory filterViewModelFactory)
        {
            HostScreen = screen;
            this.routableViewModelManager = routableViewModelManager;
            _unitOfWorkFactory = unitOfWorkFactory;
            _filterViewModelFactory = filterViewModelFactory;
        }

        /// <summary>
        /// Gets the host screen.
        /// </summary>
        public IScreen HostScreen { get; private set; }

        /// <summary>
        /// Gets the url path segment.
        /// </summary>
        public string UrlPathSegment
        {
            get { return "/CuttingOrderView"; }
        }

        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }

        public CuttingOrder SelectedCuttingOrder
        {
            get { return _selectedCuttingOrder; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedCuttingOrder, value);
            }
        }
        public IFilterViewModel<CuttingOrderFilter, CuttingOrderDto> CuttingOrderFilterViewModel
        {
            get
            {
                return _filterStrategy
                       ?? (_filterStrategy = _filterViewModelFactory.Create<CuttingOrderFilter, CuttingOrderDto>());
            }
        }
        public ICommand PreparingForDetailedCuttingOrderCommand
        {
            get
            {
                if (_preparingForDetailedCuttingOrderCommand == null)
                {
                    var observable = this.WhenAny(x => x.SelectedCuttingOrder, x => x.Value).Select(x => x != null && x.Rn != 0);
                    _preparingForDetailedCuttingOrderCommand = GetCommand(observable);
                }
                return _preparingForDetailedCuttingOrderCommand;
            }
        }
        public ICommand PreparingForStatusCuttingOrderCommand
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// The preparing editable plan receipt order.
        /// </summary>
        /// <param name="editState">
        /// The edit state.
        /// </param>
        /// <returns>
        /// The <see cref="CuttingOrder"/>.
        /// </returns>
        private CuttingOrder PreparingDetailedCuttingOrder()
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<ICuttingOrderService>();
                var cuttingOrder = service.GetCuttingOrder(SelectedCuttingOrder.Rn).MapTo<CuttingOrder>();
                return cuttingOrder;
            }
        }

        /// <summary>
        /// The get command.
        /// </summary>
        /// <param name="canExecute">
        /// The can execute.
        /// </param>
        /// <returns>
        /// The <see cref="ReactiveCommand"/>.
        /// </returns>
        private ReactiveCommand GetCommand(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.RegisterAsyncFunction(
                _ =>
                    {
                        IsBusy = true;
                        return PreparingDetailedCuttingOrder();
                    }).Finally(() => IsBusy = false).Subscribe(
                        result =>
                            {
                                var viewModel = this.routableViewModelManager.Get<ICuttingOrderDetailedViewModel>();
                                viewModel.SetCuttingOrder(result);
                                HostScreen.Router.Navigate.Execute(viewModel);
                            });

            return command;
        }
    }
}
