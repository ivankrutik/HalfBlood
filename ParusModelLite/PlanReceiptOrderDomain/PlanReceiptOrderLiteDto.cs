// --------------------------------------------------------------------------------------------------------------------
// <copyright company="VZ" file="PlanReceiptOrderLiteDto.cs">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   There are no comments for ParusModelLite.CuttingOrderDomain.PlanReceiptOrderLiteDto, ParusModelLite in the schema.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------
namespace ParusModelLite.PlanReceiptOrderDomain
{
    using System;
    using System.ComponentModel;

    using Halfblood.Common;

    /// <summary>
    ///     There are no comments for ParusModelLite.CuttingOrderDomain.PlanReceiptOrderLiteDto, ParusModelLite in the schema.
    /// </summary>
    public class PlanReceiptOrderLiteDto : INotifyPropertyChanging, INotifyPropertyChanged, IDto<long>
    {
        #region Static Fields

        /// <summary>
        /// The empty changing event args.
        /// </summary>
        private static readonly PropertyChangingEventArgs emptyChangingEventArgs =
            new PropertyChangingEventArgs(string.Empty);

        #endregion

        #region Fields

        /// <summary>
        /// The _ contractor.
        /// </summary>
        private string _Contractor;

        /// <summary>
        /// The _ creation date.
        /// </summary>
        private DateTime _CreationDate;

        /// <summary>
        /// The _ creator.
        /// </summary>
        private string _Creator;

        /// <summary>
        /// The _ crn.
        /// </summary>
        private long _Crn;

        /// <summary>
        /// The _ department.
        /// </summary>
        private string _Department;

        /// <summary>
        /// The _ ground doc date.
        /// </summary>
        private DateTime? _GroundDocDate;

        /// <summary>
        /// The _ ground doc numb.
        /// </summary>
        private string _GroundDocNumb;

        /// <summary>
        /// The _ ground doc type.
        /// </summary>
        private string _GroundDocType;

        /// <summary>
        /// The _ ground receipt doc date.
        /// </summary>
        private DateTime? _GroundReceiptDocDate;

        /// <summary>
        /// The _ ground receipt doc numb.
        /// </summary>
        private string _GroundReceiptDocNumb;

        /// <summary>
        /// The _ ground receipt doc type.
        /// </summary>
        private string _GroundReceiptDocType;

        /// <summary>
        /// The _ memo contractor.
        /// </summary>
        private string _MemoContractor;

        /// <summary>
        /// The _ memo creator.
        /// </summary>
        private string _MemoCreator;

        /// <summary>
        /// The _ note.
        /// </summary>
        private string _Note;

        /// <summary>
        /// The _ numb.
        /// </summary>
        private long _Numb;

        /// <summary>
        /// The _ pref.
        /// </summary>
        private string _Pref;

        /// <summary>
        /// The _ rn.
        /// </summary>
        private long _Rn;

        /// <summary>
        /// The _ rn contractor.
        /// </summary>
        private long _RnContractor;

        /// <summary>
        /// The _ rn creator.
        /// </summary>
        private long _RnCreator;

        /// <summary>
        /// The _ rn department.
        /// </summary>
        private long _RnDepartment;

        /// <summary>
        /// The _ rn ground doc type.
        /// </summary>
        private long? _RnGroundDocType;

        /// <summary>
        /// The _ rn ground receipt doc type.
        /// </summary>
        private long? _RnGroundReceiptDocType;

        /// <summary>
        /// The _ rn store.
        /// </summary>
        private long _RnStore;

        /// <summary>
        /// The _ state.
        /// </summary>
        private PlanReceiptOrderState _State;

        /// <summary>
        /// The _ state data.
        /// </summary>
        private DateTime? stateDate;

        /// <summary>
        /// The _ store.
        /// </summary>
        private string _Store;



        #endregion

        #region Public Events

        /// <summary>
        /// The property changed.
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The property changing.
        /// </summary>
        public virtual event PropertyChangingEventHandler PropertyChanging;

        #endregion

        #region Public Properties

        /// <summary>
        ///     There are no comments for Contractor in the schema.
        /// </summary>
        public virtual string Contractor
        {
            get
            {
                return this._Contractor;
            }

            set
            {
                if (this._Contractor != value)
                {
                    this.SendPropertyChanging();
                    this._Contractor = value;
                    this.SendPropertyChanged("Contractor");
                }
            }
        }

        /// <summary>
        ///     There are no comments for CreationDate in the schema.
        /// </summary>
        public virtual DateTime CreationDate
        {
            get
            {
                return this._CreationDate;
            }

            set
            {
                if (this._CreationDate != value)
                {
                    this.SendPropertyChanging();
                    this._CreationDate = value;
                    this.SendPropertyChanged("CreationDate");
                }
            }
        }

        /// <summary>
        ///     There are no comments for Creator in the schema.
        /// </summary>
        public virtual string Creator
        {
            get
            {
                return this._Creator;
            }

            set
            {
                if (this._Creator != value)
                {
                    this.SendPropertyChanging();
                    this._Creator = value;
                    this.SendPropertyChanged("Creator");
                }
            }
        }

