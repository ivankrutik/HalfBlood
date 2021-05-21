using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Reactive.Linq;
using Hephaestus.Infrastructure.Class;
using Hephaestus.Infrastructure.Interface;
using Hephaestus.Visirovka.Interface;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using ParusModel;
using ParusModel.Filter;

namespace Hephaestus.Visirovka.ViewModels
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof (IExpeditorTaskVM))]
    public class ExpeditorTaskVM : IExpeditorTaskVM, INotifyPropertyChanged
    {
        #region Event

        public event Action<IModule> UnloadMe;
        public event Action<IModule> Unloaded;
        public event Action<IModule> Unloading;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region VAR
        private IErrorHandler _errorHandler;
        [Import] private IExpeditorTaskV ExpeditorTaskV;
        private IDocumentBase _defaultDocument;

        private IEventAggregator _eventAggregator;

        [Import] private IListOfDocuments _listOfDocuments;
        [Import] private IParusAccessModule _parusAccess;

        private object _region;

        private object _regionMenu;
        [Import] private IReportCrystalVM _reportCrystalVM;

        private string _title;
       

        [Import] private IBLVisirovkaCore _visingCore;
        [Import] private IVisirovkaReport _visirovkaReport;

        #region Expeditor

        public const string ExpeditorPropertyName = "Expeditor";

        private Agnlist _expeditor = new Agnlist();

        public Agnlist Expeditor
        {
            get { return _expeditor; }

            set
            {
                if (_expeditor == value)
                {
                    return;
                }

                _expeditor = value;
                OnPropertyChanged(ExpeditorPropertyName);
                PrintReportCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region ExpeditorsList

        public const string ExpeditorsListPropertyName = "ExpeditorsList";
        private ObservableCollection<Agnlist> _expeditorsList = new ObservableCollection<Agnlist>();

        public ObservableCollection<Agnlist> ExpeditorsList
        {
            get { return _expeditorsList; }
            set
            {
                if (_expeditorsList == value)
                {
                    return;
                }

                _expeditorsList = value;
                OnPropertyChanged(ExpeditorsListPropertyName);
            }
        }

        #endregion

        #region Workers

        public const string WorkersPropertyName = "Workers";
        private ObservableCollection<Agnlist> _workers = new ObservableCollection<Agnlist>();

        public ObservableCollection<Agnlist> Workers
        {
            get { return _workers; }
            set
            {
                if (_workers == value)
                {
                    return;
                }
                _workers = value;
                OnPropertyChanged(WorkersPropertyName);
                PrintReportCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region WorkersList

        /// <summary>
        ///     The <see cref="WorkersList" /> property's name.
        /// </summary>
        public const string WorkersListPropertyName = "WorkersList";

        private ObservableCollection<Agnlist> _workersList = new ObservableCollection<Agnlist>();

        /// <summary>
        ///     Sets and gets the Peoples property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public ObservableCollection<Agnlist> WorkersList
        {
            get { return _workersList; }

            set
            {
                if (_workersList == value)
                {
                    return;
                }


                _workersList = value;
                OnPropertyChanged(WorkersListPropertyName);
            }
        }

        #endregion

        #region Plot

        /// <summary>
        ///     The <see cref="Plot" /> property's name.
        /// </summary>
        public const string PlotPropertyName = "Plot";

        private string _plot = "";

        /// <summary>
        ///     Sets and gets the Plot property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string Plot
        {
            get { return _plot; }

            set
            {
                if (_plot == value)
                {
                    return;
                }


                _plot = value;
                OnPropertyChanged(PlotPropertyName);
            }
        }

        #endregion

        #region Change

        /// <summary>
        ///     The <see cref="Change" /> property's name.
        /// </summary>
        public const string ChangePropertyName = "Change";

        private string _change = "";

        /// <summary>
        ///     Sets and gets the Change property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string Change
        {
            get { return _change; }

            set
            {
                if (_change == value)
                {
                    return;
                }


                _change = value;
                OnPropertyChanged(ChangePropertyName);
            }
        }

        #endregion

        #region Date

        /// <summary>
        ///     The <see cref="Date" /> property's name.
        /// </summary>
        public const string DatePropertyName = "Date";

        private DateTime _date = DateTime.Now;

        /// <summary>
        ///     Sets and gets the Date property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public DateTime Date
        {
            get { return _date; }

            set
            {
                if (_date == value)
                {
                    return;
                }


                _date = value;
                OnPropertyChanged(DatePropertyName);
            }
        }

        #endregion

        #region Header

        /// <summary>
        ///     The <see cref="Header" /> property's name.
        /// </summary>
        public const string HeaderPropertyName = "Header";

        private string _header = "";

        /// <summary>
        ///     Sets and gets the Header property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string Header
        {
            get { return _header; }

            set
            {
                if (_header == value)
                {
                    return;
                }


                _header = value;
                OnPropertyChanged(HeaderPropertyName);
            }
        }

        #endregion

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

        /// <summary>
        ///     Initializes a new instance of the TaskReportViewModel class.
        /// </summary>
        public ExpeditorTaskVM()
        {
            RemoveWorkerCommand = new DelegateCommand<Agnlist>(ExecuteRemoveWorkerCommand, CanExecuteRemoveWorkerCommand);
            PrintReportCommand = new DelegateCommand(ExecutePrintReportCommand, CanExecutePrintReportCommand);
        }

        public bool Init(IErrorHandler errorHandler,IEventAggregator EventAggregator, IDocumentBase DefaultDocument)
        {
            _errorHandler = errorHandler;
            ExpeditorTaskV.DataContext = this;
            Region = ExpeditorTaskV;
            _defaultDocument = DefaultDocument;
            _visingCore.init(_errorHandler,_defaultDocument.Connect, _defaultDocument.User);
            _visirovkaReport.init(_defaultDocument.Connect, _defaultDocument.User);
            _parusAccess.Init(_defaultDocument.Connect, _defaultDocument.User.UserId,
                              _defaultDocument.User.ConnectionInform.Password,
                              _defaultDocument.User.ConnectionInform.Server);
            LoadData();
            return true;
        }

        private void LoadData()
        {

            Observable.ToAsync(
              () =>
              {
                  IsBusy = true;
                  WorkersList =
                 new ObservableCollection<Agnlist>(
                     _parusAccess.GetAgnlistInfo(new FAgnlist
                     {
                         CLNPERSONs_PERS_AGENT =
                             new FCLNPERSON
                             {
                                 CLNPSPFMs = new FCLNPSPFM { CLNPSDEP_PSDEPRN = new CLNPSDEP { PSDEPCODE = "ГРУЗЧИК" } }
                             }
                     }));

                  ExpeditorsList =
                      new ObservableCollection<Agnlist>(
                          _parusAccess.GetAgnlistInfo(new FAgnlist
                          {
                              CLNPERSONs_PERS_AGENT =
                                  new FCLNPERSON
                                  {
                                      CLNPSPFMs = new FCLNPSPFM { CLNPSDEP_PSDEPRN = new CLNPSDEP { PSDEPCODE = "ЭКСПЕДИТОР" } }
                                  }
                          }));
              })()
              .ObserveOnDispatcher()
              .Subscribe(x =>
              {
                   IsBusy = false;
               
              });

           
        }

        ~ExpeditorTaskVM()
        {
        }

        #endregion

        #region COMMANDS

        #region RemoveWorkerCommand

        public DelegateCommand<Agnlist> RemoveWorkerCommand { get; private set; }


        private bool CanExecuteRemoveWorkerCommand(Agnlist person)
        {
            return person != null;
        }

        private void ExecuteRemoveWorkerCommand(Agnlist person)
        {
            Workers.Remove(person);
        }

        #endregion

        #region PrintReportCommand

        public DelegateCommand PrintReportCommand { get; private set; }


        private void ExecutePrintReportCommand()
        {
            _reportCrystalVM.Init(_visirovkaReport.GetReportTask(Expeditor, new List<Agnlist>(Workers), Plot, Change,
                                                                 Date));
            var doc = new Document(_reportCrystalVM);

            doc.Title = "Отчет";
            _listOfDocuments.AddDocument(doc, true);
        }


        private bool CanExecutePrintReportCommand()
        {
            return  Expeditor != null && Expeditor.RN != 0;
        }

        #endregion

        #endregion

        #region Methot

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