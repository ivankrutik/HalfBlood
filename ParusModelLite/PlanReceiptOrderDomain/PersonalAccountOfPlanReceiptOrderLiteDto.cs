//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using NHibernate template.
// 08.08.2013
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------


namespace ParusModelLite.PlanReceiptOrderDomain
{
    using Halfblood.Common;
    using System;
    using System.ComponentModel;

    /// <summary>
    /// There are no comments for ParusModelLite.PlanReceiptOrderDomain.PersonalAccountOfPlanReceiptOrderLiteDto, ParusModelLite in the schema.
    /// </summary>
    public partial class PersonalAccountOfPlanReceiptOrderLiteDto : INotifyPropertyChanging, INotifyPropertyChanged, IDto<long>
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);

        private long _rn;
        private long _cRn;
        private long _pRn;
        private string _note;
        private long _rnCreator;
        private string _creator;
        private PlanReceiptOrderPersonalAccountState _state;
        private DateTime _creationDate;
        private decimal? _countByDocument;
        private decimal? _countFact;
        private long? _rnAgentState;
        private string _agentState;
        private DateTime? _stateDate;
        private string _memoCreator;
        private string _memoAgentState;
        private long _rnPersonalAccount;
        private string _personalAccount;
        private long _inOrderSpecRN;
        private string _inOrderPref;
        private string _inOrderNumb;

        #region Extensibility Method Definitions

        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();

        public override bool Equals(object obj)
        {
            PersonalAccountOfPlanReceiptOrderLiteDto toCompare = obj as PersonalAccountOfPlanReceiptOrderLiteDto;
            if (toCompare == null)
            {
                return false;
            }

            if (!Object.Equals(this.Rn, toCompare.Rn))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = 13;
            hashCode = (hashCode * 7) + Rn.GetHashCode();
            return hashCode;
        }

        #endregion

        /// <summary>
        /// There are no comments for PersonalAccountOfPlanReceiptOrderLiteDto constructor in the schema.
        /// </summary>
        public PersonalAccountOfPlanReceiptOrderLiteDto()
        {
            OnCreated();
        }

        object IHasUid.Rn { get { return Rn; } }

        /// <summary>
        /// There are no comments for Rn in the schema.
        /// </summary>
        public virtual long Rn
        {
            get
            {
                return this._rn;
            }
            set
            {
                if (this._rn != value)
                {
                    this.SendPropertyChanging();
                    this._rn = value;
                    this.SendPropertyChanged("Rn");
                }
            }
        }


        /// <summary>
        /// There are no comments for CRn in the schema.
        /// </summary>
        public virtual long CRn
        {
            get
            {
                return this._cRn;
            }
            set
            {
                if (this._cRn != value)
                {
                    this.SendPropertyChanging();
                    this._cRn = value;
                    this.SendPropertyChanged("CRn");
                }
            }
        }


        /// <summary>
        /// There are no comments for PRn in the schema.
        /// </summary>
        public virtual long PRn
        {
            get
            {
                return this._pRn;
            }
            set
            {
                if (this._pRn != value)
                {
                    this.SendPropertyChanging();
                    this._pRn = value;
                    this.SendPropertyChanged("PRn");
                }
            }
        }


        /// <summary>
        /// There are no comments for Note in the schema.
        /// </summary>
        public virtual string Note
        {
            get
            {
                return this._note;
            }
            set
            {
                if (this._note != value)
                {
                    this.SendPropertyChanging();
                    this._note = value;
                    this.SendPropertyChanged("Note");
                }
            }
        }


        /// <summary>
        /// There are no comments for RnCreator in the schema.
        /// </summary>
        public virtual long RnCreator
        {
            get
            {
                return this._rnCreator;
            }
            set
            {
                if (this._rnCreator != value)
                {
                    this.SendPropertyChanging();
                    this._rnCreator = value;
                    this.SendPropertyChanged("RnCreator");
                }
            }
        }


        /// <summary>
        /// There are no comments for Creator in the schema.
        /// </summary>
        public virtual string Creator
        {
            get
            {
                return this._creator;
            }
            set
            {
                if (this._creator != value)
                {
                    this.SendPropertyChanging();
                    this._creator = value;
                    this.SendPropertyChanged("Creator");
                }
            }
        }


        /// <summary>
        /// There are no comments for State in the schema.
        /// </summary>
        public virtual PlanReceiptOrderPersonalAccountState State
        {
            get
            {
                return this._state;
            }
            set
            {
                if (this._state != value)
                {
                    this.SendPropertyChanging();
                    this._state = value;
                    this.SendPropertyChanged("State");
                }
            }
        }


        /// <summary>
        /// There are no comments for CreationDate in the schema.
        /// </summary>
        public virtual System.DateTime CreationDate
        {
            get
            {
                return this._creationDate;
            }
            set
            {
                if (this._creationDate != value)
                {
                    this.SendPropertyChanging();
                    this._creationDate = value;
                    this.SendPropertyChanged("CreationDate");
                }
            }
        }


        /// <summary>
        /// There are no comments for CountByDocument in the schema.
        /// </summary>
        public virtual decimal? CountByDocument
        {
            get
            {
                return this._countByDocument;
            }
            set
            {
                if (this._countByDocument != value)
                {
                    this.SendPropertyChanging();
                    this._countByDocument = value;
                    this.SendPropertyChanged("CountByDocument");
                }
            }
        }


        /// <summary>
        /// There are no comments for CountFact in the schema.
        /// </summary>
        public virtual decimal? CountFact
        {
            get
            {
                return this._countFact;
            }
            set
            {
                if (this._countFact != value)
                {
                    this.SendPropertyChanging();
                    this._countFact = value;
                    this.SendPropertyChanged("CountFact");
                }
            }
        }


        /// <summary>
        /// There are no comments for RnAgentState in the schema.
        /// </summary>
        public virtual long? RnAgentState
        {
            get
            {
                return this._rnAgentState;
            }
            set
            {
                if (this._rnAgentState != value)
                {
                    this.SendPropertyChanging();
                    this._rnAgentState = value;
                    this.SendPropertyChanged("RnAgentState");
                }
            }
        }


        /// <summary>
        /// There are no comments for AgentState in the schema.
        /// </summary>
        public virtual string AgentState
        {
            get
            {
                return this._agentState;
            }
            set
            {
                if (this._agentState != value)
                {
                    this.SendPropertyChanging();
                    this._agentState = value;
                    this.SendPropertyChanged("AgentState");
                }
            }
        }


        /// <summary>
        /// There are no comments for StateDate in the schema.
        /// </summary>
        public virtual DateTime? StateDate
        {
            get
            {
                return this._stateDate;
            }
            set
            {
                if (this._stateDate != value)
                {
                    this.SendPropertyChanging();
                    this._stateDate = value;
                    this.SendPropertyChanged("StateDate");
                }
            }
        }


        /// <summary>
        /// There are no comments for MemoCreator in the schema.
        /// </summary>
        public virtual string MemoCreator
        {
            get
            {
                return this._memoCreator;
            }
            set
            {
                if (this._memoCreator != value)
                {
                    this.SendPropertyChanging();
                    this._memoCreator = value;
                    this.SendPropertyChanged("MemoCreator");
                }
            }
        }


        /// <summary>
        /// There are no comments for MemoAgentState in the schema.
        /// </summary>
        public virtual string MemoAgentState
        {
            get
            {
                return this._memoAgentState;
            }
            set
            {
                if (this._memoAgentState != value)
                {
                    this.SendPropertyChanging();
                    this._memoAgentState = value;
                    this.SendPropertyChanged("MemoAgentState");
                }
            }
        }


        /// <summary>
        /// There are no comments for RnPersonalAccount in the schema.
        /// </summary>
        public virtual long RnPersonalAccount
        {
            get
            {
                return this._rnPersonalAccount;
            }
            set
            {
                if (this._rnPersonalAccount != value)
                {
                    this.SendPropertyChanging();
                    this._rnPersonalAccount = value;
                    this.SendPropertyChanged("RnPersonalAccount");
                }
            }
        }


        /// <summary>
        /// There are no comments for PersonalAccount in the schema.
        /// </summary>
        public virtual string PersonalAccount
        {
            get
            {
                return this._personalAccount;
            }
            set
            {
                if (this._personalAccount != value)
                {
                    this.SendPropertyChanging();
                    this._personalAccount = value;
                    this.SendPropertyChanged("PersonalAccount");
                }
            }
        }

        public virtual long InOrderSpecRN
        {
            get
            {
                return this._inOrderSpecRN;
            }

            set
            {
                if (this._inOrderSpecRN != value)
                {
                    this.SendPropertyChanging();
                    this._inOrderSpecRN = value;
                    this.SendPropertyChanged("InOrderSpecRN");
                }
            }
        }


        public virtual string InOrderPref
        {
            get
            {
                return this._inOrderPref;
            }

            set
            {
                if (this._inOrderPref != value)
                {
                    this.SendPropertyChanging();
                    this._inOrderPref = value;
                    this.SendPropertyChanged("InOrderPref");
                }
            }
        }
        public virtual string InOrderNumb
        {
            get
            {
                return this._inOrderNumb;
            }

            set
            {
                if (this._inOrderNumb != value)
                {
                    this.SendPropertyChanging();
                    this._inOrderNumb = value;
                    this.SendPropertyChanged("InOrderNumb");
                }
            }
        }
        public virtual event PropertyChangingEventHandler PropertyChanging;

        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName)
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return PersonalAccount;
        }
    }
}