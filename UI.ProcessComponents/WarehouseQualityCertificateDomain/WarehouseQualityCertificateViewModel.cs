// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.WarehouseQualityCertificateDomain
{
    using System;
    using System.ComponentModel.Composition;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Windows.Input;

    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Halfblood.Common;
    using Halfblood.Common.Log;
    using Halfblood.Common.Mappers;

    using ParusModelLite.CertificateQualityDomain.WarehouseQualityCertificateDomain;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.WarehouseQualityCertificateDomain;

    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IWarehouseQualityCertificateViewModel))]
    public class WarehouseQualityCertificateViewModel : ReactiveObject, IWarehouseQualityCertificateViewModel
    {
        #region PRIVATE FIELDS
        private readonly IMessageBus _messageBus;
        protected readonly IRoutableViewModelManager RoutableViewManagerManager;
        protected readonly IUnitOfWorkFactory UnitOfWorkFactory;
        protected readonly DisposableObject Disposables = new DisposableObject();
        protected readonly Subject<Unit> DisposableNotification = new Subject<Unit>();
        private ReactiveCommand _printCommand;
        private WarehouseQualityCertificateRestLiteDto _selectedWarehouseQualityCertificate;
        private ReactiveCommand _removeCommand;
        private ICommand _navigateToScanCommand;
        private IWarehouseQualityCertificateFilterViewModel _warehouseQualityCertificateFilterViewModel;
        private bool _isBusy;
        #endregion

        ~WarehouseQualityCertificateViewModel()
        {
            LogManager.Log.Debug("WarehouseQualityCertificateViewModel IS DESTROYED");
        }

        [ImportingConstructor]
        public WarehouseQualityCertificateViewModel(
            IScreen screen,
            IMessageBus messageBus,
            IRoutableViewModelManager routableViewModelManager,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            HostScreen = screen;
            _messageBus = messageBus;
            RoutableViewManagerManager = routableViewModelManager;
            UnitOfWorkFactory = unitOfWorkFactory;
        }

        public WarehouseQualityCertificateRestLiteDto SelectedWarehouseQualityCertificate
        {
            get { return this._selectedWarehouseQualityCertificate; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedWarehouseQualityCertificate, value);
                if (value != null)
                {
                    _messageBus.SendMessage<WarehouseQualityCertificateLiteDto>(
                        new WarehouseQualityCertificateLiteDto { Rn = value.Rn });
                }
            }
        }

        public IWarehouseQualityCertificateFilterViewModel WarehouseQualityCertificateFilterViewModel
        {
            get
            {
                return _warehouseQualityCertificateFilterViewModel
                       ?? (_warehouseQualityCertificateFilterViewModel =
                           RoutableViewManagerManager.Get<IWarehouseQualityCertificateFilterViewModel>());
            }
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
            get { return "/WarehouseQualityCertificateFilterViewModel"; }
        }
        public ICommand RemoveCommand
        {
            get
            {
                if (this._removeCommand == null)
                {
                    var observable =
                        this.WhenAny(x => x._selectedWarehouseQualityCertificate, x => x.Value)
                            .Select(x => x != null && x.Rn > 0)
                            .StartWith(
                                _selectedWarehouseQualityCertificate != null
                                && _selectedWarehouseQualityCertificate.Rn > 0);
                    _removeCommand = CreateRemoveCommand(observable);
                }

                return _removeCommand;
            }
        }
        public ICommand PrintCommand
        {
            get
            {
                if (this._printCommand == null)
                {
                    var observable =
                        this.WhenAny(x => x._selectedWarehouseQualityCertificate, x => x.Value)
                            .Select(x => x != null && x.Rn > 0)
                            .StartWith(
                                _selectedWarehouseQualityCertificate != null
                                && _selectedWarehouseQualityCertificate.Rn > 0);
                    _printCommand = CreatePrintCommand(observable);
                }

                return _printCommand;
            }
        }
        public ICommand NavigateToScanCommand
        {
            get
            {
                return _navigateToScanCommand
                       ?? (_navigateToScanCommand =
                           CreateNavigateToScanCommand(
                               this.WhenAny(x => x.SelectedWarehouseQualityCertificate, x => x.Value != null)));
            }
        }

        public void Dispose()
        {
            this.Disposables.Dispose();
            this.DisposableNotification.OnNext(Unit.Default);
        }

        private ReactiveCommand CreateRemoveCommand(IObservable<bool> observable)
        {
            var command = new ReactiveCommand(observable);
            command.Subscribe(
                result =>
                {
                    using (IUnitOfWork unitOfWork = this.UnitOfWorkFactory.Create())
                    {
                        var service = unitOfWork.Create<ICertificateQualityService>();

                        {

                            service.RemoveWarehouseQualityCertificate(SelectedWarehouseQualityCertificate.Rn);
                            unitOfWork.Commit();
                        }
                    }
                });

            command.ThrownExceptions.Subscribe(this.OnErrorRemove);
            return command;
        }
        private ReactiveCommand CreatePrintCommand(IObservable<bool> observable)
        {
            return new ReactiveCommand(observable);
        }
        private ReactiveCommand CreateNavigateToScanCommand(IObservable<bool> canExecuteObservable = null)
        {
            var command = new ReactiveCommand(canExecuteObservable);
            command.IsExecuting.Subscribe(isBusy => IsBusy = isBusy);
            command.RegisterAsyncFunction(
                _ =>
                {
                    CertificateQualityDto certificateQuality;
                    using (IUnitOfWork unitOfWork = this.UnitOfWorkFactory.Create())
                    {
                        var service = unitOfWork.Create<ICertificateQualityService>();
                        certificateQuality =
                            service.GetCertificateQualityByWarehouse(SelectedWarehouseQualityCertificate.Rn);
                    }

                    var viewModel = this.RoutableViewManagerManager.Get<IAttachedDocumentViewModel>();
                    viewModel.SetHasDocument(certificateQuality.MapTo<CertificateQuality>());

                    return viewModel;
                }).Subscribe(viewModel => HostScreen.Router.Navigate.Execute(viewModel));

            return command;
        }
        private void OnErrorRemove(Exception exception)
        {
            UserError.Throw("Подготовка к добавлению/редактированию", exception);
        }
    }
}
