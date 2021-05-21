// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderSpecificationViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The posting of inventory at the warehouse view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.CuttingOrderDomain.CuttingOrderSpecificationDomain
{
    using System;
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
    [Export(typeof(ICuttingOrderSpecificationViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CuttingOrderSpecificationViewModel : ReactiveObject, ICuttingOrderSpecificationViewModel
    {
        #region private fields
        private ReactiveCommand _preparingForEditCuttingOrderSpecificationCommand;
        private CuttingOrderSpecification _selectedCuttingOrderSpecification;
        private CuttingOrder _selectedCuttingOrder;
        private readonly IRoutableViewModelManager routableViewModelManager;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private bool _isBusy;
        private IFilterViewModel<CuttingOrderSpecificationFilter, CuttingOrderSpecificationLiteDto> _filterStrategy;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CuttingOrderSpecificationViewModel"/> class.
        /// </summary>
        /// <param name="screen">
        /// The screen.
        /// </param>
        /// <param name="messenger">
        /// The Messenger.
        /// </param>
        /// <param name="filterViewModelFactory">
        /// The filter view model factory.
        /// </param>
        /// <param name="unitOfWorkFactory">
        /// The unit of work factory.
        /// </param>
        [ImportingConstructor]
        public CuttingOrderSpecificationViewModel(
            IScreen screen,
            IMessenger messenger,
            IFilterViewModelFactory filterViewModelFactory,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            HostScreen = screen;
            _filterViewModelFactory = filterViewModelFactory;
            _unitOfWorkFactory = unitOfWorkFactory;
            CuttingOrderSpecificationFilterViewModel.InvokeCommand.Execute(null);
        }

        public IScreen HostScreen { get; private set; }
        public string UrlPathSegment
        {
            get { return "/CuttingOrderSpecificationView"; }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public CuttingOrderSpecification SelectedCuttingOrderSpecification
        {
            get { return _selectedCuttingOrderSpecification; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedCuttingOrderSpecification, value);
            }
        }
        public IFilterViewModel<CuttingOrderSpecificationFilter, CuttingOrderSpecificationLiteDto> CuttingOrderSpecificationFilterViewModel
        {
            get
            {
                return _filterStrategy
                       ?? (_filterStrategy =
                           _filterViewModelFactory.Create<CuttingOrderSpecificationFilter, CuttingOrderSpecificationLiteDto>());
            }
        }
        public ICommand PreparingForEditCuttingOrderSpecificationCommand
        {
            get
            {
                var observable =
                    this.WhenAny(x => x.SelectedCuttingOrderSpecification, x => x.Value)
                        .Select(x => x != null && x.Rn > 0);
                _preparingForEditCuttingOrderSpecificationCommand = new ReactiveCommand(observable);
                _preparingForEditCuttingOrderSpecificationCommand.RegisterAsyncFunction(
                    editState =>
                    new
                        {
                            CuttingOrderSpecification = PreparingEditableCuttingOrderSpecification((EditState)editState),
                            EditState = (EditState)editState
                        }).Finally(() => IsBusy = false).Subscribe(
                            result =>
                                {
                                    throw new NotImplementedException();
                                    var viewModel =
                                        this.routableViewModelManager.Get<IEditableCuttingOrderSpecificationViewModel>();
                                    //viewModel.SetEditableObject(result.CuttingOrderSpecification, result.EditState);
                                    HostScreen.Router.Navigate.Execute(viewModel);
                                });

                return _preparingForEditCuttingOrderSpecificationCommand;
            }
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

        private CuttingOrderSpecification PreparingEditableCuttingOrderSpecification(EditState editState)
        {
            IsBusy = true;
            if (editState == EditState.Edit)
            {
                using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<ICuttingOrderService>();
                    var cuttingOrderSpecification = service.GetCuttingOrderSpecification(SelectedCuttingOrderSpecification.Rn).MapTo<CuttingOrderSpecification>();
                    return cuttingOrderSpecification;
                }
            }

            return new CuttingOrderSpecification();
        }
        private void OnSelectedCuttingOrder(CuttingOrder cuttingOrder)
        {
            if (cuttingOrder == null)
            {
                return;
            }

            CuttingOrderSpecificationFilterViewModel.Filter.CuttingOrder.Rn = cuttingOrder.Rn;
            CuttingOrderSpecificationFilterViewModel.InvokeCommand.Execute(null);
        }
    }
}