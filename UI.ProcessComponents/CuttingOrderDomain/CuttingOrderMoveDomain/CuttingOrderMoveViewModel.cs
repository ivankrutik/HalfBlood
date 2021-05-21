// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostingOfInventoryAtTheWarehouseViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PostingOfInventoryAtTheWarehouseViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.CuttingOrderDomain.CuttingOrderMoveDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using System.Windows.Input;

    using Buisness.Filters;

    using Halfblood.Common.Mappers;

    using ParusModelLite.CuttingOrderDomain;

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
    [Export(typeof(ICuttingOrderMoveViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CuttingOrderMoveViewModel : ReactiveObject, ICuttingOrderMoveViewModel
    {
        #region private fields
        private readonly IRoutableViewModelManager _routableViewModelManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IList<IDisposable> _disposable;
        private ReactiveCommand _preparingForEditCuttingOrderMoveCommand;
        private CuttingOrderMove _selectedCuttingOrderMove;
        private CuttingOrder _selectedCuttingOrder;
        private bool _isBusy;
        private IFilterViewModel<CuttingOrderMoveFilter, CuttingOrderMoveLiteDto> _filterStrategy;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CuttingOrderMoveViewModel"/> class.
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
        [ImportingConstructor]
        public CuttingOrderMoveViewModel(
            IScreen screen,
            IMessenger messenger,
            IRoutableViewModelManager routableViewModelManager,
            IUnitOfWorkFactory unitOfWorkFactory,
            IFilterViewModelFactory filterViewModelFactory)
        {
            HostScreen = screen;
            _disposable = new List<IDisposable>();
            this._routableViewModelManager = routableViewModelManager;
            _unitOfWorkFactory = unitOfWorkFactory;
            _filterViewModelFactory = filterViewModelFactory;
            CuttingOrderMoveFilterViewModel.InvokeCommand.Execute(null);
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
            get { return "/CuttingOrderMoveView"; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is busy.
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public CuttingOrderMove SelectedCuttingOrderMove
        {
            get { return _selectedCuttingOrderMove; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedCuttingOrderMove, value);
            }
        }
        public IFilterViewModel<CuttingOrderMoveFilter, CuttingOrderMoveLiteDto> CuttingOrderMoveFilterViewModel
        {
            get
            {
                return _filterStrategy
                       ?? (_filterStrategy = _filterViewModelFactory.Create<CuttingOrderMoveFilter, CuttingOrderMoveLiteDto>());
            }
        }
        public ICommand PreparingForEditCuttingOrderMoveCommand
        {
            get
            {

                var observable = this.WhenAny(x => x.SelectedCuttingOrderMove, x => x.Value).Select(x => x != null && x.Rn != 0);
                _preparingForEditCuttingOrderMoveCommand = new ReactiveCommand(observable);
                _preparingForEditCuttingOrderMoveCommand.RegisterAsyncFunction(
                    editState =>
                    new
                        {
                            CuttingOrderMove = PreparingEditableCuttingOrderMove((EditState)editState),
                            EditState = (EditState)editState
                        }).Finally(() => IsBusy = false).Subscribe(
                            result =>
                                {
                                    var viewModel = this._routableViewModelManager.Get<IEditableCuttingOrderMoveViewModel>();
                                    viewModel.SetEditableObject(result.CuttingOrderMove, result.EditState);
                                    HostScreen.Router.Navigate.Execute(viewModel);
                                });

                return _preparingForEditCuttingOrderMoveCommand;
            }
        }
        public ICommand PreparingForStatusCuttingOrderMoveCommand
        {
            get { throw new NotImplementedException(); }
        }
        public CuttingOrder SelectedCuttingOrder
        {
            get { return _selectedCuttingOrder; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedCuttingOrder, value);
                OnSelectedCuttingOrder(value);
            }
        }

        public void Dispose()
        {
            if (_disposable != null)
            {
                foreach (IDisposable disposable in _disposable)
                {
                    disposable.Dispose();
                }
            }
        }

        private CuttingOrderMove PreparingEditableCuttingOrderMove(EditState editState)
        {
            IsBusy = true;
            if (editState == EditState.Edit)
            {
                using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<ICuttingOrderService>();
                    var cuttingOrderMove = service.GetCuttingOrderMove(SelectedCuttingOrderMove.Rn).MapTo<CuttingOrderMove>();
                    return cuttingOrderMove;
                }
            }

            return new CuttingOrderMove();
        }
        private void OnSelectedCuttingOrder(CuttingOrder cuttingOrder)
        {
            if (cuttingOrder == null)
            {
                return;
            }

            CuttingOrderMoveFilterViewModel.Filter.CuttingOrder.Rn = cuttingOrder.Rn;
            CuttingOrderMoveFilterViewModel.InvokeCommand.Execute(null);
        }
    }
}
