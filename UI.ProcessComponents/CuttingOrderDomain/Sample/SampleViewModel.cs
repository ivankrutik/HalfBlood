// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostingOfInventoryAtTheWarehouseViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PostingOfInventoryAtTheWarehouseViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.CuttingOrderDomain.Sample
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
    [Export(typeof(ISampleViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SampleViewModel : ReactiveObject, ISampleViewModel
    {
        #region private fields
        private ReactiveCommand _preparingForEditSampleCommand;
        private Sample _selectedSample;
        private CuttingOrderSpecification _selectedCuttingOrderSpecification;
        private readonly IRoutableViewModelManager routableViewModelManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private bool _isBusy;
        private IFilterViewModel<SampleFilter, SampleLiteDto> _filterStrategy;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleViewModel"/> class.
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
        public SampleViewModel(
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
            get { return "/SampleView"; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is busy.
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }

        public Sample SelectedSample
        {
            get { return _selectedSample; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedSample, value);
            }
        }
        public IFilterViewModel<SampleFilter, SampleLiteDto> SampleFilterViewModel
        {
            get
            {
                return _filterStrategy ?? (_filterStrategy = _filterViewModelFactory.Create<SampleFilter, SampleLiteDto>());
            }
        }
        public ICommand PreparingForEditSampleCommand
        {
            get
            {

                var observable = this.WhenAny(x => x.SelectedSample, x => x.Value).Select(x => x != null && x.Rn != 0);
                _preparingForEditSampleCommand = new ReactiveCommand(observable);
                _preparingForEditSampleCommand.RegisterAsyncFunction(
                    editState =>
                    new
                    {
                        Sample = PreparingEditableSample((EditState)editState),
                        EditState = (EditState)editState
                    })
                    .Finally(() => IsBusy = false)
                    .Subscribe(
                            result =>
                            {
                                var viewModel = this.routableViewModelManager.Get<IEditableSampleViewModel>();
                                viewModel.SetEditableObject(result.Sample, result.EditState);
                                HostScreen.Router.Navigate.Execute(viewModel);
                            });

                return _preparingForEditSampleCommand;
            }
        }
        public ICommand PreparingForStatusSampleCommand
        {
            get { throw new NotImplementedException(); }
        }
        public CuttingOrderSpecification SelectedCuttingOrderSpecification
        {
            get { return _selectedCuttingOrderSpecification; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedCuttingOrderSpecification, value);
                OnSelectedCuttingOrderSpecification(value);
            }
        }

        private Sample PreparingEditableSample(EditState editState)
        {
            IsBusy = true;
            if (editState == EditState.Edit)
            {
                using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<ICuttingOrderService>();
                    var sample = service.GetSample(SelectedSample.Rn).MapTo<Sample>();
                    return sample;
                }
            }

            return new Sample();
        }
        private void OnSelectedCuttingOrderSpecification(CuttingOrderSpecification cuttingOrderSpecification)
        {
            if (cuttingOrderSpecification == null)
            {
                return;
            }
            SampleFilterViewModel.Filter.CuttingOrderSpecification.Rn = cuttingOrderSpecification.Rn;
            SampleFilterViewModel.InvokeCommand.Execute(null);
        }
    }
}
