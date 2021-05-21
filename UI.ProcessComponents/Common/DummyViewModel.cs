namespace UI.ProcessComponents.Common
{
    using System;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using Halfblood.Common.Reporting;
    using Halfblood.Reports;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;

    [Export(typeof(IDummyViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DummyViewModel : ReactiveObject, IDummyViewModel
    {
        #region PRIVATE FIELDS
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPrintManager _printManager;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private bool _isBusy;
        private StoreGasStationOilDepotDto _inStoreGasStationOilDepot;
        private decimal _quantity;
        private ReactiveCommand _dealCommand;
        private CertificateQualityRestLiteDto _certificateQuality;
        private Task<long> _task;
        private string _numberOfBook;
        private DateTime? _dateOfBook;
        private IFilterViewModel<StoreGasStationOilDepotFilter, StoreGasStationOilDepotDto> _storeSearcher;
        private IFilterViewModel<EmployeeFilter, EmployeeDto> _employeeOtkFilterViewModel;
        private IFilterViewModel<EmployeeFilter, EmployeeDto> _employeeStoreFilterViewModel;
        private EmployeeDto _selectedEmployeeOtk;
        private EmployeeDto _selectedEmployeeStore;
        #endregion

        [ImportingConstructor]
        public DummyViewModel(
            IScreen screen,
            IUnitOfWorkFactory unitOfWorkFactory,
            IPrintManager printManager,
            IFilterViewModelFactory filterViewModelFactory)
        {
            HostScreen = screen;
            _unitOfWorkFactory = unitOfWorkFactory;
            _printManager = printManager;
            _filterViewModelFactory = filterViewModelFactory;
        }

        public string UrlPathSegment
        {
            get;
            private set;
        }
        public IScreen HostScreen
        {
            get;
            private set;
        }
        public bool IsBusy
        {
            get { return this._isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public StoreGasStationOilDepotDto InStoreGasStationOilDepot
        {
            get { return this._inStoreGasStationOilDepot; }
            set { this.RaiseAndSetIfChanged(ref _inStoreGasStationOilDepot, value); }
        }
        public IFilterViewModel<StoreGasStationOilDepotFilter, StoreGasStationOilDepotDto> StoreSearcher
        {
            get
            {
                return _storeSearcher
                       ?? (_storeSearcher =
                           _filterViewModelFactory.Create<StoreGasStationOilDepotFilter, StoreGasStationOilDepotDto>());
            }
        }
        public decimal Quantity
        {
            get { return this._quantity; }
            set { this.RaiseAndSetIfChanged(ref _quantity, value); }
        }
        public ICommand DealCommand
        {
            get
            {
                return this._dealCommand
                       ?? (this._dealCommand = this.CreateDealCommand(this.CreateCanExecuteDealCommand()));
            }
        }
        public string NumberOfBook
        {
            get { return this._numberOfBook; }
            set { this.RaiseAndSetIfChanged(ref _numberOfBook, value); }
        }
        public DateTime? DateOfBook
        {
            get { return this._dateOfBook; }
            set { this.RaiseAndSetIfChanged(ref _dateOfBook, value); }
        }
        public CertificateQualityRestLiteDto CertificateQuality
        {
            get { return this._certificateQuality; }
            set { this.RaiseAndSetIfChanged(ref _certificateQuality, value); }
        }
        public IFilterViewModel<EmployeeFilter, EmployeeDto> EmployeeOTKFilterViewModel
        {
            get
            {
                return _employeeOtkFilterViewModel
                       ?? (_employeeOtkFilterViewModel = _filterViewModelFactory.Create<EmployeeFilter, EmployeeDto>());
            }
        }
        public IFilterViewModel<EmployeeFilter, EmployeeDto> EmployeeStoreFilterViewModel
        {
            get
            {
                return _employeeStoreFilterViewModel
                       ?? (_employeeStoreFilterViewModel = _filterViewModelFactory.Create<EmployeeFilter, EmployeeDto>());
            }
        }
        public EmployeeDto SelectedEmployeeOtk
        {
            get { return this._selectedEmployeeOtk; }
            set { this.RaiseAndSetIfChanged(ref _selectedEmployeeOtk, value); }
        }
        public EmployeeDto SelectedEmployeeStore
        {
            get { return this._selectedEmployeeStore; }
            set { this.RaiseAndSetIfChanged(ref _selectedEmployeeStore, value); }
        }

        public void Wait()
        {
            if (_task != null && !_task.IsCanceled)
            {
                _task.Wait();
            }
        }

        private ReactiveCommand CreateDealCommand(IObservable<bool> canExecuteObservable = null)
        {
            var command = new ReactiveCommand(canExecuteObservable);
            command.IsExecuting.Subscribe(isBusy => IsBusy = isBusy);
            command.ThrownExceptions.ObserveOnUiSafeScheduler().Subscribe(OnError);
            command.RegisterAsyncTask(_ => (_task = Task.Factory.StartNew(() => Deal())))
                .ObserveOnUiSafeScheduler()
                .Subscribe(
                    certificateUid =>
                        {
                            Print(_task.Result);
                            HostScreen.Router.NavigateBack.Execute(null);
                        });

            return command;
        }
        private IObservable<bool> CreateCanExecuteDealCommand()
        {
            return
                Observable.CombineLatest(
                    this.WhenAnyValue(x => x.InStoreGasStationOilDepot).Select(store => store != null),
                    this.WhenAnyValue(x => x.Quantity).Select(quantity => quantity > 0),
                    this.WhenAnyValue(x => x.SelectedEmployeeOtk).Select(user => user != null),
                    this.WhenAnyValue(x => x.DateOfBook).Select(date => date != null),
                    this.WhenAnyValue(x => x.NumberOfBook).Select(numberOfBook => !string.IsNullOrWhiteSpace(numberOfBook)),
                    this.WhenAnyValue(x => x.SelectedEmployeeStore).Select(user => user != null),
                    this.WhenAnyValue(x => x.CertificateQuality).Select(x => x != null),
                    (a, b, c, d, e, f, g) => a && b && c && d && e && f && g);
        }
        private void OnError(Exception exception)
        {
            UserError.Throw("Не удалось выдать материал", exception);
        }
        private long Deal()
        {
            long certificateUid;

            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<ICertificateQualityService>();
                certificateUid = service.TakeMaterial(
                    Quantity,
                    (DateTime)_dateOfBook,
                    _numberOfBook,
                    InStoreGasStationOilDepot,
                    CertificateQuality,
                    SelectedEmployeeOtk,
                    SelectedEmployeeStore);

                unitOfWork.Commit();
            }

            return certificateUid;
        }
        private void Print(long certificateUid)
        {
            var report = new CertificateSSHReport(certificateUid, Quantity);
            _printManager.OpenReportInBrowser(report);
        }
    }
}
