// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificationViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The posting of inventory at the warehouse view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.CuttingOrderDomain.Certifications
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
    [Export(typeof(ICertificationViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CertificationViewModel : ReactiveObject, ICertificationViewModel
    {
        #region private fields
        private ReactiveCommand _preparingForEditCertificationCommand;
        private Certification selectedCertification;
        private CuttingOrderSpecification _selectedCuttingOrderSpecification;
        private readonly IRoutableViewModelManager routableViewModelManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private bool _isBusy;
        private IFilterViewModel<CertificationFilter, CertificationDto> _filterStrategy;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificationViewModel"/> class.
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
        public CertificationViewModel(
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
            CertificationFilterViewModel.InvokeCommand.Execute(null);
        }

        /// <summary>
        /// Gets the host screen.
        /// </summary>
        public IScreen HostScreen { get; private set; }

        /// <summary>
        /// Gets the key path segment.
        /// </summary>
        public string UrlPathSegment
        {
            get { return "/CertificationView"; }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public Certification SelectedCertification
        {
            get { return selectedCertification; }
            set
            {
                this.RaiseAndSetIfChanged(ref selectedCertification, value);
            }
        }
        public IFilterViewModel<CertificationFilter, CertificationDto> CertificationFilterViewModel
        {
            get
            {
                return _filterStrategy
                       ?? (_filterStrategy =
                           _filterViewModelFactory.Create<CertificationFilter, CertificationDto>());
            }
        }
        public ICommand PreparingForEditCertificationCommand
        {
            get
            {
                var observable = this.WhenAny(x => x.SelectedCertification, x => x.Value).Select(x => x != null && x.Rn != 0);
                _preparingForEditCertificationCommand = new ReactiveCommand(observable);
                _preparingForEditCertificationCommand.RegisterAsyncFunction(
                    editState =>
                    new
                    {
                        Certification = PreparingEditableCertification((EditState)editState),
                        EditState = (EditState)editState
                    })
                    .Finally(() => IsBusy = false)
                    .Subscribe(
                            result =>
                            {
                                var viewModel = this.routableViewModelManager.Get<IEditableCertificationViewModel>();
                                viewModel.SetEditableObject(result.Certification, result.EditState);
                                HostScreen.Router.Navigate.Execute(viewModel);
                            });

                return _preparingForEditCertificationCommand;
            }
        }
        public ICommand PreparingForStatusCertificationCommand
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

        private Certification PreparingEditableCertification(EditState editState)
        {
            IsBusy = true;
            if (editState == EditState.Edit)
            {
                using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<ICuttingOrderService>();
                    var Certification = service.GetCertification(SelectedCertification.Rn).MapTo<Certification>();
                    return Certification;
                }
            }

            return new Certification();
        }
        private void OnSelectedCuttingOrderSpecification(CuttingOrderSpecification cuttingOrderSpecification)
        {
            if (cuttingOrderSpecification == null)
            {
                return;
            }

            CertificationFilterViewModel.Filter.CuttingOrderSpecification.Rn = cuttingOrderSpecification.Rn;
            CertificationFilterViewModel.InvokeCommand.Execute(null);
        }
    }
}
