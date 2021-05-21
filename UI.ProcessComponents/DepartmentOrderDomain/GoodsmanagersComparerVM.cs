using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using Hephaestus.Infrastructure.Interface;
using Hephaestus.Visirovka.Interface;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using ParusModel;
using ParusModel.Filter;

namespace Hephaestus.Visirovka.ViewModels
{
    //используется для работы с товароведами (смена товароведа, количество заявок и тд)
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof (IGoodsmanagersComparerVM))]
    public class GoodsmanagersComparerVM : IGoodsmanagersComparerVM, INotifyPropertyChanged
    {
        #region Event

        public event Action<IModule> UnloadMe;

        public event Action<IModule> Unloaded;

        public event Action<IModule> Unloading;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region VAR
        private  IErrorHandler _errorHandler;
        private IEventAggregator _eventAggregator;
        [Import] private IGoodsmanagerChangerV _goodsmanagerChangerV;
        private string _header;
        private object _region;

        private object _regionMenu;

        private string _title;
        
       
        private IBLVisirovkaCore _visingCore;

        #region Goodsmanagers

        /// <summary>
        ///     The <see cref="Goodsmanagers" /> property's name.
        /// </summary>
        public const string GoodsmanagersPropertyName = "Goodsmanagers";

        private ObservableCollection<Agnlist> _goodsmanager = new ObservableCollection<Agnlist>();

        /// <summary>
        ///     Sets and gets the Goodsmanagers property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public ObservableCollection<Agnlist> Goodsmanagers
        {
            get { return _goodsmanager; }

            set
            {
                if (_goodsmanager == value)
                {
                    return;
                }


                _goodsmanager = value;

                OnPropertyChanged(GoodsmanagersPropertyName);
            }
        }

        #endregion

        #region FromGoodsmanager

        /// <summary>
        ///     The <see cref="FromGoodsmanager" /> property's name.
        /// </summary>
        public const string FromGoodsmanagerPropertyName = "FromGoodsmanager";

        private Agnlist _fromgoodsmanager = new Agnlist();

        /// <summary>
        ///     Sets and gets the FromGoodsmanager property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public Agnlist FromGoodsmanager
        {
            get { return _fromgoodsmanager; }

            set
            {
                if (_fromgoodsmanager == value)
                {
                    return;
                }

                _fromgoodsmanager = value;
                OnPropertyChanged(FromGoodsmanagerPropertyName);
                ChangeGoodsmanagersCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region ToGoodsmanager

        /// <summary>
        ///     The <see cref="ToGoodsmanager" /> property's name.
        /// </summary>
        public const string ToGoodsmanagerPropertyName = "ToGoodsmanager";

        private Agnlist _togoodsmanager = new Agnlist();

        /// <summary>
        ///     Sets and gets the ToGoodsmanager property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public Agnlist ToGoodsmanager
        {
            get { return _togoodsmanager; }

            set
            {
                if (_togoodsmanager == value)
                {
                    return;
                }

                _togoodsmanager = value;
                OnPropertyChanged(ToGoodsmanagerPropertyName);
                ChangeGoodsmanagersCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region CountOfClaimsFromGoodsmanager

        /// <summary>
        ///     The <see cref="CountOfClaimsFromGoodsmanager" /> property's name.
        /// </summary>
        public const string CountOfSigthsFromGoodsmanagerPropertyName = "CountOfClaimsFromGoodsmanager";

        private int? _countOfClaimsFromGoodsmanager = 0;

        /// <summary>
        ///     Sets and gets the CountOfClaimsFromGoodsmanager property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public int? CountOfClaimsFromGoodsmanager
        {
            get { return _countOfClaimsFromGoodsmanager; }

            set
            {
                if (_countOfClaimsFromGoodsmanager == value)
                {
                    return;
                }


                _countOfClaimsFromGoodsmanager = value;
                OnPropertyChanged(CountOfSigthsFromGoodsmanagerPropertyName);
            }
        }

        #endregion

        #region CountOfClaimsToGoodsmanager

        /// <summary>
        ///     The <see cref="CountOfClaimsToGoodsmanager" /> property's name.
        /// </summary>
        public const string CountOfSightsToGoodsmanagerPropertyName = "CountOfClaimsToGoodsmanager";

        private int? _countOfClaimsToGoodsmanager = 0;

        /// <summary>
        ///     Sets and gets the CountOfClaimsToGoodsmanager property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public int? CountOfClaimsToGoodsmanager
        {
            get { return _countOfClaimsToGoodsmanager; }

            set
            {
                if (_countOfClaimsToGoodsmanager == value)
                {
                    return;
                }


                _countOfClaimsToGoodsmanager = value;
                OnPropertyChanged(CountOfSightsToGoodsmanagerPropertyName);
            }
        }

        #endregion

        #region Message

        /// <summary>
        ///     The <see cref="Message" /> property's name.
        /// </summary>
        public const string MessagePropertyName = "Message";

        private string _message = "";

        /// <summary>
        ///     Sets and gets the Message property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string Message
        {
            get { return _message; }

            set
            {
                if (_message == value)
                {
                    return;
                }


                _message = value;
                OnPropertyChanged(MessagePropertyName);
            }
        }

        #endregion

        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                OnPropertyChanged("Header");
            }
        }

        public object Region
        {
            get { return _region; }
            set
            {
                if (_region == value)
                {
                    return;
                }
                _region = value;
                OnPropertyChanged("Region");
            }
        }

        public object RegionMenu
        {
            get { return _regionMenu; }
            set
            {
                if (_regionMenu == value)
                {
                    return;
                }
                _regionMenu = value;
                OnPropertyChanged("RegionMenu");
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                {
                    return;
                }
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Id
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        #region IsBusy

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
                // ((RelayCommand)LoadDataCommand).RaiseCanExecuteChanged();
            }
        }

        #endregion
        #endregion

        #region CTOR

        public GoodsmanagersComparerVM()
        {
            CountSightsOfGoodsmanagersCommand = new DelegateCommand(ExecuteCountSightsOfGoodsmanagersCommand);
            ChangeGoodsmanagersCommand = new DelegateCommand(ExecuteChangeGoodsmanagersCommand,
                                                             CanExecuteChangeGoodsmanagersCommand);
        }

        public bool Init(IErrorHandler errorHandler,IEventAggregator EventAggregator, IBLVisirovkaCore BLVisirovkaCore)
        {
            _errorHandler = errorHandler;
            _visingCore = BLVisirovkaCore;
            _eventAggregator = EventAggregator;
            _goodsmanagerChangerV.DataContext = this;
            Region = _goodsmanagerChangerV;
            LoadData();

            return true;
        }

        #endregion

        #region COMMANDS

        #region ChangeGoodsmanagersCommand

        public DelegateCommand ChangeGoodsmanagersCommand { get; private set; }


        private void ExecuteChangeGoodsmanagersCommand()
        {
            //получим список заявок для изменяемого товароведа
            var claimsForFirst =
                new List<UDOSight>(_visingCore.GetUdoSight(
                    new FUDOSight
                        {
                            AgnlistTOV = new FAgnlist {RN = new List<long> {FromGoodsmanager.RN}},
                            STATE = new List<UDOSightSTATE> {UDOSightSTATE.NotConfirmed}
                        }));
            //заменим
            _visingCore.ReplaceTov(claimsForFirst, ToGoodsmanager);
            ExecuteCountSightsOfGoodsmanagersCommand();
            Message = "Заявки переназначены";
            //_eventAggregator.GetEvent<GoodsmanagerChanged>().Publish(ToGoodsmanager);
        }

        private bool CanExecuteChangeGoodsmanagersCommand()
        {
            return FromGoodsmanager != null && ToGoodsmanager != null && FromGoodsmanager.RN != 0 &&
                   ToGoodsmanager.RN != 0;
        }

        #endregion

        #region CountSightsOfGoodsmanagersCommand

        public DelegateCommand CountSightsOfGoodsmanagersCommand { get; private set; }

        private void ExecuteCountSightsOfGoodsmanagersCommand()
        {
            var rns = new List<long>();
            if (ToGoodsmanager != null) rns.Add(ToGoodsmanager.RN);
            if (FromGoodsmanager != null) rns.Add(FromGoodsmanager.RN);
            IList<UDOSight> s = _visingCore.GetUdoSight(new FUDOSight
                {
                    AgnlistCREATOR = new FAgnlist {RN = new List<long>()},
                    AgnlistTOV = new FAgnlist {RN = rns},
                    DepartmentOrder = new FDepartmentOrder
                        {
                            Agnlist_ACC_AGENT = new FAgnlist(),
                            Agnlist_AGENT = new FAgnlist(),
                            StoreGasStationOilDepot =
                                new FStoreGasStationOilDepot {AZSNUMBER = new List<string>()},
                            CRN = new List<long?>(),
                            NameOfCurrency = new FNameOfCurrency(),
                            DepartmentOrderSpecifacations = new FDepartmentOrderSpecifacation
                                {
                                    StoreGasStationOilDepot =
                                        new FStoreGasStationOilDepot(),
                                    DICMUNT =
                                        new FDICMUNT(),
                                    NomenclatureNumber =
                                        new FNomenclatureNumber(),
                                    NOMENCL =
                                        new FNOMENCL(),
                                    NOMMODIF =
                                        new FNOMMODIF()
                                },
                            ORDDATE =
                                new ObservableCollection<DateTime?> {null, null},
                            STATEDATE =
                                new ObservableCollection<DateTime?> {null, null},
                            StaffingDivision_ACC_SUBDIV = new FStaffingDivision(),
                            StaffingDivision_SUBDIV = new FStaffingDivision(),
                            ORDSTATE = DepartmentOrder.DepartmentOrderState.All
                        },
                    RN = new List<long?> {null},
                    ROW = 100,
                    STATE = new List<UDOSightSTATE> {UDOSightSTATE.NotConfirmed},
                    URGENTLYTOV = -1
                }
                );
            List<UDOSight> source = s.ToList();
            CountOfClaimsFromGoodsmanager = (FromGoodsmanager != null)
                                                ? source.Count(item => item.AgnlistTOV.RN == FromGoodsmanager.RN)
                                                : 0;

            CountOfClaimsToGoodsmanager = (ToGoodsmanager != null)
                                              ? source.Count(item => item.AgnlistTOV.RN == ToGoodsmanager.RN)
                                              : 0;
        }

        #endregion

        #endregion

        #region Methot

        private void LoadData()
        {

            Observable.ToAsync(
              () =>
              {
                  IsBusy = true;
                  Goodsmanagers = new ObservableCollection<Agnlist>(_visingCore.GetTovAgnlist(new FAgnlist()));
              })()
              .ObserveOnDispatcher()
              .Subscribe(x =>
              {
                  IsBusy = false;

              });


        }

        public bool Unload()
        {
            if (Unloaded != null) Unloaded(this);
            return true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler h = PropertyChanged;
            if (h != null)
                h(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}