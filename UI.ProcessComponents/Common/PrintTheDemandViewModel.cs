namespace UI.ProcessComponents.Common
{
    using System;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using System.Windows.Input;

    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using Halfblood.Common.Reporting;
    using Halfblood.Reports;

    using ParusModelLite;
    using ParusModelLite.CertificateQualityDomain.WarehouseQualityCertificateDomain;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Common;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.WarehouseQualityCertificateDomain;

    [Export(typeof(IPrintTheDemandViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PrintTheDemandViewModel : ReactiveObject, IPrintTheDemandViewModel
    {
        #region PRIVATE FIELDS
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IRoutableViewModelManager _routableViewModelManager;
        private readonly IPrintManager _printManager;
        private IWarehouseQualityCertificateWithFilterViewModel _warehouseQualityCertificateViewModel;
        private IFilterViewModel<DeficiencyFilter, DeficiencyLiteDto> _deficiencySearcher;
        private IFilterViewModel<EmployeeFilter, EmployeeDto> _employeeFilterViewModel;
        private IFilterViewModel<EmployeeFilter, EmployeeDto> _employeeOtkFilterViewModel;
        private IFilterViewModel<EmployeeFilter, EmployeeDto> _employeeReceiverFilterViewModel;
        private IFilterViewModel<EmployeeFilter, EmployeeDto> _employeeGiverFilterViewModel;
        private ReactiveCommand _printCommand;
        private EmployeeDto _selectedEmployeeOtk;
        private EmployeeDto _selectedEmployeeReceiver;
        private EmployeeDto _selectedEmployeeGiver;
        private long _countDSE;
        private DeficiencyLiteDto _selectedDeficiency;
        private WarehouseQualityCertificateLiteDto _selectedWarehouseQualityCertificate;
        #endregion

        [ImportingConstructor]
        public PrintTheDemandViewModel(
            IFilterViewModelFactory filterViewModelFactory,
            IRoutableViewModelManager routableViewModelManager,
            IPrintManager printManager,
            IMessageBus messageBus)
        {
            messageBus.Listen<WarehouseQualityCertificateLiteDto>()
                .Subscribe(selectedCertificate => SelectedWarehouseQualityCertificate = selectedCertificate);

            _filterViewModelFactory = filterViewModelFactory;
            _routableViewModelManager = routableViewModelManager;
            _printManager = printManager;
        }

        public WarehouseQualityCertificateLiteDto SelectedWarehouseQualityCertificate
        {
            get { return _selectedWarehouseQualityCertificate; }
            set { this.RaiseAndSetIfChanged(ref _selectedWarehouseQualityCertificate, value); }
        }
        public IWarehouseQualityCertificateWithFilterViewModel WarehouseQualityCertificateViewModel
        {
            get
            {
                return _warehouseQualityCertificateViewModel
                       ?? (_warehouseQualityCertificateViewModel =
                           _routableViewModelManager.Get<IWarehouseQualityCertificateWithFilterViewModel>());
            }
        }
        public long CountDSE
        {
            get
            {
                return _countDSE;
            }
            set
            {
                _countDSE = value;
            }
        }
        public IFilterViewModel<DeficiencyFilter, DeficiencyLiteDto> DeficiencySearcher
        {
            get
            {
                return _deficiencySearcher
                       ?? (_deficiencySearcher = _filterViewModelFactory.Create<DeficiencyFilter, DeficiencyLiteDto>());
            }
        }
        public DeficiencyLiteDto SelectedDeficiency
        {
            get { return _selectedDeficiency; }
            set { this.RaiseAndSetIfChanged(ref _selectedDeficiency, value); }
        }
        public ICommand PrintCommand
        {
            get
            {
                return _printCommand ?? (_printCommand = CreatePrintCommand(CreateCanExecuteObservable()));
            }
        }
        public string UrlPathSegment { get; private set; }
        public IScreen HostScreen { get; private set; }
        public IFilterViewModel<EmployeeFilter, EmployeeDto> EmployeeOtkFilterViewModel
        {
            get
            {
                return _employeeOtkFilterViewModel
                       ?? (_employeeOtkFilterViewModel = _filterViewModelFactory.Create<EmployeeFilter, EmployeeDto>());
            }
        }
        public IFilterViewModel<EmployeeFilter, EmployeeDto> EmployeeReceiverFilterViewModel
        {
            get
            {
                return _employeeReceiverFilterViewModel
                       ?? (_employeeReceiverFilterViewModel =
                           _filterViewModelFactory.Create<EmployeeFilter, EmployeeDto>());
            }
        }
        public IFilterViewModel<EmployeeFilter, EmployeeDto> EmployeeGiverFilterViewModel
        {
            get
            {
                return _employeeGiverFilterViewModel
                       ?? (_employeeGiverFilterViewModel = _filterViewModelFactory.Create<EmployeeFilter, EmployeeDto>());
            }
        }
        public EmployeeDto SelectedEmployeeOtk
        {
            get { return this._selectedEmployeeOtk; }
            set { this.RaiseAndSetIfChanged(ref _selectedEmployeeOtk, value); }
        }
        public EmployeeDto SelectedEmployeeReceiver
        {
            get { return this._selectedEmployeeReceiver; }
            set { this.RaiseAndSetIfChanged(ref _selectedEmployeeReceiver, value); }
        }
        public EmployeeDto SelectedEmployeeGiver
        {
            get { return this._selectedEmployeeGiver; }
            set { this.RaiseAndSetIfChanged(ref _selectedEmployeeGiver, value); }
        }

        private ReactiveCommand CreatePrintCommand(IObservable<bool> canExecuteObservable)
        {
            var command = new ReactiveCommand(canExecuteObservable);
            command.ObserveOnUiSafeScheduler()
                .Subscribe(_ =>
                {
                    var demandreport = new TheDemandReport
                    {
                        CountDSE = CountDSE,
                        DSE = SelectedDeficiency.DSE,
                        Shop = SelectedDeficiency.StageWorkshopManufacturer,
                        EmployeeGiver = SelectedEmployeeGiver.Fullname,
                        EmployeeOTK = SelectedEmployeeOtk.Fullname,
                        EmployeeReceiver = SelectedEmployeeReceiver.Fullname,
                        KeyRn = SelectedWarehouseQualityCertificate.Rn
                    };
                    _printManager.OpenReportInBrowser(demandreport);
                });

            return command;
        }
        private IObservable<bool> CreateCanExecuteObservable()
        {
            return
                Observable.CombineLatest(
                    this.WhenAnyValue(x => x.SelectedDeficiency).Select(x => x != null),
                    this.WhenAnyValue(x => x.SelectedEmployeeGiver).Select(x => x != null),
                    this.WhenAnyValue(x => x.SelectedEmployeeOtk).Select(x => x != null),
                    this.WhenAnyValue(x => x.SelectedEmployeeReceiver).Select(x => x != null),
                    this.WhenAnyValue(x => x.SelectedWarehouseQualityCertificate).Select(x => x != null),
                    (a, b, c, d, e) => a && b && c && d && e);
        }
    }
}
