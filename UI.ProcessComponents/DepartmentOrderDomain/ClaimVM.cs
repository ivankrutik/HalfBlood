using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reactive.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;
using Hephaestus.Infrastructure.Interface;
using Hephaestus.Infrastructure.Message;
using Hephaestus.Visirovka.Class;
using Hephaestus.Visirovka.Infrastructure;
using Hephaestus.Visirovka.Infrastructure.Message;
using Hephaestus.Visirovka.Interface;
using Hephaestus.Visirovka.View.Wpf.Converter;
using Hephaestus.Visirovka.wscMatNorm;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using ParusModel;
using ParusModel.Filter;
using log4net;
using Hephaestus.Infrastructure.Message.DepartmentOreders;

namespace Hephaestus.Visirovka
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IClaimVM))]
    public class ClaimVM : IClaimVM, INotifyPropertyChanged
    {
        #region Event
        public event Action<ClaimChangedMessage> ClaimChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<IModule> UnloadMe;
        public event Action<IModule> Unloaded;
        public event Action<IModule> Unloading;
        #endregion

        #region VAR

        /// <summary>
        ///     приватная переменная для ведения логов
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(ClaimVM));

        #region TargetStors

        public const string TargetStorsPropertyName = "TargetStors";

        private ObservableCollection<StoreGasStationOilDepot> _targetStors =
            new ObservableCollection<StoreGasStationOilDepot>();

        public ObservableCollection<StoreGasStationOilDepot> TargetStors
        {
            get { return _targetStors; }

            set
            {
                if (_targetStors == value)
                {
                    return;
                }


                _targetStors = value;
                OnPropertyChanged(TargetStorsPropertyName);
            }
        }

        #endregion



        #region BrowserString

        /// <summary>
        ///     The <see cref="BrowserString" /> property's name.
        /// </summary>
        public const string BrowserStringPropertyName = "BrowserString";

        private string _browserstring = "";

        /// <summary>
        ///     Sets and gets the BrowserString property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string BrowserString
        {
            get { return _browserstring; }

            set
            {
                if (_browserstring == value)
                {
                    return;
                }


                _browserstring = value;
                OnPropertyChanged(BrowserStringPropertyName);
            }
        }

        #endregion

        #region MaterialInfo

        /// <summary>
        ///     The <see cref="MaterialInfo" /> property's name.
        /// </summary>
        public const string MaterialInfoPropertyName = "MaterialInfo";

        private GOODSPARTY _MaterialInfo = new GOODSPARTY();

        /// <summary>
        ///     Sets and gets the MaterialInfo property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public GOODSPARTY MaterialInfo
        {
            get { return _MaterialInfo; }

            set
            {
                if (_MaterialInfo == value)
                {
                    return;
                }


                _MaterialInfo = value;
                OnPropertyChanged(MaterialInfoPropertyName);
            }
        }

        #endregion

        #region Claim

        /// <summary>
        ///     The <see cref="Claim" /> property's name.
        /// </summary>
        public const string ClaimPropertyName = "Claim";

        private UDOSight _claim;

        /// <summary>
        ///     Gets the Claim property.
        ///     Заявка
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public UDOSight Claim
        {
            get { return _claim; }

            private set
            {

                _claim = value;
                OnPropertyChanged("Claim");


            }
        }

        #endregion

        #region TovAgnCollection

        /// <summary>
        ///     The <see cref="TovAgnCollection" /> property's name.
        /// </summary>
        public const string TovAgnCollectionPropertyName = "TovAgnCollection";

        private ObservableCollection<Agnlist> _agnlists = new ObservableCollection<Agnlist>();

        /// <summary>
        ///     Sets and gets the TovAgnCollection property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public ObservableCollection<Agnlist> TovAgnCollection
        {
            get { return _agnlists; }
            set
            {
                if (_agnlists == value)
                    return;


                _agnlists = value;
                OnPropertyChanged(TovAgnCollectionPropertyName);
            }
        }

        #endregion


        #region IsBusy

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        #endregion

        private readonly IEventAggregator _eventAggregator;
        [Import]
        private IClaimV ClaimView;
        private IEventAggregator _mainEventAggregator;

        private object _region;
        private object _regionMenu;
        private string _title;
        private IBLVisirovkaCore _visingCore;

        [Import]
        public IUserRightsVisirovka UserRightsVisirovka { get; private set; }

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

        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
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



        //Fixme

        #endregion

        #region CTOR

        /// <summary>
        ///     Конструктор ViewModel
        /// </summary>
        public ClaimVM()
        {
            CreateClaimCommand = new DelegateCommand(ExecuteSaveClaimCommand, CanExecuteSaveClaimCommand);
            ConfirmClaimCommand = new DelegateCommand(ExecuteConfirmClaimCommand, CanExecuteConfirmClaimCommand);
            DeleteClaimCommand = new DelegateCommand(ExecuteDeleteClaimCommand, CanExecuteDeleteClaimCommand);
            UnConfirmClaimCommand = new DelegateCommand(ExecuteUnConfirmClaimCommand, CanExecuteUnConfirmClaimCommand);
            RejectClaimCommand = new DelegateCommand(ExecuteRejectClaimCommand, CanExecuteRejectClaimCommand);
            UnRejectClaimCommand = new DelegateCommand(ExecuteUnRejectClaimCommand, CanExecuteUnRejectClaimCommand);
            CloseClaimCommand = new DelegateCommand(ExecuteCloseClaimCommand, CanExecuteCloseClaimCommand);
            UnCloseClaimCommand = new DelegateCommand(ExecuteUnCloseClaimCommand, CanExecuteUnCloseClaimCommand);
            MakeProblemCommand = new DelegateCommand(ExecuteMakeProblemCommand, CanExecuteMakeProblemCommand);
            ResolvProblemClaimCommand = new DelegateCommand(ExecuteResolvProblemClaimCommand, CanExecuteResolvProblemClaimCommand);
            AnnulateClaimCommand = new DelegateCommand(ExecuteAnnulateClaimCommand, CanExecuteAnnulateClaimCommand);
            FillClaimByNnCommand = new DelegateCommand(ExecuteFillClaimByNnCommand, CanExecuteFillClaimByNnCommand);

        }

        void Claim_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            CreateClaimCommand.RaiseCanExecuteChanged();
            ConfirmClaimCommand.RaiseCanExecuteChanged();
            DeleteClaimCommand.RaiseCanExecuteChanged();
            UnConfirmClaimCommand.RaiseCanExecuteChanged();
            RejectClaimCommand.RaiseCanExecuteChanged();
            UnRejectClaimCommand.RaiseCanExecuteChanged();
            CloseClaimCommand.RaiseCanExecuteChanged();
            UnCloseClaimCommand.RaiseCanExecuteChanged();
            MakeProblemCommand.RaiseCanExecuteChanged();
            ResolvProblemClaimCommand.RaiseCanExecuteChanged();
            AnnulateClaimCommand.RaiseCanExecuteChanged();
        }

        public bool Init(IErrorHandler _errorHandler,IEventAggregator EventAggregator, IBLVisirovkaCore BLVisirovkaCore, IDocumentBase DocumentBase, UDOSight e)
        {
            _visingCore = BLVisirovkaCore;
            _mainEventAggregator = EventAggregator;
            ClaimView.DataContext = this;
            Claim = e;
            UserRightsVisirovka.Init(DocumentBase.User);

            Region = ClaimView;

            //Подписываемся на сообщение о взятии материалла
            _mainEventAggregator.GetEvent<TakeMaterialEvent>()
                                .Subscribe(
                                    message => { ExecuteTakeMaterialToClaimCommand((RemainMaterial)message.Material); });

            loadData();

            Claim.PropertyChanged += Claim_PropertyChanged;

            return true;
        }

        ~ClaimVM()
        {
            var d = 1;
        }

        #endregion

        #region COMMANDS

        #region ClearClaimCommand

        public DelegateCommand ClearClaimCommand { get; private set; }

        private void ExecuteClearClaimCommand()
        {

            Claim =
                new UDOSight
                    {
                        AgnlistTOV = new Agnlist(),
                        DepartmentOrder = new DepartmentOrder
                            {
                                Agnlist_ACC_AGENT =
                                    new Agnlist(),
                                Agnlist_AGENT =
                                    new Agnlist(),
                                StoreGasStationOilDepot =
                                    new StoreGasStationOilDepot(),
                                NameOfCurrency = new NameOfCurrency(),
                                DepartmentOrderSpecifacation =
                                    new List
                                        <DepartmentOrderSpecifacation>
                                        {
                                            new DepartmentOrderSpecifacation
                                                {
                                                    StoreGasStationOilDepot
                                                        =
                                                        new StoreGasStationOilDepot
                                                            (),
                                                    DICMUNT
                                                        =
                                                        new DICMUNT
                                                            (),
                                                    NomenclatureNumber
                                                        =
                                                        new NomenclatureNumber
                                                            (),
                                                    NOMENCL
                                                        =
                                                        new NOMENCL
                                                            (),
                                                    NOMMODIF
                                                        =
                                                        new NOMMODIF
                                                            ()
                                                }
                                        },
                                StaffingDivision_ACC_SUBDIV
                                    =
                                    new StaffingDivision(),
                                StaffingDivision_SUBDIV =
                                    new StaffingDivision(),
                            },
                    };
        }

        private bool CanExecuteClearClaimCommand()
        {
            return true;
        }

        #endregion

        #region FillClaimByNNCommand

        public DelegateCommand FillClaimByNnCommand { get; private set; }


        private void ExecuteFillClaimByNnCommand()
        {
            string nn =
                ((DepartmentOrderSpecifacation)Claim.DepartmentOrder.DepartmentOrderSpecifacation[0])
                    .NomenclatureNumber.NOMENCODE;



            if (nn != null)
            {
            

                #region Ищим товароведа
                var service = new wscMatNormSoapClient();
                string tovaroved = service.get_inf_tovaroved(nn).Tables[0].Rows[0]["OTV"].ToString();
                service.Close();
                SelectAgnTovByFIO(tovaroved);
                #endregion
                OnPropertyChanged("Claim");
            }
        }

        private bool CanExecuteFillClaimByNnCommand()
        {
            return Claim.RN == 0;
        }

        #endregion

        #region CreateClaimCommand

        public DelegateCommand CreateClaimCommand { get; private set; }


        private void ExecuteSaveClaimCommand()
        {
            bool isNew = Claim.RN == 0;
            Claim = _visingCore.Save(Claim);
            if (Claim != null && Claim.RN != 0)
            {

                OnPropertyChanged(ClaimPropertyName);
                string message = "Заявка №" + Claim.DepartmentOrder.ORDPREF.Replace(" ", "") + "-" +
                                 Claim.DepartmentOrder.ORDNUMB.Replace(" ", "") + " сохранена успешно!";
                //отправим всем сообщение что была сохранена заявка

#if Release
                if (isNew)
                {
                    ServiceCore.MakeMail(claim);
                    ServiceCore.MakeRss(claim);
                }
#endif
                var msg = new ClaimChangedMessage
                    {
                        Action = isNew ? ClaimChangedMessage.Create : ClaimChangedMessage.Update,
                        Caption = "Сохранение",
                        Claim = Claim,
                        Message = message
                    };
                _mainEventAggregator.GetEvent<ClaimChangedEvent>().Publish(msg);

                OnClaimChanged(msg);
                Unload();
            }
        }

        private bool CanExecuteSaveClaimCommand()
        {

            if (Claim == null) return false;
            string nomencode = "";
            string nomenname = "";
            decimal mainquant = 0;
            if (Claim.DepartmentOrder != null && Claim.DepartmentOrder.DepartmentOrderSpecifacation != null &&
                (Claim.DepartmentOrder.DepartmentOrderSpecifacation.Count > 0 &&
                 ((DepartmentOrderSpecifacation)Claim.DepartmentOrder.DepartmentOrderSpecifacation[0])
                     .NomenclatureNumber != null))
            {
                nomencode =
                    ((DepartmentOrderSpecifacation)Claim.DepartmentOrder.DepartmentOrderSpecifacation[0])
                        .NomenclatureNumber.NOMENCODE;
                nomenname =
                    ((DepartmentOrderSpecifacation)Claim.DepartmentOrder.DepartmentOrderSpecifacation[0])
                        .NomenclatureNumber.NOMENNAME;
                mainquant =
                    ((DepartmentOrderSpecifacation)Claim.DepartmentOrder.DepartmentOrderSpecifacation[0]).MAINQUANT;
            }
            bool flag = false;

            if (UserRightsVisirovka.IsCreator)
                if (Claim.STATE == UDOSightSTATE.NotConfirmed)
                    flag = true;
            if (UserRightsVisirovka.CentralWarehouseStorekeeper)
                if (Claim.STATE == UDOSightSTATE.Confirmed)
                    flag = true;
            bool res = (flag && mainquant > 0 &&
                    !string.IsNullOrWhiteSpace(Claim.AgnlistTOV != null
                                                   ? Claim.AgnlistTOV.AGNNAME
                                                   : "") &&
                    !string.IsNullOrWhiteSpace(nomencode) &&
                    !string.IsNullOrWhiteSpace(nomenname) &&
                    !string.IsNullOrWhiteSpace(Claim.URGENTLY)) &&
                   !string.IsNullOrWhiteSpace(Claim.DOPUSK);

            return res;
        }

        #endregion

        #region DeleteClaimCommand

        public DelegateCommand DeleteClaimCommand { get; private set; }


        private void ExecuteDeleteClaimCommand()
        {

            //если вернулься нул то значит заявка удалилась
            UDOSight claim = _visingCore.Delete(Claim);

            if (claim == null)
            {
                var message = new ClaimChangedMessage
                    {
                        Action = ClaimChangedMessage.Remove,
                        Caption = "Удалено",
                        Message = "Заявка была удалена"
                    };
                //сообщим всем что заявка была удалена
                _mainEventAggregator.GetEvent<ClaimChangedEvent>()
                                    .Publish(message);
                OnClaimChanged(message);
                _mainEventAggregator.GetEvent<ReloadDataEvent>().Publish(null);
                Unload();

            }
        }

        private bool CanExecuteDeleteClaimCommand()
        {

            return Claim != null && Claim.STATE == UDOSightSTATE.NotConfirmed && Claim.RN != 0;
        }

        #endregion

        #region ConfirmClaimCommand

        public DelegateCommand ConfirmClaimCommand { get; private set; }


        private void ExecuteConfirmClaimCommand()
        {
            UDOSightSTATE privstate = Claim.STATE;
            Claim = _visingCore.Save(Claim);

            //установим новый статус
            Claim.STATE = UDOSightSTATE.Confirmed;
            Claim = _visingCore.SetState(Claim);

            if (Claim != null && Claim.STATE == UDOSightSTATE.Confirmed)
            {

                OnPropertyChanged(ClaimPropertyName);
                var message = new ClaimChangedMessage
                    {
                        Action = ClaimChangedMessage.Confirm,
                        Claim = Claim,
                        Caption = "Утверждено",
                        Message =
                            "Заявка №" + Claim.DepartmentOrder.ORDPREF.Replace(" ", "") + "-" +
                            Claim.DepartmentOrder.ORDNUMB.Replace(" ", "") + " была утверждена"
                    };
                //отправим всем сообщение что была сохранена заявка
                _mainEventAggregator.GetEvent<ClaimChangedEvent>()
                                    .Publish(message);
                OnClaimChanged(message);
                Unload();
            }
            else
            {
                //вернем предыдущий статус
                Claim.STATE = privstate;
                OnPropertyChanged(ClaimPropertyName);
            }
        }

        private bool CanExecuteConfirmClaimCommand()
        {
            return Claim != null && Claim.RN != 0 &&
                   (Claim.STATE == UDOSightSTATE.NotConfirmed || Claim.STATE == UDOSightSTATE.Problem ||
                    Claim.STATE == UDOSightSTATE.Closed) && Claim.ALLOWQUANT > 0;
        }

        #endregion

        #region UnConfirmClaimCommand

        public DelegateCommand UnConfirmClaimCommand { get; private set; }


        private void ExecuteUnConfirmClaimCommand()
        {
            UDOSightSTATE privstate = Claim.STATE;
            //сначала сохраним текущее состояние
            Claim = _visingCore.Save(Claim);

            //установим новый статус
            Claim.STATE = UDOSightSTATE.NotConfirmed;
            Claim = _visingCore.SetState(Claim);
            if (Claim != null && Claim.STATE == UDOSightSTATE.NotConfirmed && Claim.RN != 0)
            {

                OnPropertyChanged(ClaimPropertyName);
                var message = new ClaimChangedMessage
                    {
                        Action = ClaimChangedMessage.UnConfirm,
                        Claim = Claim,
                        Caption = "Отмена утверждения",
                        Message =
                            "С заявки №" + Claim.DepartmentOrder.ORDPREF.Replace(" ", "") + "-" +
                            Claim.DepartmentOrder.ORDNUMB.Replace(" ", "") + " снято утверждение"
                    };
                //отправим всем сообщение что была сохранена заявка
                _mainEventAggregator.GetEvent<ClaimChangedEvent>().Publish(message);
                OnClaimChanged(message);
                Unload();
            }
            else
            {
                Claim.STATE = privstate;
                OnPropertyChanged(ClaimPropertyName);
            }
        }

        private bool CanExecuteUnConfirmClaimCommand()
        {
            return Claim != null && Claim.STATE == UDOSightSTATE.Confirmed && Claim.RN != 0;
        }
        #endregion

        #region RejectClaimCommand

        public DelegateCommand RejectClaimCommand { get; private set; }


        private void ExecuteRejectClaimCommand()
        {
            UDOSightSTATE privstate = Claim.STATE;
            Claim = _visingCore.Save(Claim);

            Claim.STATE = UDOSightSTATE.Rejected;
            Claim = _visingCore.SetState(Claim);

            if (Claim != null && Claim.STATE == UDOSightSTATE.Rejected && Claim.RN != 0)
            {

                OnPropertyChanged(ClaimPropertyName);
                var message = new ClaimChangedMessage
                    {
                        Action = ClaimChangedMessage.Reject,
                        Claim = Claim,
                        Caption = "Отклонение",
                        Message =
                            "Заявка №" + Claim.DepartmentOrder.ORDPREF.Replace(" ", "") + "-" +
                            Claim.DepartmentOrder.ORDNUMB.Replace(" ", "") + " отклонена"
                    };
                //отправим сообщение что заявка была отклонена
                _mainEventAggregator.GetEvent<ClaimChangedEvent>().Publish(message);
                OnClaimChanged(message);
                Unload();
            }
            else
            {
                Claim.STATE = privstate;
                OnPropertyChanged(ClaimPropertyName);
            }
        }

        private bool CanExecuteRejectClaimCommand()
        {
            return Claim != null && Claim.RN != 0 && Claim.STATE == UDOSightSTATE.NotConfirmed
                   && !string.IsNullOrWhiteSpace(Claim.COMMENTTOVFORCEX);
        }

        #endregion

        #region UnRejectClaimCommand

        public DelegateCommand UnRejectClaimCommand { get; private set; }


        private void ExecuteUnRejectClaimCommand()
        {
            Claim = _visingCore.Save(Claim);
            UDOSightSTATE privstate = Claim.STATE;
            Claim.STATE = UDOSightSTATE.NotConfirmed;
            Claim = _visingCore.SetState(Claim);

            if (Claim != null && Claim.STATE == UDOSightSTATE.NotConfirmed && Claim.RN != 0)
            {

                OnPropertyChanged(ClaimPropertyName);
                var message = new ClaimChangedMessage
                    {
                        Action = ClaimChangedMessage.UnReject,
                        Claim = Claim,
                        Caption = "Отмена отклонения",
                        Message =
                            "С заявки №" + Claim.DepartmentOrder.ORDPREF.Replace(" ", "") + "-" +
                            Claim.DepartmentOrder.ORDNUMB.Replace(" ", "") + " снято отклонение"
                    };
                //отправим сообщение что заявка была отклонена
                _mainEventAggregator.GetEvent<ClaimChangedEvent>().Publish(message);
                OnClaimChanged(message);
                Unload();
            }
            else
            {
                Claim.STATE = privstate;
                OnPropertyChanged(ClaimPropertyName);
            }
        }

        private bool CanExecuteUnRejectClaimCommand()
        {
            return Claim != null && Claim.RN != 0 && Claim.STATE == UDOSightSTATE.Rejected;
        }

        #endregion

        #region CloseClaimCommand

        public DelegateCommand CloseClaimCommand { get; private set; }


        private void ExecuteCloseClaimCommand()
        {
            UDOSightSTATE privstate = Claim.STATE;
            //сохранием изменения в заявке
            Claim = _visingCore.Save(Claim);
            //изменим состаяние на закрытый
            Claim.STATE = UDOSightSTATE.Closed;
            Claim = _visingCore.SetState(Claim);

            if (Claim != null && Claim.STATE == UDOSightSTATE.Closed && Claim.RN != 0)
            {

                OnPropertyChanged(ClaimPropertyName);
                var message = new ClaimChangedMessage
                    {
                        Action = ClaimChangedMessage.Close,
                        Claim = Claim,
                        Caption = "Закрыте",
                        Message =
                            "Заявка №" + Claim.DepartmentOrder.ORDPREF.Replace(" ", "") + "-" +
                            Claim.DepartmentOrder.ORDNUMB.Replace(" ", "") + " закрыта"
                    };
                //отправим сообщение что заявка была закрыта
                _mainEventAggregator.GetEvent<ClaimChangedEvent>().Publish(message);
                OnClaimChanged(message);
                Unload();
            }
            else
            {
                Claim.STATE = privstate;
                OnPropertyChanged(ClaimPropertyName);
            }
        }

        private bool CanExecuteCloseClaimCommand()
        {
            return Claim != null && Claim.RN != 0 && Claim.STATE == UDOSightSTATE.Confirmed;
        }

        #endregion

        #region UnCloseClaimCommand

        public DelegateCommand UnCloseClaimCommand { get; private set; }


        private void ExecuteUnCloseClaimCommand()
        {
            //сохранием изменения в заявке
            Claim = _visingCore.Save(Claim);
            UDOSightSTATE privstate = Claim.STATE;
            //изменим состаяние на закрытый
            Claim.STATE = UDOSightSTATE.Confirmed;
            Claim = _visingCore.SetState(Claim);

            if (Claim != null && Claim.STATE == UDOSightSTATE.Confirmed)
            {
                Claim = Claim;
                OnPropertyChanged(ClaimPropertyName);
                var message = new ClaimChangedMessage { Action = ClaimChangedMessage.Open, Claim = Claim };
                //отправим сообщение что заявка была закрыта
                _mainEventAggregator.GetEvent<ClaimChangedEvent>().Publish(message);
                OnClaimChanged(message);
                Unload();
            }
            else
            {
                Claim.STATE = privstate;
                OnPropertyChanged(ClaimPropertyName);
            }
        }

        private bool CanExecuteUnCloseClaimCommand()
        {
            return Claim != null && Claim.RN != 0 && Claim.STATE == UDOSightSTATE.Closed;
        }

        #endregion

        #region MakeProblemCommand

        public DelegateCommand MakeProblemCommand { get; private set; }


        private void ExecuteMakeProblemCommand()
        {
            UDOSightSTATE privstate = Claim.STATE;
            Claim = _visingCore.Save(Claim);

            Claim.STATE = UDOSightSTATE.Problem;
            Claim = _visingCore.SetState(Claim);

            if (Claim != null && Claim.STATE == UDOSightSTATE.Problem && Claim.RN != 0)
            {
                Claim = Claim;
                OnPropertyChanged(ClaimPropertyName);
                var message = new ClaimChangedMessage
                    {
                        Action = ClaimChangedMessage.Problem,
                        Claim = Claim,
                        Caption = "Проблемная",
                        Message =
                            "Заявка №" + Claim.DepartmentOrder.ORDPREF.Replace(" ", "") + "-" +
                            Claim.DepartmentOrder.ORDNUMB.Replace(" ", "") + " отмечена как проблемная"
                    };
                //отправим сообщение что заявка Проблемная
                _mainEventAggregator.GetEvent<ClaimChangedEvent>().Publish(message);
                OnClaimChanged(message);
                Unload();
            }
            else
            {
                Claim.STATE = privstate;
                OnPropertyChanged(ClaimPropertyName);
            }
        }

        private bool CanExecuteMakeProblemCommand()
        {
            return Claim != null && Claim.RN != 0 && Claim.STATE == UDOSightSTATE.Confirmed;
        }

        #endregion

        #region ResolvProblemClaimCommand

        public DelegateCommand ResolvProblemClaimCommand { get; private set; }


        private void ExecuteResolvProblemClaimCommand()
        {
            Claim = _visingCore.Save(Claim);
            UDOSightSTATE privstate = Claim.STATE;

            Claim = _visingCore.SetState(Claim);

            if (Claim != null && Claim.STATE == UDOSightSTATE.Confirmed && Claim.RN != 0)
            {
                Claim = Claim;
                OnPropertyChanged(ClaimPropertyName);
                var message = new ClaimChangedMessage
                    {
                        Action = ClaimChangedMessage.ResolvProblem,
                        Claim = Claim,
                        Caption = "Проблема решена",
                        Message =
                            "С заявки №" + Claim.DepartmentOrder.ORDPREF.Replace(" ", "") + "-" +
                            Claim.DepartmentOrder.ORDNUMB.Replace(" ", "") + " снято утверждение"
                    };
                //отправим сообщение что заявка Проблемная
                _mainEventAggregator.GetEvent<ClaimChangedEvent>().Publish(message);
                OnClaimChanged(message);
                Unload();
            }
            else
            {
                Claim.STATE = privstate;
                OnPropertyChanged(ClaimPropertyName);
            }
        }

        private bool CanExecuteResolvProblemClaimCommand()
        {
            return Claim != null && Claim.RN != 0 && Claim.STATE == UDOSightSTATE.Problem;
        }

        #endregion

        #region AnnulateClaimCommand

        public DelegateCommand AnnulateClaimCommand { get; private set; }


        private void ExecuteAnnulateClaimCommand()
        {
            UDOSightSTATE privstate = Claim.STATE;
            Claim = _visingCore.Save(Claim);
            Claim.STATE = UDOSightSTATE.Annulated;
            Claim = _visingCore.SetState(Claim);

            if (Claim != null && Claim.STATE == UDOSightSTATE.Annulated && Claim.RN != 0)
            {
                Claim = Claim;
                OnPropertyChanged(ClaimPropertyName);
                var message = new ClaimChangedMessage
                    {
                        Action = ClaimChangedMessage.Annulate,
                        Claim = Claim,
                        Caption = "Аннулирование",
                        Message =
                            "Заявка №" + Claim.DepartmentOrder.ORDPREF.Replace(" ", "") + "-" +
                            Claim.DepartmentOrder.ORDNUMB.Replace(" ", "") + " аннулирована"
                    };
                //отправим сообщение что заявка аннулирована
                _mainEventAggregator.GetEvent<ClaimChangedEvent>().Publish(message);
                OnClaimChanged(message);
                Unload();
            }
            else
            {
                Claim.STATE = privstate;
                OnPropertyChanged(ClaimPropertyName);
            }
        }

        private bool CanExecuteAnnulateClaimCommand()
        {
            return Claim != null && Claim.RN != 0 && Claim.STATE == UDOSightSTATE.Problem;
        }

        #endregion

        #region FillGoodsManagerListCommand

        public DelegateCommand<UDOSight> FillGoodsManagerListCommand { get; private set; }

        #endregion

        #region TakeMaterialToClaimCommand

        public DelegateCommand<RemainMaterial> TakeMaterialToClaimCommand { get; private set; }


        private void ExecuteTakeMaterialToClaimCommand(RemainMaterial matinfo)
        {
            //обозначим материал
            ((DepartmentOrderSpecifacation)Claim.DepartmentOrder.DepartmentOrderSpecifacation[0]).NomenclatureNumber =
                matinfo.Parent.NOMMODIF.NomenclatureNumber;
            ((DepartmentOrderSpecifacation)Claim.DepartmentOrder.DepartmentOrderSpecifacation[0]).NOMMODIF =
                matinfo.Parent.NOMMODIF;
            ((DepartmentOrderSpecifacation)Claim.DepartmentOrder.DepartmentOrderSpecifacation[0]).DICMUNT =
                matinfo.Parent.NOMMODIF.NomenclatureNumber.DICMUNT_UMEAS_MAIN;
            var gs = new GOODSSUPPLY();
            foreach (GOODSSUPPLY item in matinfo.Parent.GOODSSUPPLIES)
            {
                if (item.RN == matinfo.RN)
                {
                    gs = item;
                    break;
                }
            }

            ((DepartmentOrderSpecifacation)Claim.DepartmentOrder.DepartmentOrderSpecifacation[0])
                .StoreGasStationOilDepot = gs.StoreGasStationOilDepot;

            Claim.DepartmentOrder.StoreGasStationOilDepot = gs.StoreGasStationOilDepot;

            FillClaimByNnCommand.Execute();

        }

        private bool CanExecuteTakeMaterialToClaimCommand(RemainMaterial matinfo)
        {
            //выбирать материал можно столи при начальном состоянии заявки
            return matinfo != null && matinfo.RN != 0 && Claim != null && Claim.RN == 0 && Claim.STATE == 0;
        }

        #endregion



        #region SetAllowQuantCommand

        public DelegateCommand<UDOSight> SetAllowQuantCommand { get; private set; }

        private void ExecuteSetAllowQuantCommand(UDOSight claim)
        {
            Claim.ALLOWQUANT =
                ((DepartmentOrderSpecifacation)Claim.DepartmentOrder.DepartmentOrderSpecifacation[0]).MAINQUANT;
            OnPropertyChanged(ClaimPropertyName);
        }

        private bool CanExecuteSetAllowQuantCommand(UDOSight claim)
        {
            return claim != null && claim.RN != 0 && (claim.STATE == UDOSightSTATE.NotConfirmed);
        }

        #endregion

        #region GiveOutMaterialToClaimCommand

        public DelegateCommand<RemainMaterial> GiveOutMaterialToClaimCommand { get; private set; }


        private void ExecuteGiveOutMaterialToClaimCommand(RemainMaterial remainMaterial)
        {
            if (Claim.ALLOWQUANT < (Claim.ISSUEDQUANT + remainMaterial.Gift))
            {
                if (MessageBox.Show(
                    "Внимание итоговое количество выданного материала (" +
                    (Claim.ISSUEDQUANT + remainMaterial.Gift).ToString(CultureInfo.InvariantCulture) + "" +
                    ((DepartmentOrderSpecifacation)Claim.DepartmentOrder.DepartmentOrderSpecifacation[0])
                        .NomenclatureNumber.DICMUNT_UMEAS_MAIN.MEASMNEMO + ") превышает количество завизированного (" +
                    Claim.ALLOWQUANT + "" +
                    ((DepartmentOrderSpecifacation)Claim.DepartmentOrder.DepartmentOrderSpecifacation[0])
                        .NomenclatureNumber.DICMUNT_UMEAS_MAIN.MEASMNEMO +
                    ")." + Environment.NewLine + "Продолжить?", "ВНИМАНИЕ", MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.No)
                    return;
            }

            GOODSPARTY goodsparty = remainMaterial.Parent;
            var goodssuply = new GOODSSUPPLY();
            foreach (
                GOODSSUPPLY g in
                    from object item in goodsparty.GOODSSUPPLIES
                    select item as GOODSSUPPLY
                        into g
                        where g.RN == remainMaterial.RN
                        select g)
            {
                goodssuply = g;
            }

            var tranceindept = new InvoiceForTransmissionInUnit
                {
                    StoreGasStationOilDepot_STORE = goodssuply.StoreGasStationOilDepot,
                    InvoiceForTransmissionInUnitSPECs = new List<InvoiceForTransmissionInUnitSPEC>
                        {
                            new InvoiceForTransmissionInUnitSPEC
                                {
                                    GOODSPARTY = goodsparty,
                                    QUANT = remainMaterial.Gift,
                                    NOMMODIF = goodsparty.NOMMODIF
                                }
                        },
                    FACEACC = new FACEACC { NUMB = remainMaterial.FACEACCENUMBER },
                    KindOfWarehouseOperations_STOPER =
                        new KindOfWarehouseOperations { GSMWAYSMNEMO = remainMaterial.OperationNumber }
                };
            IsBusy = true;
            Observable.ToAsync(() => tranceindept = _visingCore.SaveTran(tranceindept, Claim)
                )()
                .ObserveOnDispatcher()
                .Subscribe(x =>
                    {
                        IsBusy = false;
                        if (tranceindept.RN != 0)
                        {
                            Claim = _visingCore.RecalculationIssuedQuant(Claim);


                            if (TransInvDepListRNs.RNs == null)
                            {
                                TransInvDepListRNs.RNs = new ObservableCollection<long> { tranceindept.RN };
                            }

                            OnClaimChanged(new ClaimChangedMessage
                                {
                                    Action = ClaimChangedMessage.GiveOutMaterial,
                                    Caption = "Выдача материала",
                                    Claim = Claim,
                                    Message = "Расходная накладная №" + tranceindept.PREF + "-" + tranceindept.NUMB
                                });
                        }
                    });
        }

        private bool CanExecuteGiveOutMaterialToClaimCommand(RemainMaterial material)
        {
            return Claim != null && Claim.RN != 0 &&
                   (Claim.STATE == UDOSightSTATE.Confirmed || Claim.STATE == UDOSightSTATE.Confirmed) &&
                   material != null;
        }

        #endregion

        #endregion

        #region Methot

        public bool Unload()
        {
            Claim.PropertyChanged -= Claim_PropertyChanged;
            if (Unloaded != null) Unloaded(this);
            return true;
        }

        private void loadData()
        {
            Observable.ToAsync(
              () =>
              {
                  IsBusy = true;
                  if ((Claim.RN == 0) || (Claim.STATE == UDOSightSTATE.NotConfirmed))
                  {
                      TovAgnCollection = new ObservableCollection<Agnlist>(_visingCore.GetTovAgnlist(new FAgnlist()));

                      TargetStors =
                          new ObservableCollection<StoreGasStationOilDepot>(
                              _visingCore.GetStoreGasStationOilDepotOfStaffingDivision().OrderBy(x => x.AZSNUMBER));

                      var tempStore = TargetStors.Where(x => x.RN == (Claim.INSTORE != null ? Claim.INSTORE.RN : 0)).FirstOrDefault();
                      if (tempStore != null)
                      {
                          Claim.INSTORE = tempStore;
                      }
                      var tempTovAgnCollection = TovAgnCollection.Where(x => x.RN == Claim.AgnlistTOV.RN).FirstOrDefault();
                      if (tempTovAgnCollection != null)
                      {
                          Claim.AgnlistTOV = tempTovAgnCollection;
                      }
                  }
                  else
                  {
                      TovAgnCollection.Add(Claim.AgnlistTOV);
                      TargetStors.Add(Claim.INSTORE);
                  }
              })()
              .ObserveOnDispatcher()
              .Subscribe(x =>
              {

                  IsBusy = false;
              });



        }
        /// <summary>
        ///     Обновить свойство
        /// </summary>
        /// <param name="propertyname">имя свойства</param>
        public void UpdateProperty(string propertyname)
        {
            OnPropertyChanged(propertyname);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler h = PropertyChanged;
            if (h != null)
                h(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     Выбрать товароведа по его идентификатору
        /// </summary>
        public void SelectAgnTovByRn()
        {
            if (Claim == null || Claim.AgnlistTOV == null) return;
            foreach (Agnlist tovaroved in TovAgnCollection.Where(tovaroved => Claim.AgnlistTOV.RN == tovaroved.RN))
            {
                Claim.AgnlistTOV = tovaroved;
                OnPropertyChanged("Claim");
                break;
            }
        }

        /// <summary>
        ///     Выбрать товароведа по ФИО
        /// </summary>
        /// <param name="fio">ФИО товароведа</param>
        private void SelectAgnTovByFIO(string fio)
        {
            if (Claim == null || Claim.AgnlistTOV == null) return;
            foreach (Agnlist tovaroved in TovAgnCollection.Where(tovaroved => fio.ToUpper() == tovaroved.AGNNAME.ToUpper()))
            {
                Claim.AgnlistTOV = tovaroved;
                OnPropertyChanged(ClaimPropertyName);
                break;
            }

        }



        public void OnClaimChanged(ClaimChangedMessage message)
        {
            Action<ClaimChangedMessage> handler = ClaimChanged;
            if (handler != null) handler(message);
        }

        #endregion
    }
}