        /// <summary>
        ///     There are no comments for Crn in the schema.
        /// </summary>
        public virtual long Crn
        {
            get
            {
                return this._Crn;
            }

            set
            {
                if (this._Crn != value)
                {
                    this.SendPropertyChanging();
                    this._Crn = value;
                    this.SendPropertyChanged("Crn");
                }
            }
        }

        /// <summary>
        ///     There are no comments for Department in the schema.
        /// </summary>
        public virtual string Department
        {
            get
            {
                return this._Department;
            }

            set
            {
                if (this._Department != value)
                {
                    this.SendPropertyChanging();
                    this._Department = value;
                    this.SendPropertyChanged("Department");
                }
            }
        }

        /// <summary>
        ///     There are no comments for GroundDocDate in the schema.
        /// </summary>
        public virtual DateTime? GroundDocDate
        {
            get
            {
                return this._GroundDocDate;
            }

            set
            {
                if (this._GroundDocDate != value)
                {
                    this.SendPropertyChanging();
                    this._GroundDocDate = value;
                    this.SendPropertyChanged("GroundDocDate");
                }
            }
        }

        /// <summary>
        ///     There are no comments for GroundDocNumb in the schema.
        /// </summary>
        public virtual string GroundDocNumb
        {
            get
            {
                return this._GroundDocNumb;
            }

            set
            {
                if (this._GroundDocNumb != value)
                {
                    this.SendPropertyChanging();
                    this._GroundDocNumb = value;
                    this.SendPropertyChanged("GroundDocNumb");
                }
            }
        }

        /// <summary>
        ///     There are no comments for GroundDocType in the schema.
        /// </summary>
        public virtual string GroundDocType
        {
            get
            {
                return this._GroundDocType;
            }

            set
            {
                if (this._GroundDocType != value)
                {
                    this.SendPropertyChanging();
                    this._GroundDocType = value;
                    this.SendPropertyChanged("GroundDocType");
                }
            }
        }

        /// <summary>
        ///     There are no comments for GroundReceiptDocDate in the schema.
        /// </summary>
        public virtual DateTime? GroundReceiptDocDate
        {
            get
            {
                return this._GroundReceiptDocDate;
            }

            set
            {
                if (this._GroundReceiptDocDate != value)
                {
                    this.SendPropertyChanging();
                    this._GroundReceiptDocDate = value;
                    this.SendPropertyChanged("GroundReceiptDocDate");
                }
            }
        }

        /// <summary>
        ///     There are no comments for GroundReceiptDocNumb in the schema.
        /// </summary>
        public virtual string GroundReceiptDocNumb
        {
            get
            {
                return this._GroundReceiptDocNumb;
            }

            set
            {
                if (this._GroundReceiptDocNumb != value)
                {
                    this.SendPropertyChanging();
                    this._GroundReceiptDocNumb = value;
                    this.SendPropertyChanged("GroundReceiptDocNumb");
                }
            }
        }

        /// <summary>
        ///     There are no comments for GroundReceiptDocType in the schema.
        /// </summary>
        public virtual string GroundReceiptDocType
        {
            get
            {
                return this._GroundReceiptDocType;
            }

            set
            {
                if (this._GroundReceiptDocType != value)
                {
                    this.SendPropertyChanging();
                    this._GroundReceiptDocType = value;
                    this.SendPropertyChanged("GroundReceiptDocType");
                }
            }
        }

        /// <summary>
        ///     There are no comments for MemoContractor in the schema.
        /// </summary>
        public virtual string MemoContractor
        {
            get
            {
                return this._MemoContractor;
            }

            set
            {
                if (this._MemoContractor != value)
                {
                    this.SendPropertyChanging();
                    this._MemoContractor = value;
                    this.SendPropertyChanged("MemoContractor");
                }
            }
        }

        /// <summary>
        ///     There are no comments for MemoCreator in the schema.
        /// </summary>
        public virtual string MemoCreator
        {
            get
            {
                return this._MemoCreator;
            }

            set
            {
                if (this._MemoCreator != value)
                {
                    this.SendPropertyChanging();
                    this._MemoCreator = value;
                    this.SendPropertyChanged("MemoCreator");
                }
            }
        }

        /// <summary>
        ///     There are no comments for Note in the schema.
        /// </summary>
        public virtual string Note
        {
            get
            {
                return this._Note;
            }

            set
            {
                if (this._Note != value)
                {
                    this.SendPropertyChanging();
                    this._Note = value;
                    this.SendPropertyChanged("Note");
                }
            }
        }

        /// <summary>
        ///     There are no comments for Numb in the schema.
        /// </summary>
        public virtual long Numb
        {
            get
            {
                return this._Numb;
            }

            set
            {
                if (this._Numb != value)
                {
                    this.SendPropertyChanging();
                    this._Numb = value;
                    this.SendPropertyChanged("Numb");
                }
            }
        }

