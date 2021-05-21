using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Hephaestus.Infrastructure.Interface;
using Hephaestus.Visirovka.Class;
using Hephaestus.Visirovka.Interface;
using Hephaestus.Visirovka.View.Wpf.Converter;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using ParusModel;

namespace Hephaestus.Visirovka
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IClaimHistoryVM))]
    public class ClaimHistoryVM : IClaimHistoryVM, INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<IModule> UnloadMe;
        public event Action<IModule> Unloaded;
        public event Action<IModule> Unloading;
        #endregion
        #region Var
        private object _region;
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
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        private string _name;
        public string Name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        private object _regionMenu;
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
        private string _title;
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

        
        

        private IEventAggregator _mainEventAggregator;


        
        [Import]
        private IBLVisirovkaCore _visingCore;
        [Import]
        private IClaimHistoryV _claimHistoryV;

        #region HistoryList
        /// <summary>
        /// The <see cref="HistoryList" /> property's name.
        /// </summary>
        public const string HistoryListPropertyName = "HistoryList";

        private ObservableCollection<RevisionHistoryUdoSight> _historyList = new ObservableCollection<RevisionHistoryUdoSight>();

        /// <summary>
        /// Sets and gets the HistoryList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<RevisionHistoryUdoSight> HistoryList
        {
            get
            {
                return _historyList;
            }

            set
            {
                if (_historyList == value)
                {
                    return;
                }

                
                _historyList = value;
                
            }
        }
        #endregion

        #endregion
        #region Ctor
        public ClaimHistoryVM()
        {

        }
        public bool Init(IErrorHandler _errorHandler,IEventAggregator EventAggregator, IBLVisirovkaCore BLVisirovkaCore, IDocumentBase DocumentBase, UDOSight Claim)
        {
            _mainEventAggregator = EventAggregator;
            _visingCore = BLVisirovkaCore;
            _claimHistoryV.DataContext = this;
            Region = _claimHistoryV;
            ExecuteLoadHistoryCommand(Claim);
            return true;
        }
        #endregion
        #region Command
        #region LoadHistoryCommand
        public DelegateCommand<UDOSight> LoadHistoryCommand { get; private set; }

      
        private void ExecuteLoadHistoryCommand(UDOSight claim)
        {

            HistoryList.Clear();
            //изменения за сегдня 
            var updatelist = _visingCore.GetUpdateList(claim);
            foreach (var item in updatelist)
            {
                var updatelistdetail = _visingCore.GetUpdateListDetail(item);
                foreach (var itemdetail in updatelistdetail)
                {
                    var historicalAction = new RevisionHistoryUdoSight { Date = item.MODIFDATE, Who = item.AUTHID };
                    historicalAction.Action = new GroupNameConverter().Convert("Claim." + itemdetail.COLUMNNAME, null, null, null).ToString();
                    if (itemdetail.COLUMNNAME == "STATE")
                    { 
                        if (itemdetail.NUMVALUE != null)
                        {
                            historicalAction.Value = new ValueToStateConverter().Convert(itemdetail.NUMVALUE, null, null, null).ToString();
                            if (itemdetail.UPDNUMVALUE != null)
                            {
                                historicalAction.OldValue = new ValueToStateConverter().Convert(itemdetail.UPDNUMVALUE, null, null, null).ToString();
                            }
                        }
                    }
                    else
                        if (itemdetail.STRVALUE != null)
                        {
                            historicalAction.Value = itemdetail.STRVALUE;
                            historicalAction.OldValue = itemdetail.UPDSTRVALUE;
                        }
                    if (historicalAction.OldValue != historicalAction.Value)
                    {
                        HistoryList.Add(historicalAction);
                    }
                }

            }
            //изменениния из архива
            var updatelistarc = _visingCore.GetUpdateListArc(claim);
            foreach (var item in updatelistarc)
            {
                var updatelistdetail = _visingCore.GetUpdateListDetailArc(item);
                foreach (var itemdetail in updatelistdetail)
                {
                    var historicalAction = new RevisionHistoryUdoSight { Date = item.MODIFDATE, Who = item.AUTHID };

                    historicalAction.Action = new GroupNameConverter().Convert(itemdetail.COLUMNNAME, null, null, null).ToString();
                    if (itemdetail.NUMVALUE != null)
                    {
                        historicalAction.Value = new ValueToStateConverter().Convert(itemdetail.NUMVALUE, null, null, null).ToString();
                        if (itemdetail.UPDNUMVALUE != null)
                        {
                            historicalAction.OldValue = new ValueToStateConverter().Convert(itemdetail.UPDNUMVALUE, null, null, null).ToString();
                        }
                    }
                    else
                        if (itemdetail.STRVALUE != null)
                        {
                            historicalAction.Value = itemdetail.STRVALUE;
                            historicalAction.OldValue = itemdetail.UPDSTRVALUE;
                        }
                    if (historicalAction.OldValue != historicalAction.Value)
                    {
                        HistoryList.Add(historicalAction);
                    }
                }
            }
            HistoryList = new ObservableCollection<RevisionHistoryUdoSight>(HistoryList.OrderByDescending(x => x.Date));
        }

        private bool CanExecuteLoadHistoryCommand(UDOSight claim)
        {
            return true;
        }
        #endregion
        #endregion
        #region Method
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
