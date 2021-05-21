namespace ParusModelLite.CertificateQualityDomain.PermissionMaterialDomain
{
    using Halfblood.Common;
    using System;
    using System.ComponentModel;

    public class PermissionMaterialLiteDto : INotifyPropertyChanging, INotifyPropertyChanged, IDto<long>
    {
        #region Static field

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);

        #endregion

        #region Private field

        private long _rn;
        private long _cRn;
        private string _note;
        private string _justification;
        private long _rnCreator;
        private string _creator;
        private DateTime? _creationDate;
        private string _obj;
        private long _rnUserSetState;
        private string _userSetState;
        private PermissionMaterialState _state;
        private DateTime? _stateDate;
        private decimal _count;
        private DateTime? _acceptToDate;
        private string _nomerCertifiacata;
        private string _fullRepresentattion;
        private string _cast;

        #endregion

        #region Public Events

        public virtual event PropertyChangedEventHandler PropertyChanged;
        public virtual event PropertyChangingEventHandler PropertyChanging;

        #endregion

        #region Public Properties

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
        public virtual string Justification
        {
            get
            {
                return this._justification;
            }
            set
            {
                if (this._justification != value)
                {
                    this.SendPropertyChanging();
                    this._justification = value;
                    this.SendPropertyChanged("Justification");
                }
            }
        }
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
        public virtual DateTime? CreationDate
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
        public virtual string Obj
        {
            get
            {
                return this._obj;
            }
            set
            {
                if (this._obj != value)
                {
                    this.SendPropertyChanging();
                    this._obj = value;
                    this.SendPropertyChanged("Obj");
                }
            }
        }
        public virtual long RnUserSetState
        {
            get
            {
                return this._rnUserSetState;
            }
            set
            {
                if (this._rnUserSetState != value)
                {
                    this.SendPropertyChanging();
                    this._rnUserSetState = value;
                    this.SendPropertyChanged("RnUserSetState");
                }
            }
        }
        public virtual string UserSetState
        {
            get
            {
                return this._userSetState;
            }
            set
            {
                if (this._userSetState != value)
                {
                    this.SendPropertyChanging();
                    this._userSetState = value;
                    this.SendPropertyChanged("UserSetState");
                }
            }
        }
        public virtual PermissionMaterialState State
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
        public virtual decimal Count
        {
            get
            {
                return this._count;
            }
            set
            {
                if (this._count != value)
                {
                    this.SendPropertyChanging();
                    this._count = value;
                    this.SendPropertyChanged("Count");
                }
            }
        }
        public virtual DateTime? AcceptToDate
        {
            get
            {
                return this._acceptToDate;
            }
            set
            {
                if (this._acceptToDate != value)
                {
                    this.SendPropertyChanging();
                    this._acceptToDate = value;
                    this.SendPropertyChanged("AcceptToDate");
                }
            }
        }
        public virtual string NomerCertifiacata
        {
            get
            {
                return this._nomerCertifiacata;
            }
            set
            {
                if (this._nomerCertifiacata != value)
                {
                    this.SendPropertyChanging();
                    this._nomerCertifiacata = value;
                    this.SendPropertyChanged("NomerCertifiacata");
                }
            }
        }
        public virtual string FullRepresentattion
        {
            get
            {
                return this._fullRepresentattion;
            }
            set
            {
                if (this._fullRepresentattion != value)
                {
                    this.SendPropertyChanging();
                    this._fullRepresentattion = value;
                    this.SendPropertyChanged("FullRepresentattion");
                }
            }
        }
        public virtual string Cast
        {
            get
            {
                return this._cast;
            }
            set
            {
                if (this._cast != value)
                {
                    this.SendPropertyChanging();
                    this._cast = value;
                    this.SendPropertyChanged("Cast");
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        public override bool Equals(object obj)
        {
            var toCompare = obj as PermissionMaterialLiteDto;
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

        public override int GetHashCode()
        {
            int hashCode = 13;
            hashCode = (hashCode * 7) + this.Rn.GetHashCode();
            return hashCode;
        }

        #endregion

        #region Methods

        protected virtual void SendPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void SendPropertyChanging()
        {
            PropertyChangingEventHandler handler = this.PropertyChanging;
            if (handler != null)
            {
                handler(this, emptyChangingEventArgs);
            }
        }

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

        //partial void OnCreated();

        //public PermissionMaterialLiteDto()
        //{
        //    OnCreated();
        //}
    }
}