        /// <summary>
        ///     There are no comments for Pref in the schema.
        /// </summary>
        public virtual string Pref
        {
            get
            {
                return this._Pref;
            }

            set
            {
                if (this._Pref != value)
                {
                    this.SendPropertyChanging();
                    this._Pref = value;
                    this.SendPropertyChanged("Pref");
                }
            }
        }

        /// <summary>
        ///     There are no comments for Rn in the schema.
        /// </summary>
        public virtual long Rn
        {
            get
            {
                return this._Rn;
            }

            set
            {
                if (this._Rn != value)
                {
                    this.SendPropertyChanging();
                    this._Rn = value;
                    this.SendPropertyChanged("Rn");
                }
            }
        }

        /// <summary>
        ///     There are no comments for RnContractor in the schema.
        /// </summary>
        public virtual long RnContractor
        {
            get
            {
                return this._RnContractor;
            }

            set
            {
                if (this._RnContractor != value)
                {
                    this.SendPropertyChanging();
                    this._RnContractor = value;
                    this.SendPropertyChanged("RnContractor");
                }
            }
        }

        /// <summary>
        ///     There are no comments for RnCreator in the schema.
        /// </summary>
        public virtual long RnCreator
        {
            get
            {
                return this._RnCreator;
            }

            set
            {
                if (this._RnCreator != value)
                {
                    this.SendPropertyChanging();
                    this._RnCreator = value;
                    this.SendPropertyChanged("RnCreator");
                }
            }
        }

        /// <summary>
        ///     There are no comments for RnDepartment in the schema.
        /// </summary>
        public virtual long RnDepartment
        {
            get
            {
                return this._RnDepartment;
            }

            set
            {
                if (this._RnDepartment != value)
                {
                    this.SendPropertyChanging();
                    this._RnDepartment = value;
                    this.SendPropertyChanged("RnDepartment");
                }
            }
        }

        /// <summary>
        ///     There are no comments for RnGroundDocType in the schema.
        /// </summary>
        public virtual long? RnGroundDocType
        {
            get
            {
                return this._RnGroundDocType;
            }

            set
            {
                if (this._RnGroundDocType != value)
                {
                    this.SendPropertyChanging();
                    this._RnGroundDocType = value;
                    this.SendPropertyChanged("RnGroundDocType");
                }
            }
        }

        /// <summary>
        ///     There are no comments for RnGroundReceiptDocType in the schema.
        /// </summary>
        public virtual long? RnGroundReceiptDocType
        {
            get
            {
                return this._RnGroundReceiptDocType;
            }

            set
            {
                if (this._RnGroundReceiptDocType != value)
                {
                    this.SendPropertyChanging();
                    this._RnGroundReceiptDocType = value;
                    this.SendPropertyChanged("RnGroundReceiptDocType");
                }
            }
        }

        /// <summary>
        ///     There are no comments for RnStore in the schema.
        /// </summary>
        public virtual long RnStore
        {
            get
            {
                return this._RnStore;
            }

            set
            {
                if (this._RnStore != value)
                {
                    this.SendPropertyChanging();
                    this._RnStore = value;
                    this.SendPropertyChanged("RnStore");
                }
            }
        }

        /// <summary>
        ///     There are no comments for State in the schema.
        /// </summary>
        public virtual PlanReceiptOrderState State
        {
            get
            {
                return this._State;
            }

            set
            {
                if (this._State != value)
                {
                    this.SendPropertyChanging();
                    this._State = value;
                    this.SendPropertyChanged("State");
                }
            }
        }

        /// <summary>
        ///     There are no comments for StateDate in the schema.
        /// </summary>
        public virtual DateTime? StateDate
        {
            get
            {
                return this.stateDate;
            }

            set
            {
                if (this.stateDate != value)
                {
                    this.SendPropertyChanging();
                    this.stateDate = value;
                    this.SendPropertyChanged("StateDate");
                }
            }
        }

        /// <summary>
        ///     There are no comments for Store in the schema.
        /// </summary>
        public virtual string Store
        {
            get
            {
                return this._Store;
            }

            set
            {
                if (this._Store != value)
                {
                    this.SendPropertyChanging();
                    this._Store = value;
                    this.SendPropertyChanged("Store");
                }
            }
        }
        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var toCompare = obj as PlanReceiptOrderLiteDto;
            if (toCompare == null)
            {
                return false;
            }

            if (!Equals(this.Rn, toCompare.Rn))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            int hashCode = 13;
            hashCode = (hashCode * 7) + this.Rn.GetHashCode();
            return hashCode;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The send property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void SendPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The send property changing.
        /// </summary>
        protected virtual void SendPropertyChanging()
        {
            PropertyChangingEventHandler handler = this.PropertyChanging;
            if (handler != null)
            {
                handler(this, emptyChangingEventArgs);
            }
        }

        /// <summary>
        /// The send property changing.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void SendPropertyChanging(string propertyName)
        {
            PropertyChangingEventHandler handler = this.PropertyChanging;
            if (handler != null)
            {
                handler(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion

        object IHasUid.Rn { get { return Rn; } }
    }
}