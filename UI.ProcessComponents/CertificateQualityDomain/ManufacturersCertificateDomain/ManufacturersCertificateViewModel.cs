// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManufacturersCertificateViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ManufacturersCertificateViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace UI.ProcessComponents.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Windows.Input;

    using Buisness.Entities.AttachedDocumentDomain;
    using Buisness.Filters;

    using Halfblood.Common;
    using Halfblood.Common.Mappers;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Entities.PermissionMaterialDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.CertificateQualityServiceDomain.ManufacturersCertificateDomain;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PermissionMaterialDomain;
    using UI.Infrastructure.ViewModels.WarehouseQualityCertificateDomain;
    using Buisness.Entities.CertificateQualityDomain.ActSelectionProbeDomain;
    using UI.Infrastructure.Messages;

    [Export(typeof(IManufacturersCertificateViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ManufacturersCertificateViewModel : ReactiveObject, IManufacturersCertificateViewModel
    {
        #region PRIVATE FIELDS
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IRoutableViewModelManager _routableViewModelManager;
        protected readonly IMessageBus _messageBus;
        private ICertificateQualityRestFilterViewModel _certificateQualityRestFilterViewModel;
        private IWarehouseQualityCertificateViewModel _warehouseQualityCertificateViewModel;
        private CertificateQualityRestLiteDto _selectedCertificateQuality;
        private ReactiveCommand _takeMaterialCommand;
        private ReactiveCommand _showScanCertificateCommand;
        private ReactiveCommand _navigateToDealCommand;
        private ReactiveCommand _setStateCommand;
        private ReactiveCommand _createPermissionMaterialCommand;
        private ReactiveCommand _createActSelectionProbeCommand;
        private bool _isBusy;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        #endregion

        public CertificateQualityRestLiteDto SelectedCertificateQuality
        {
            get { return _selectedCertificateQuality; }
            set { this.RaiseAndSetIfChanged(ref _selectedCertificateQuality, value); }
        }
        public bool IsBusy
        {
            get { return this._isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }

        public IScreen HostScreen
        {
            get;
            private set;
        }
        public string UrlPathSegment
        {
            get { return "/ManufacturersCertificateView"; }
        }



        public ICertificateQualityRestFilterViewModel CertificateQualityRestFilterViewModel
        {
            get
            {
                return _certificateQualityRestFilterViewModel
                       ?? (_certificateQualityRestFilterViewModel =
                           _routableViewModelManager.Get<ICertificateQualityRestFilterViewModel>());
            }
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


        [ImportingConstructor]
        public ManufacturersCertificateViewModel(
            IScreen screen,
            IFilterViewModelFactory filterViewModelFactory,
            IUnitOfWorkFactory unitOfWorkFactory,
            IRoutableViewModelManager routableViewModelManager,
            IMessageBus messenger
            )
        {
            _messageBus = messenger;
            _filterViewModelFactory = filterViewModelFactory;
            _routableViewModelManager = routableViewModelManager;
            _unitOfWorkFactory = unitOfWorkFactory;
            HostScreen = screen;
            Binding().ToList();
        }

        public ICommand TakeMaterialCommand
        {
            get
            {
                if (_takeMaterialCommand == null)
                {
                    _takeMaterialCommand =
                        new ReactiveCommand(this.WhenAny(x => x.SelectedCertificateQuality, x => x.Value != null));
                    _takeMaterialCommand.Subscribe(_ => HostScreen.Router.NavigateBack.Execute(null));
                }

                return _takeMaterialCommand;
            }
        }
        public ICommand ShowScanCertificateCommand
        {
            get
            {
                return _showScanCertificateCommand
                       ?? (_showScanCertificateCommand =
                           CreateShowScanCertificateCommand(
                               this.WhenAny(x => x.SelectedCertificateQuality, x => x.Value != null)));
            }
        }
        public ICommand NavigateToDealCommand
        {
            get
            {
                return _navigateToDealCommand
                       ?? (_navigateToDealCommand =
                           CreateNavigateToDealCommand(
                               this.WhenAny(x => x.SelectedCertificateQuality, x => x.Value != null)
                               .CombineLatest(
                                   this.WhenAnyValue(x => x.IsBusy).Select(isBusy => !isBusy),
                                   (left, right) => left && right)));
            }
        }
        public ICommand SetStateCommand
        {
            get
            {
                return _setStateCommand
                       ?? (_setStateCommand =
                           CreateSetStateCommand());
            }
        }
        public ICommand CreatePermissionMaterialCommand
        {
            get
            {
                return _createPermissionMaterialCommand
                    ?? (_createPermissionMaterialCommand = CreateCommandCreatePermisionMaterial(EditState.Insert,
                                                            this.WhenAny(x => x.SelectedCertificateQuality, x => x.Value)
                                                                .Select(x => x != null && x.Rn != 0)
                                                                .StartWith(SelectedCertificateQuality != null)));
            }
        }
        public ICommand CreateActSelectionProbeCommand
        {
            get
            {
                return _createActSelectionProbeCommand ??
                       (_createActSelectionProbeCommand = CreateCommandCreateActSelectionProbeCommand(this.WhenAnyValue(x => x.SelectedCertificateQuality).Any()));
            }
        }
        private ReactiveCommand CreateNavigateToDealCommand(IObservable<bool> canExecuteObservable = null)
        {
            var command = new ReactiveCommand(canExecuteObservable);
            command.IsExecuting.Subscribe(isBusy => IsBusy = isBusy);
            command.Subscribe(
                _ =>
                {
                    var viewModel = _routableViewModelManager.Get<IDummyViewModel>();
                    viewModel.CertificateQuality = SelectedCertificateQuality;
                    HostScreen.Router.Navigate.Execute(viewModel);
                });

            return command;
        }
        private ReactiveCommand CreateShowScanCertificateCommand(IObservable<bool> canExecuteObservable = null)
        {
            var command = new ReactiveCommand(canExecuteObservable);
            command.IsExecuting.Subscribe(isBusy => IsBusy = isBusy);
            command.RegisterAsyncFunction(_ =>
                {
                    var filtering =
                        _filterViewModelFactory.Create<AttachedDocumentFilter, AttachedDocumentDto>();

                    filtering.Filter.Document = SelectedCertificateQuality.Rn;

                    filtering.Wait();

                    var certificateQuality = new CertificateQuality(SelectedCertificateQuality.Rn);
                    if (filtering.Result.Any())
                    {
                        filtering.Result.MapTo<CertificateQualityAttachedDocument>()
                            .DoForEach(doc => certificateQuality.Documents.Add(doc));
                    }

                    var viewModel = _routableViewModelManager.Get<IAttachedDocumentViewModel>();
                    viewModel.SetHasDocument(certificateQuality);

                    return viewModel;
                }).Subscribe(viewModel => HostScreen.Router.Navigate.Execute(viewModel));

            return command;
        }
        private ReactiveCommand CreateSetStateCommand(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);

            command.RegisterAsyncAction(_ => SetState(SelectedCertificateQuality.Rn,
                SelectedCertificateQuality.State == QualityCertificateState.Confirm ?
                    QualityCertificateState.NotСonfirm :
                        QualityCertificateState.Confirm));

            return command;
        }
        private ReactiveCommand CreateCommandCreatePermisionMaterial(EditState editState, IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.RegisterAsyncFunction(
                _ => new { PermissionMaterial = new PermissionMaterial() })
            .Subscribe(
                    result =>
                    {
                        var viewModel = _routableViewModelManager.Get<IEditablePermissionMaterialViewModel>();
                        viewModel.SetEditableObject(result.PermissionMaterial, editState);
                        viewModel.RnCertificateQuality = SelectedCertificateQuality.Rn;

                        HostScreen.Router.Navigate.Execute(viewModel);
                    });

            return command;
        }

        private ReactiveCommand CreateCommandCreateActSelectionProbeCommand(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.IsExecuting.Subscribe(isBusy => IsBusy = isBusy);
            command.RegisterAsyncFunction(_ =>
            {
                ActSelectionOfProbeDto result;

                using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<IActSelectionOfProbeService>();
                    result= service.AddActSelectionOfProbe(SelectedCertificateQuality.Rn);

                    unitOfWork.Commit();
                }

                return result;
            })
                .Subscribe(result =>
                {
                    if (result==null)
                    {
                        var message = string.Format("Не получилось добавить Акт отбора проб");
                        UserError.Throw(message);
                    }
                    else

                    {
                        _messageBus.SendMessage(new AddedEntityMessage<ActSelectionOfProbeDto>(result));
                    }
                }
                );

            return command;
        }

        private void SetState(long rn, QualityCertificateState state)
        {
            using (var unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IManufacturersCertificateService>();
                service.SetStatus(rn, state);
                unitOfWork.Commit();
            }
        }
        private IEnumerable<IDisposable> Binding()
        {
            yield return this.WhenAnyValue(x => x.SelectedCertificateQuality).Where(x => x != null).Subscribe(
                selectedCertificate =>
                {
                    WarehouseQualityCertificateViewModel.WarehouseQualityCertificateFilterViewModel.SetFilter(
                        new WarehouseQualityCertificateRestFilter { RNCertificateQuality = SelectedCertificateQuality.Rn });
                    WarehouseQualityCertificateViewModel.WarehouseQualityCertificateFilterViewModel.InvokeCommand
                        .Execute(null);
                });
        }
    }
}