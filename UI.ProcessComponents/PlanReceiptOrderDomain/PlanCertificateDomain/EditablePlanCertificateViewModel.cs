// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditablePlanCertificateViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditablePlanCertificateViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.PlanReceiptOrderDomain.PlanCertificateDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.NomenclatorDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;
    using Buisness.Filters;

    using FluentValidation;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;
    using Halfblood.Common.Log;
    using Halfblood.Common.Mappers;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModelLite.CommonDomain;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Entities.CommonDomain;
    using UI.Entities.NomeclatorDomain;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.EditViewModels;
    using Halfblood.AlgorithmsOfCalculation;

    [Export(typeof(IEditablePlanCertificateViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditablePlanCertificateViewModel
        : PolicyEditableViewModelBase<PlanCertificate>, IEditablePlanCertificateViewModel
    {
        #region private fields
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRoutableViewModelManager _routableViewModelManager;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IInitializationManager initializationManager;
        private NomenclatureNumber _selectedNomenclatureNumber;
        private ReactiveCommand _preparingForEditPassCommand;
        private ReactiveCommand _preparingForEditDestinationCommand;
        private ReactiveCommand _preparingForEditMechanicIndicatorValuesCommand;
        private ReactiveCommand _preparingForEditChemicalIndcatorValuesCommand;
        private IAttachedDocumentViewModel _attachedDocumentViewModel;
        private readonly Subject<Unit> _disposedNotification = new Subject<Unit>();
        private IFilterViewModel<CertificateQualityFilter, CertificateQualityDto> _certificateQualityViewModel;
        private IFilterViewModel<NomenclatureNumberModificationFilter, NomenclatureNumberModificationDto> _storekeeperModificationFilterViewModel;
        private IFilterViewModel<NomenclatureNumberModificationFilter, NomenclatureNumberModificationDto> _goodsmanagerModificationFilterViewModel;
        private IFilterViewModel<UserFilter, UserDto> _userFilterViewModel;
        private IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> _mixFilterViewModel;
        private IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> _markaFilterViewModel;
        private IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> _gostMixFilterViewModel;
        private IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> _gostCastFilterViewModel;
        #endregion

        ~EditablePlanCertificateViewModel()
        {
            LogManager.Log.Debug("EditablePlanCertificateViewModel IS DESTROYED");
        }

        [ImportingConstructor]
        public EditablePlanCertificateViewModel(
            IScreen screen,
            IUnitOfWorkFactory unitOfWorkFactory,
            IRoutableViewModelManager routableViewModelManager,
            IFilterViewModelFactory filterViewModelFactory,
            IValidatorFactory validatorFactory,
            IMessageBus messageBus,
            IInitializationManager initializationManager)
            : base(screen, messageBus, validatorFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
            this._routableViewModelManager = routableViewModelManager;
            this._filterViewModelFactory = filterViewModelFactory;
            this.initializationManager = initializationManager;
            this.InitializeFilterViewModel();
            this.InitializeRecalculation();
        }

        public string UrlPathSegment
        {
            get { return "/EditPlanCertificate"; }
        }
        public IAttachedDocumentViewModel Document
        {
            get
            {
                if (this._attachedDocumentViewModel == null)
                {
                    this._attachedDocumentViewModel =
                        this._routableViewModelManager.Get<IAttachedDocumentViewModel>(_disposedNotification);

                    this._attachedDocumentViewModel.SetHasDocument(
                        this.EditableObject.WhenAny(x => x.CertificateQuality)
                            .StartWith(EditableObject.CertificateQuality));

                    Task task = this.initializationManager.InitViewModel(this._attachedDocumentViewModel);
                    task.Wait();
                }

                return this._attachedDocumentViewModel;
            }
        }
        public NomenclatureNumber SelectedNomenclatureNumber
        {
            get { return _selectedNomenclatureNumber; }
            set { this.RaiseAndSetIfChanged(ref _selectedNomenclatureNumber, value); }
        }
        public IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> GostCastFilterViewModel
        {
            get
            {
                return this._gostCastFilterViewModel
                       ?? (_gostCastFilterViewModel =
                           _filterViewModelFactory.Create<CertificateQualityFilter, CertificateQualityLiteDto>());
            }
        }
        public IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> GostMixFilterViewModel
        {
            get
            {
                return this._gostMixFilterViewModel
                       ?? (_gostMixFilterViewModel =
                           _filterViewModelFactory.Create<CertificateQualityFilter, CertificateQualityLiteDto>());
            }
        }
        public IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> MarkaFilterViewModel
        {
            get
            {
                return this._markaFilterViewModel
                       ?? (_markaFilterViewModel =
                           _filterViewModelFactory.Create<CertificateQualityFilter, CertificateQualityLiteDto>());
            }
        }
        public IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> MixFilterViewModel
        {
            get
            {
                return this._mixFilterViewModel
                       ?? (_mixFilterViewModel =
                           _filterViewModelFactory.Create<CertificateQualityFilter, CertificateQualityLiteDto>());
            }
        }
        public IFilterViewModel<UserFilter, UserDto> UserFilterViewModel
        {
            get
            {
                return this._userFilterViewModel
                       ?? (_userFilterViewModel = _filterViewModelFactory.Create<UserFilter, UserDto>());
            }
        }
        public IFilterViewModel<NomenclatureNumberModificationFilter, NomenclatureNumberModificationDto> GoodsmanagerModificationFilterViewModel
        {
            get
            {
                return this._goodsmanagerModificationFilterViewModel
                       ?? (_goodsmanagerModificationFilterViewModel =
                           _filterViewModelFactory
                               .Create<NomenclatureNumberModificationFilter, NomenclatureNumberModificationDto>());
            }
        }
        public IFilterViewModel<NomenclatureNumberModificationFilter, NomenclatureNumberModificationDto> StorekeeperModificationFilterViewModel
        {
            get
            {
                if (_storekeeperModificationFilterViewModel == null)
                {
                    _storekeeperModificationFilterViewModel =
                        _filterViewModelFactory
                            .Create<NomenclatureNumberModificationFilter, NomenclatureNumberModificationDto>();
                }

                return this._storekeeperModificationFilterViewModel;
            }
        }
        public IFilterViewModel<CertificateQualityFilter, CertificateQualityDto> CertificateQualityViewModel
        {
            get
            {
                if (_certificateQualityViewModel == null)
                {
                    var canExecuteGetCertificateQuality =
                        this.WhenAnyValue(x => x.EditableObject)
                            .Select(planCertificate => planCertificate != null)
                            .Merge(
                                this.WhenAnyValue(x => x.EditableObject.ModificationNomenclature)
                                    .Select(
                                        mNomenclature =>
                                        mNomenclature != null && !string.IsNullOrWhiteSpace(mNomenclature.Code)))
                            .StartWith(
                                EditableObject != null && EditableObject.ModificationNomenclature != null
                                && !string.IsNullOrWhiteSpace(EditableObject.ModificationNomenclature.Code));

                    _certificateQualityViewModel =
                        _filterViewModelFactory.Create<CertificateQualityFilter, CertificateQualityDto>(
                            canExecuteGetCertificateQuality);
                }

                return _certificateQualityViewModel;
            }
        }
        public IList<TaxBand> TaxBands { get; set; }
        public IList<NameOfCurrency> NameOfCurrencies { get; set; }
        public IList<UnitOfMeasure> UnitOfMeasures { get; set; }
        public ICommand PreparingForEditPassCommand
        {
            get
            {
                if (_preparingForEditPassCommand == null)
                {
                    _preparingForEditPassCommand = new ReactiveCommand(Observable.Empty<bool>());
                    _preparingForEditPassCommand.Subscribe(
                        x =>
                        {
                            var viewModel = this._routableViewModelManager.Get<IEditablePassViewModel>();
                            if (EditableObject.CertificateQuality == null)
                            {
                                EditableObject.CertificateQuality = new CertificateQuality();
                            }

                            if (EditableObject.CertificateQuality.Passes == null)
                            {
                                EditableObject.CertificateQuality.Passes = new ReactiveList<Pass>();
                            }

                            viewModel.SetCertificateQuality(EditableObject.CertificateQuality);
                            viewModel.SetEditableObject(EditableObject.CertificateQuality.Passes);
                            viewModel.Destinations = EditableObject.CertificateQuality.Destinations;
                            HostScreen.Router.Navigate.Execute(viewModel);
                        });
                }

                return _preparingForEditPassCommand;
            }
        }
        public ICommand PreparingForEditDestinationCommand
        {
            get
            {
                if (_preparingForEditDestinationCommand == null)
                {
                    _preparingForEditDestinationCommand = new ReactiveCommand(Observable.Empty<bool>());
                    _preparingForEditDestinationCommand.ObserveOnUiSafeScheduler().Subscribe(
                        x =>
                        {
                            var viewModel = this._routableViewModelManager.Get<IEditableDestinationViewModel>();
                            if (EditableObject.CertificateQuality == null)
                            {
                                EditableObject.CertificateQuality = new CertificateQuality();
                            }

                            if (EditableObject.CertificateQuality.Destinations == null)
                            {
                                EditableObject.CertificateQuality.Destinations = new ReactiveList<Destination>();
                            }

                            viewModel.SetCertificateQuality(EditableObject.CertificateQuality);
                            viewModel.SetEditableObject(EditableObject.CertificateQuality.Destinations);
                            HostScreen.Router.Navigate.Execute(viewModel);
                        });
                }

                return _preparingForEditDestinationCommand;
            }
        }
        public ICommand PreparingForEditMechanicIndicatorValuesCommand
        {
            get
            {
                if (_preparingForEditMechanicIndicatorValuesCommand == null)
                {
                    _preparingForEditMechanicIndicatorValuesCommand = new ReactiveCommand();
                    _preparingForEditMechanicIndicatorValuesCommand.ObserveOnUiSafeScheduler().Subscribe(
                        _ =>
                        {
                            var viewModel = this._routableViewModelManager.Get<IEditableMechanicViewModel>();
                            if (EditableObject.CertificateQuality == null)
                            {
                                EditableObject.CertificateQuality = new CertificateQuality();
                            }

                            if (EditableObject.CertificateQuality.MechanicIndicatorValues == null)
                            {
                                EditableObject.CertificateQuality.MechanicIndicatorValues =
                                    new ReactiveList<MechanicIndicatorValue>();
                            }

                            viewModel.SetCertificateQuality(EditableObject.CertificateQuality);

                            viewModel.SetEditableObject(
                                EditableObject.CertificateQuality.MechanicIndicatorValues,
                                EditState.Edit);
                            HostScreen.Router.Navigate.Execute(viewModel);
                        });
                }

                return _preparingForEditMechanicIndicatorValuesCommand;
            }
        }
        public ICommand PreparingForEditChemicalIndicatorValuesCommand
        {
            get
            {
                if (_preparingForEditChemicalIndcatorValuesCommand == null)
                {
                    _preparingForEditChemicalIndcatorValuesCommand = new ReactiveCommand();
                    _preparingForEditChemicalIndcatorValuesCommand.Subscribe(
                        _ =>
                        {
                            var viewModel = this._routableViewModelManager.Get<IEditableChemicalViewModel>();
                            if (EditableObject.CertificateQuality == null)
                            {
                                EditableObject.CertificateQuality = new CertificateQuality();
                            }

                            if (EditableObject.CertificateQuality.ChemicalIndicatorValues == null)
                            {
                                EditableObject.CertificateQuality.ChemicalIndicatorValues =
                                    new ReactiveList<ChemicalIndicatorValue>();
                            }

                            viewModel.SetCertificateQuality(EditableObject.CertificateQuality);

                            viewModel.SetEditableObject(
                                EditableObject.CertificateQuality.ChemicalIndicatorValues,
                                EditState.Edit);
                            HostScreen.Router.Navigate.Execute(viewModel);
                        });
                }

                return _preparingForEditChemicalIndcatorValuesCommand;
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            if (this._attachedDocumentViewModel != null)
            {
                this._attachedDocumentViewModel.Dispose();
                this._attachedDocumentViewModel = null;
            }

            _disposedNotification.OnNext(Unit.Default);
        }

        protected override IObservable<bool> CanExecute(IObservable<bool> validateObservable)
        {
            var canExecute =
                Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    h => EditableObject.CertificateQuality.PropertyChanged += h,
                    h => EditableObject.CertificateQuality.PropertyChanged -= h)
                    .Select(_ => GetValidator().Validate(EditableObject).IsValid)
                    .StartWith(GetValidator().Validate(EditableObject).IsValid);

            return validateObservable.Merge(canExecute);
        }
        protected override void ApplyAction(PlanCertificate editObject)
        {
            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();

                if (EditState == EditState.Edit)
                {
                    var r = editObject.MapTo<PlanCertificateDto>();
                 
                    service.UpdatePlanCertificate(r);
                }
                else
                {
                    EditableObject.Rn = service.AddPlanCertificate(editObject.MapTo<PlanCertificateDto>()).Rn;
                }

                unitOfWork.Commit();
            }
        }
        protected override void OnLoadAcatalog()
        {
            GetCatalogAccess.LoadForEntity(typeof(CertificateQuality), TypeActionInSystem.StandardCorrection);
        }

        private void InitializeFilterViewModel()
        {
            this.CertificateQualityViewModel.LoadCompletedNotification.Where(x => x.Any())
                .Select(x => x.First())
                .Subscribe(x => this.EditableObject.CertificateQuality = x.ClearValues().MapTo<CertificateQuality>());
        }
        private void InitializeRecalculation()
        {
            var taxFilter = this._filterViewModelFactory.Create<TaxFilter, TaxLiteDto>();

            this.WhenAny(
                x => x.EditableObject,
                x => x.EditableObject.CountByDocument,
                x => x.EditableObject.Price,
                (e, cd, p) => e.Value != null && cd.Value != null && cd.Value != null && p.Value != null)
                .CombineLatest(
                    taxFilter.LoadCompletedNotification.Select(result => result.Any()),
                    (left, right) => left && right)
                .Where(isNeedRecalculate => isNeedRecalculate)
                .Subscribe(
                    _ =>
                    {
                        if (taxFilter.Result != null && taxFilter.Result.Any())
                        {
                            EditableObject.SumDocumenta = CreditSlipDomainAlgorithmsOfCalculation.SumWithoutNDS((decimal)EditableObject.CountByDocument, (decimal)EditableObject.Price);
                            EditableObject.SumWithTaxDocumenta = CreditSlipDomainAlgorithmsOfCalculation.SumWithNDS((decimal)EditableObject.CountByDocument, (decimal)EditableObject.Price, taxFilter.Result.First().Value);
                        }
                    });

            this.WhenAny(
                x => x.EditableObject,
                x => x.EditableObject.TaxBand,
                (e, t) => t.Value)
                .Where(taxBand => taxBand != null)
                .Subscribe(x =>
                    {
                        taxFilter.SetFilter(new TaxFilter { TaxBandRN = this.EditableObject.TaxBand == null ? 0 : this.EditableObject.TaxBand.Rn });
                        taxFilter.InvokeCommand.Execute(null);
                    });
        }

    }
}