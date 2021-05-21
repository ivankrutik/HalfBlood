namespace ParusModelLite.CertificateQualityDomain.WarehouseQualityCertificateDomain
{
    using System;
    using Buisness.Entities;
    using Halfblood.Common;
    using System.ComponentModel;

    public class WarehouseQualityCertificateRestLiteDto : INotifyPropertyChanging, INotifyPropertyChanged, IDto<long>
    {
        private static readonly PropertyChangingEventArgs emptyChangingEventArgs =
            new PropertyChangingEventArgs(string.Empty);
        #region Fields
        object IHasUid.Rn { get { return Rn; } }
        private long _rn;
        private CatalogDto _catalog;
        private string _userCreator;
        private long _rnCreator;
        private DateTime? _creationDate;
        private WarehouseQualityCertificateState _state;
        private string _note;
        private string _userSetState;
        private long _rnUserSetState;
        private DateTime? _stateDate;
        private string _storekeeper;
        private long _rnStorekeeper;
        private DateTime? _storekeeperDate;
        private string _controllerQuality;
        private long _rnControllerQuality;
        private DateTime? _controllerQualityDate;
        private string _customer;
        private long _rnCustomer;
        private DateTime? _customerDate;
        private string _controllerQualityDepartment;
        private long _rnControllerQualityDepartment;
        private DateTime? _controllerQualityDepartmentDate;
        private string _marka;
        private string _cast;
        private string _fullRepresentation;
        private string _gostMix;
        private string _gostCast;
        private string _mix;
        private string _standardSize;
        private string _nomerCertificata;
        private string _pass;
        private decimal _rest;

        private string _unitOfMeasure;
        private long _rNCertificateQuality;
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
        public virtual CatalogDto Catalog
        {
            get
            {
                return this._catalog;
            }
            set
            {
                if (this._catalog != value)
                {
                    this.SendPropertyChanging();
                    this._catalog = value;
                    this.SendPropertyChanged("Catalog");
                }
            }
        }
        public virtual string UserCreator
        {
            get
            {
                return this._userCreator;
            }
            set
            {
                if (this._userCreator != value)
                {
                    this.SendPropertyChanging();
                    this._userCreator = value;
                    this.SendPropertyChanged("UserCreator");
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
        public virtual WarehouseQualityCertificateState State
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
        public virtual string Storekeeper
        {
            get
            {
                return this._storekeeper;
            }
            set
            {
                if (this._storekeeper != value)
                {
                    this.SendPropertyChanging();
                    this._storekeeper = value;
                    this.SendPropertyChanged("Storekeeper");
                }
            }
        }
        public virtual long RnStorekeeper
        {
            get
            {
                return this._rnStorekeeper;
            }
            set
            {
                if (this._rnStorekeeper != value)
                {
                    this.SendPropertyChanging();
                    this._rnStorekeeper = value;
                    this.SendPropertyChanged("RnStorekeeper");
                }
            }
        }
        public virtual DateTime? StorekeeperDate
        {
            get
            {
                return this._storekeeperDate;
            }
            set
            {
                if (this._storekeeperDate != value)
                {
                    this.SendPropertyChanging();
                    this._storekeeperDate = value;
                    this.SendPropertyChanged("StorekeeperDate");
                }
            }
        }
        public virtual string ControllerQuality
        {
            get
            {
                return this._controllerQuality;
            }
            set
            {
                if (this._controllerQuality != value)
                {
                    this.SendPropertyChanging();
                    this._controllerQuality = value;
                    this.SendPropertyChanged("ControllerQuality");
                }
            }
        }
        public virtual long RnControllerQuality
        {
            get
            {
                return this._rnControllerQuality;
            }
            set
            {
                if (this._rnControllerQuality != value)
                {
                    this.SendPropertyChanging();
                    this._rnControllerQuality = value;
                    this.SendPropertyChanged("RnControllerQuality");
                }
            }
        }
        public virtual DateTime? ControllerQualityDate
        {
            get
            {
                return this._controllerQualityDate;
            }
            set
            {
                if (this._controllerQualityDate != value)
                {
                    this.SendPropertyChanging();
                    this._controllerQualityDate = value;
                    this.SendPropertyChanged("ControllerQualityDate");
                }
            }
        }

        public virtual string Customer
        {
            get
            {
                return this._customer;
            }
            set
            {
                if (this._customer != value)
                {
                    this.SendPropertyChanging();
                    this._customer = value;
                    this.SendPropertyChanged("Customer");
                }
            }
        }

        public virtual long RnCustomer
        {
            get
            {
                return this._rnCustomer;
            }
            set
            {
                if (this._rnCustomer != value)
                {
                    this.SendPropertyChanging();
                    this._rnCustomer = value;
                    this.SendPropertyChanged("RnCustomer");
                }
            }
        }
        public virtual DateTime? CustomerDate
        {
            get
            {
                return this._customerDate;
            }
            set
            {
                if (this._customerDate != value)
                {
                    this.SendPropertyChanging();
                    this._customerDate = value;
                    this.SendPropertyChanged("CustomerDate");
                }
            }
        }
        public virtual string ControllerQualityDepartment
        {
            get
            {
                return this._controllerQualityDepartment;
            }
            set
            {
                if (this._controllerQualityDepartment != value)
                {
                    this.SendPropertyChanging();
                    this._controllerQualityDepartment = value;
                    this.SendPropertyChanged("ControllerQualityDepartment");
                }
            }
        }
        public virtual long RnControllerQualityDepartment
        {
            get
            {
                return this._rnControllerQualityDepartment;
            }
            set
            {
                if (this._rnControllerQualityDepartment != value)
                {
                    this.SendPropertyChanging();
                    this._rnControllerQualityDepartment = value;
                    this.SendPropertyChanged("RnControllerQualityDepartment");
                }
            }
        }
        public virtual DateTime? ControllerQualityDepartmentDate
        {
            get
            {
                return this._controllerQualityDepartmentDate;
            }
            set
            {
                if (this._controllerQualityDepartmentDate != value)
                {
                    this.SendPropertyChanging();
                    this._controllerQualityDepartmentDate = value;
                    this.SendPropertyChanged("ControllerQualityDepartmentDate");
                }
            }
        }
        public virtual string Marka
        {
            get
            {
                return this._marka;
            }
            set
            {
                if (this._marka != value)
                {
                    this.SendPropertyChanging();
                    this._marka = value;
                    this.SendPropertyChanged("Marka");
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
        public virtual string FullRepresentation
        {
            get
            {
                return this._fullRepresentation;
            }
            set
            {
                if (this._fullRepresentation != value)
                {
                    this.SendPropertyChanging();
                    this._fullRepresentation = value;
                    this.SendPropertyChanged("FullRepresentation");
                }
            }
        }
        public virtual string GostMix
        {
            get
            {
                return this._gostMix;
            }
            set
            {
                if (this._gostMix != value)
                {
                    this.SendPropertyChanging();
                    this._gostMix = value;
                    this.SendPropertyChanged("GostMix");
                }
            }
        }
        public virtual string GostCast
        {
            get
            {
                return this._gostCast;
            }
            set
            {
                if (this._gostCast != value)
                {
                    this.SendPropertyChanging();
                    this._gostCast = value;
                    this.SendPropertyChanged("GostCast");
                }
            }
        }
        public virtual string Mix
        {
            get
            {
                return this._mix;
            }
            set
            {
                if (this._mix != value)
                {
                    this.SendPropertyChanging();
                    this._mix = value;
                    this.SendPropertyChanged("Mix");
                }
            }
        }
        public virtual string StandardSize
        {
            get
            {
                return this._standardSize;
            }
            set
            {
                if (this._standardSize != value)
                {
                    this.SendPropertyChanging();
                    this._standardSize = value;
                    this.SendPropertyChanged("StandardSize");
                }
            }
        }
        public virtual string NomerCertificata
        {
            get
            {
                return this._nomerCertificata;
            }
            set
            {
                if (this._nomerCertificata != value)
                {
                    this.SendPropertyChanging();
                    this._nomerCertificata = value;
                    this.SendPropertyChanged("NomerCertificate");
                }
            }
        }
        public virtual string Pass
        {
            get
            {
                return this._pass;
            }
            set
            {
                if (this._pass != value)
                {
                    this.SendPropertyChanging();
                    this._pass = value;
                    this.SendPropertyChanged("Pass");
                }
            }
        }
        public virtual decimal Rest
        {
            get
            {
                return this._rest;
            }
            set
            {
                if (this._rest != value)
                {
                    this.SendPropertyChanging();
                    this._rest = value;
                    this.SendPropertyChanged("Rest");
                }
            }
        }


        public virtual string UnitOfMeasure
        {
            get
            {
                return this._unitOfMeasure;
            }
            set
            {
                if (this._unitOfMeasure != value)
                {
                    this.SendPropertyChanging();
                    this._unitOfMeasure = value;
                    this.SendPropertyChanged("UnitOfMeasure");
                }
            }
        }
        public virtual long RNCertificateQuality
        {
            get
            {
                return this._rNCertificateQuality;
            }
            set
            {
                if (this._rNCertificateQuality != value)
                {
                    this.SendPropertyChanging();
                    this._rNCertificateQuality = value;
                    this.SendPropertyChanged("RNCertificateQuality");
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
            var toCompare = obj as WarehouseQualityCertificateRestLiteDto;
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
    }
}
