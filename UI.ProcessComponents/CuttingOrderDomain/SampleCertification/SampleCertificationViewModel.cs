// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleCertificationViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The posting of inventory at the warehouse view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.CuttingOrderDomain.SampleCertification
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
    [Export(typeof(ISampleCertificationViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SampleCertificationViewModel : ReactiveObject, ISampleCertificationViewModel
    {
        #region private fields
        private readonly IRoutableViewModelManager routableViewModelManager;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        private ReactiveCommand _preparingForEditSampleCertificationCommand;
        private SampleCertification _selectedSampleCertification;
        private Sample _selectedSample;
        private bool _isBusy;
        private IFilterViewModel<SampleCertificationFilter, SampleCertificationDto> _filterStrategy;
        #endregion

        [ImportingConstructor]
        public SampleCertificationViewModel(
            IScreen screen,
            IMessenger messenger,
            IFilterViewModelFactory filterViewModelFactory,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            HostScreen = screen;
            _filterViewModelFactory = filterViewModelFactory;
            this._unitOfWorkFactory = unitOfWorkFactory;
            SampleCertificationFilterViewModel.InvokeCommand.Execute(null);
        }

        public IScreen HostScreen { get; private set; }
        public string UrlPathSegment
        {
            get { return "/SampleCertificationView"; }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public SampleCertification SelectedSampleCertification
        {
            get { return _selectedSampleCertification; }
            set { this.RaiseAndSetIfChanged(ref _selectedSampleCertification, value); }
        }
        public IFilterViewModel<SampleCertificationFilter, SampleCertificationDto> SampleCertificationFilterViewModel
        {
            get
            {
                return _filterStrategy
                       ?? (_filterStrategy = _filterViewModelFactory.Create<SampleCertificationFilter, SampleCertificationDto>());
            }
        }
        public ICommand PreparingForEditSampleCertificationCommand
        {
            get
            {
                var observable = this.WhenAny(x => x.SelectedSampleCertification, x => x.Value).Select(x => x != null && x.Rn != 0);
                _preparingForEditSampleCertificationCommand = new ReactiveCommand(observable);
                _preparingForEditSampleCertificationCommand.RegisterAsyncFunction(
                    editState =>
                    new
                    {
                        SampleCertification = PreparingEditableSampleCertification((EditState)editState),
                        EditState = (EditState)editState
                    })
                    .Finally(() => IsBusy = false)
                    .Subscribe(
                            result =>
                            {
                                var viewModel = this.routableViewModelManager.Get<IEditableSampleCertificationViewModel>();
                                viewModel.SetEditableObject(result.SampleCertification, result.EditState);
                                HostScreen.Router.Navigate.Execute(viewModel);
                            });

                return _preparingForEditSampleCertificationCommand;
            }
        }
        public ICommand PreparingForStatusSampleCertificationCommand
        {
            get { throw new NotImplementedException(); }
        }
        public Sample SelectedSample
        {
            get { return _selectedSample; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedSample, value);
                OnSelectedSample(value);
            }
        }

        private SampleCertification PreparingEditableSampleCertification(EditState editState)
        {
            IsBusy = true;
            if (editState == EditState.Edit)
            {
                using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<ICuttingOrderService>();
                    var sampleCertification = service.GetSampleCertification(SelectedSampleCertification.Rn).MapTo<SampleCertification>();
                    return sampleCertification;
                }
            }

            return new SampleCertification();
        }
        private void OnSelectedSample(Sample sample)
        {
            if (sample == null)
            {
                return;
            }

            SampleCertificationFilterViewModel.Filter.Sample.Rn = sample.Rn;
            SampleCertificationFilterViewModel.InvokeCommand.Execute(null);
        }
    }
}
