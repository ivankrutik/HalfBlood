using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Net;
using System.Text;
using System.Windows;
using Hephaestus.Infrastructure.Interface;
using Hephaestus.Infrastructure.Message;
using Hephaestus.Infrastructure.Message.DepartmentOreders;
using Hephaestus.Infrastructure.Message.InvoiceForTransmissionInUnit;
using Hephaestus.Visirovka.Class;
using Hephaestus.Visirovka.Infrastructure;
using Hephaestus.Visirovka.Infrastructure.Message;
using Hephaestus.Visirovka.Interface;
using Microsoft.Practices.Prism.Events;
using ParusModel;
using ParusModel.Filter;

namespace Hephaestus.Visirovka.ViewModels
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IEditClaimVM))]
    public class EditClaimVM : IEditClaimVM, IHeadered, INotifyPropertyChanged
    {
        #region Event

        public event Action<IModule> UnloadMe;

        public event Action<IModule> Unloaded;

        public event Action<IModule> Unloading;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region VAR

        private IErrorHandler _errorHandler;
        private readonly IEventAggregator _eventAggregator = new EventAggregator();
        [Import]
        private IClaimVM _claimVM;
        private IDocumentBase _defaultDocument;

        [Import]
        private IDepartmentOrederVM _departmentOredersVM;
        [Import]
        private IEditClaimV _editClaimV;
        [Import]
        private IInvoiceForTransmissionInUnitVM _invoiceForTransmissionInUnitVM;
        [Import]
        private IClaimHistoryVM _claimHistoryVM;

        private IEventAggregator _mainEventAggregator;
        private object _region;
        private object _regionMenu;
        [Import]
        private IRemainMaterialsVM _remainMaterialsVM;

        private string _title;
        private IBLVisirovkaCore _visingCore;
        private IBootStrapper _сomp;


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



        private UDOSight _sight
        {
            get;
            set;
        }

        #region --- ClaimV --- Заявка на визировку основные данные

        /// <summary>
        ///     The <see cref="ClaimVRegion" /> property's name.
        /// </summary>
        public const string ClaimVMPropertyName = "ClaimV";

        private Object _claimV;

        /// <summary>
        ///     Sets and gets the ClaimView property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public Object ClaimVRegion
        {
            get { return _claimV; }

            set
            {
                if (_claimV == value)
                {
                    return;
                }


                _claimV = value;
                OnPropertyChanged(ClaimVMPropertyName);
            }
        }

        #endregion

        #region --- RemainMaterialsVM --- остатки материала по складам

        /// <summary>
        ///     The <see cref="RemainMaterialVRegion" /> property's name.
        /// </summary>
        public const string RemainMaterialViewPropertyName = "RemainMaterialVM";

        private object _remainMaterial;

        /// <summary>
        ///     Sets and gets the RemainMaterialView property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public object RemainMaterialVRegion
        {
            get { return _remainMaterial; }

            set
            {
                if (_remainMaterial == value)
                {
                    return;
                }


                _remainMaterial = value;
                OnPropertyChanged(RemainMaterialViewPropertyName);
            }
        }

        #endregion

        #region --- GivesView --- выдачи материала по зявке

        /// <summary>
        ///     The <see cref="InvoiceForTransmissionInUnitVRegion" /> property's name.
        /// </summary>
        public const string GivesViewPropertyName = "GivesVM";

        private object _givesVM;

        /// <summary>
        ///     Sets and gets the GivesView property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public object InvoiceForTransmissionInUnitVRegion
        {
            get { return _givesVM; }

            set
            {
                if (_givesVM == value)
                {
                    return;
                }


                _givesVM = value;
                OnPropertyChanged(GivesViewPropertyName);
            }
        }

        #endregion

        #region --- DepartmentOredersVRegion --- история визировки

        /// <summary>
        ///     The <see cref="DepartmentOredersVRegion" /> property's name.
        /// </summary>
        public const string DepartmentOredersViewPropertyName = "DepartmentOredersVRegion";
        private object _departmentOredersVRegion;
        public object DepartmentOredersVRegion
        {
            get { return _departmentOredersVRegion; }

            set
            {
                if (_departmentOredersVRegion == value || value == null)
                {
                    return;
                }


                _departmentOredersVRegion = value;
                OnPropertyChanged(DepartmentOredersViewPropertyName);
            }
        }

        #endregion

        #region --- DepartmentOredersVRegion --- история изменения заявки

        /// <summary>
        ///     The <see cref="RevisionHistoryClaimVRegion" /> property's name.
        /// </summary>
        public const string RevisionHistoryClaimVRegionPropertyName = "RevisionHistoryClaimVRegion";

        private object _revisionHistoryClaimVRegion;
        public object RevisionHistoryClaimVRegion
        {
            get { return _revisionHistoryClaimVRegion; }

            set
            {
                if (_revisionHistoryClaimVRegion == value || value == null)
                {
                    return;
                }


                _revisionHistoryClaimVRegion = value;
                OnPropertyChanged(RevisionHistoryClaimVRegionPropertyName);
            }
        }




        #endregion
        #region NavigateStringDemand

        /// <summary>
        ///     The <see cref="NavigateStringDemand" /> property's name.
        /// </summary>
        public const string NavigateStringDemandPropertyName = "NavigateStringDemand";

        private string _navigateStringDemand = @"http://kts.vz/MAT_POTR_WEB/wfm_Def_Mat.aspx";

        /// <summary>
        ///     Sets and gets the NavigateStringDemand property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string NavigateStringDemand
        {
            get { return _navigateStringDemand; }

            set
            {
                if (_navigateStringDemand == value)
                {
                    return;
                }


                _navigateStringDemand = value;
                OnPropertyChanged(NavigateStringDemandPropertyName);
            }
        }

        #endregion

        #region NavigateStringDemandExtended

        /// <summary>
        ///     The <see cref="NavigateStringDemandExtended" /> property's name.
        /// </summary>
        public const string NavigateStringDemandExtendedPropertyName = "NavigateStringDemandExtended";

        private string _navigateStringDemandExtended = @"http://kts.vz/MAT_POTR_WEB/wfm_Def_003.aspx";

        /// <summary>
        ///     Sets and gets the NavigateStringDemandExtended property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string NavigateStringDemandExtended
        {
            get { return _navigateStringDemandExtended; }

            set
            {
                if (_navigateStringDemandExtended == value)
                {
                    return;
                }


                _navigateStringDemandExtended = value;
                OnPropertyChanged(NavigateStringDemandExtendedPropertyName);
            }
        }

        #endregion

        private byte[] _htmlBody;
        public Byte[] HtmlBody
        {
            get { return _htmlBody; }
            set { _htmlBody = value; OnPropertyChanged("HtmlBody"); }
        }

        #region --== Rights ==--

        /// <summary>
        ///     The <see cref="Rights" /> property's name.
        /// </summary>
        public const string RightsPropertyName = "Rights";

        private UserSettings _rights = new UserSettings();

        /// <summary>
        ///     Sets and gets the Rights property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public UserSettings Rights
        {
            get { return _rights; }

            set
            {
                if (_rights == value)
                {
                    return;
                }


                _rights = value;
                //object(RightsPropertyName);
            }
        }

        #endregion

        #region Header

        /// <summary>
        ///     The <see cref="Header" /> property's name.
        /// </summary>
        public const string HeaderPropertyName = "Header";

        private object _header = "";


        /// <summary>
        ///     Sets and gets the Header property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public object Header
        {
            get { return _header; }

            set
            {
                if (_header == value)
                {
                    return;
                }

                //  RaisePropertyChanging(HeaderPropertyName);
                _header = value;
                //  RaisePropertyChanged(HeaderPropertyName);
            }
        }

        #endregion

        #endregion

        #region CTOR


        public bool Init(IErrorHandler errorHandler,IEventAggregator EventAggregator, IDocumentBase DefaultDocument, IBootStrapper Comp,
                         IBLVisirovkaCore BLVisirovkaCore, UDOSight Sight)
        {
            _errorHandler = errorHandler;
            _mainEventAggregator = EventAggregator;
            _сomp = Comp;
            _defaultDocument = DefaultDocument;
            _visingCore = BLVisirovkaCore;

            _sight = Sight;



            HtmlBody = _sight.WANTDATECREATE;
            _editClaimV.DataContext = this;
            Region = _editClaimV;

            //Устанавливаем ссылки на открытие окна браузера в подтрабности
            SetNavigateStringDemand();

            _claimVM.Init(_errorHandler, _eventAggregator, _visingCore, _defaultDocument, _sight);



            ClaimVRegion = _claimVM.Region;

            _remainMaterialsVM.Init(_errorHandler, _eventAggregator, _visingCore, _сomp, _defaultDocument, _sight);
            RemainMaterialVRegion = _remainMaterialsVM.Region;

            _invoiceForTransmissionInUnitVM.Init(_errorHandler, _eventAggregator, _defaultDocument, false);
            InvoiceForTransmissionInUnitVRegion = _invoiceForTransmissionInUnitVM.Region;


            _departmentOredersVM.Init(_errorHandler, _eventAggregator, _defaultDocument, _сomp);
            DepartmentOredersVRegion = _departmentOredersVM.Region;
            _claimHistoryVM.Init(_errorHandler, _eventAggregator, _visingCore, _defaultDocument, _sight);
            RevisionHistoryClaimVRegion = _claimHistoryVM.Region;

            _claimVM.Unloaded += _claimVM_Unloaded;

            if (_sight.RN != 0)
            {
                //посылаем сообщение загрузить расходные накладные на оипуск в подразделение
                _eventAggregator.GetEvent<SavingNewInvoiceForTransmissionInUnitEvent>().Publish(new RelationshipBetweenDocuments { INDOCUMENT = _sight.DepartmentOrder.RN, INUNITCODE = "DepartmentsOrders" });
                //посылаем сообщение загрузить заявки по номенклатурному номеру
                var x = (Sight.DepartmentOrder != null ? (((DepartmentOrderSpecifacation)Sight.DepartmentOrder.DepartmentOrderSpecifacation[0]).NomenclatureNumber.NOMENCODE ?? "") : "");
                _eventAggregator.GetEvent<FindUDOSightEvent>().Publish(new FUDOSight { DepartmentOrder = new FDepartmentOrder { ORDSTATE = ParusModel.DepartmentOrder.DepartmentOrderState.All, DepartmentOrderSpecifacations = new FDepartmentOrderSpecifacation { NomenclatureNumber = new FNomenclatureNumber { NOMENCODE = x } } }, AgnlistTOV = new FAgnlist { RN = new List<long>() }, STATE = new List<UDOSightSTATE>(), RN = new List<long?>() });
            }
            //подписываемся на сообщение о взятие материала что бы загрузить потребность
            _eventAggregator.GetEvent<TakeMaterialEvent>().Subscribe(message => { TakeMaterials((RemainMaterial)message.Material); });
            return true;
        }

        private void SetNavigateStringDemand()
        {

            if (_sight != null && _sight.DepartmentOrder != null &&
                _sight.DepartmentOrder.DepartmentOrderSpecifacation != null &&
                _sight.DepartmentOrder.DepartmentOrderSpecifacation.Count > 0 &&
                ((DepartmentOrderSpecifacation)_sight.DepartmentOrder.DepartmentOrderSpecifacation[0])
                    .NomenclatureNumber != null)
            {
                NavigateStringDemand = @"http://kts.vz/MAT_POTR_WEB/wfm_Def_Mat.aspx?nn=" +
                                       ((DepartmentOrderSpecifacation)
                                        _sight.DepartmentOrder.DepartmentOrderSpecifacation[0])
                                           .NomenclatureNumber.NOMENCODE;
                NavigateStringDemandExtended = @"http://kts.vz/MAT_POTR_WEB/wfm_Def_003.aspx?nn=" +
                                               ((DepartmentOrderSpecifacation)
                                                _sight.DepartmentOrder.DepartmentOrderSpecifacation[0])
                                                   .NomenclatureNumber.NOMENCODE + "&Extended=1";
            }
            else
            {
                NavigateStringDemand = @"http://kts.vz/MAT_POTR_WEB/wfm_Def_Mat.aspx";
                NavigateStringDemandExtended = @"http://kts.vz/MAT_POTR_WEB/wfm_Def_003.aspx";
            }

        }

        void _claimVM_Unloaded(IModule obj)
        {
            _claimVM.Unloaded -= _claimVM_Unloaded;

            Unload();


        }




    


        #endregion

        #region Methot
        private void TakeMaterials(RemainMaterial arg)
        {
            //посылаем сообщение загрузить заявки по номенклатурному номеру
            var x = arg.SNOMEN;
            _eventAggregator.GetEvent<FindUDOSightEvent>().Publish(new FUDOSight {  DepartmentOrder = new FDepartmentOrder { ORDSTATE = ParusModel.DepartmentOrder.DepartmentOrderState.All, DepartmentOrderSpecifacations = new FDepartmentOrderSpecifacation { NomenclatureNumber = new FNomenclatureNumber { NOMENCODE = x } } }, AgnlistTOV = new FAgnlist { RN = new List<long>() }, STATE = new List<UDOSightSTATE>(), RN = new List<long?>() });

            //получим потребность
            //загружаем страницу и вырезаем нужное
            var browserData = GetReguirementOfMaterials(arg);
            //преобразуем в массив байт
            byte[] stream = new UTF8Encoding().GetBytes(browserData);
            _sight.WANTDATECREATE = stream;
            HtmlBody = _sight.WANTDATECREATE;

        }

        private static string GetReguirementOfMaterials(RemainMaterial arg)
        {
        
            var ffile = string.Format("http://kts.vz/MAT_POTR_WEB/wfm_Def_Mat.aspx?nn={0}", arg.SNOMEN);
            string dfile;
            int start, end;
            var client = new WebClient();
            using (client)
            {
                try
                {

                    client.UseDefaultCredentials = true;
                    dfile = client.DownloadString(ffile);
                    dfile = dfile.Replace("VBScript", " ");
                    start = dfile.IndexOf("id=\"DG_Mat\"", StringComparison.Ordinal);
                    start = dfile.IndexOf(">", start, StringComparison.Ordinal);
                    end = dfile.IndexOf("id=\"Label4\"", StringComparison.Ordinal);
                    end = dfile.IndexOf(">", end, StringComparison.Ordinal);
                    start++;
                    end++;
                }
                catch
                {
                    return
                        string.Format(
                            @"<head><meta http-equiv='Content-Language' content='ru-RU'><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'></head><div style='font-size: 10px;'><table><tr><td>{0}</td></tr></table></div>",
                            "Нет данных либо потребности в материалах нет. Проверьте правильность введенных данных.");
                }
                Encoding ascii = Encoding.Default;
                Encoding utf8 = Encoding.UTF8;
                byte[] one = ascii.GetBytes(dfile.Substring(start, end - start));
                string two = utf8.GetString(one);
                return
                    string.Format(
                        @"<head><meta http-equiv='Content-Language' content='ru-RU'><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'></head><div style='font-size: 10px;'><table><tr><td>{0}</td></tr></table></div>",
                        two);
            }
        }


        public bool Unload()
        {

            _claimVM.Unload();
            _claimHistoryVM.Unload();
            _invoiceForTransmissionInUnitVM.Unload();
            _departmentOredersVM.Unload();

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