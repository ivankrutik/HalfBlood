// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificateQualityRestLiteDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the CertificateQualityRestLiteDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using System;
    using System.ComponentModel;
    using Halfblood.Common;

    public partial class CertificateQualityRestLiteDto : INotifyPropertyChanging, INotifyPropertyChanged, IDto<long>
    {
        private static readonly PropertyChangingEventArgs emptyChangingEventArgs =
            new PropertyChangingEventArgs(string.Empty);

        #region Fields
        private long _rn;
        object IHasUid.Rn { get { return Rn; } }
        private DateTime _creationDate;
        private string _marka;
        private string _cast;
        private string _fullRepresentation;
        private string _gostMarka;
        private string _gostMix;
        private DateTime _makingDate;
        private Decimal _numb;
        private string _pref;
        private string _nomerCertificate;
        private string _note;
        private string _mix;
        private DateTime _storageDate;
        private string _standardStandardSize;
        private long _rnUserCreator;
        private string _userCreator;
        private string _creatorFactory;
        private long _rnCreatorFactory;
        private string _pass;
        private decimal? _rest;
        private string _nameOfCurrency;
        private string _store;
        private DateTime _stateDate;
        private QualityCertificateState _state;
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
        //==============================================================================================================================================
        private string _gostCast;
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

        private string _sizes;
        public virtual string Sizes
        {
            get
            {
                return this._sizes;
            }
            set
            {
                if (this._sizes != value)
                {
                    this.SendPropertyChanging();
                    this._sizes = value;
                    this.SendPropertyChanged("Sizes");
                }
            }
        }
        //==============================================================================================================================================

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
        public virtual DateTime CreationDate
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
        public virtual string GostMarka
        {
            get
            {
                return this._gostMarka;
            }

            set
            {
                if (this._gostMarka != value)
                {
                    this.SendPropertyChanging();
                    this._gostMarka = value;
                    this.SendPropertyChanged("GostCast");
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
        public virtual DateTime MakingDate
        {
            get
            {
                return this._makingDate;
            }

            set
            {
                if (this._makingDate != value)
                {
                    this.SendPropertyChanging();
                    this._makingDate = value;
                    this.SendPropertyChanged("MakingDate");
                }
            }
        }
        public virtual Decimal Numb
        {
            get
            {
                return this._numb;
            }

            set
            {
                if (this._numb != value)
                {
                    this.SendPropertyChanging();
                    this._numb = value;
                    this.SendPropertyChanged("Numb");
                }
            }
        }
        public virtual string Pref
        {
            get
            {
                return this._pref;
            }

            set
            {
                if (this._pref != value)
                {
                    this.SendPropertyChanging();
                    this._pref = value;
                    this.SendPropertyChanged("Pref");
                }
            }
        }
        public virtual string NomerCertificate
        {
            get
            {
                return this._nomerCertificate;
            }

            set
            {
                if (this._nomerCertificate != value)
                {
                    this.SendPropertyChanging();
                    this._nomerCertificate = value;
                    this.SendPropertyChanged("NomerCertificate");
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
        public virtual DateTime StorageDate
        {
            get
            {
                return this._storageDate;
            }

            set
            {
                if (this._storageDate != value)
                {
                    this.SendPropertyChanging();
                    this._storageDate = value;
                    this.SendPropertyChanged("StorageDate");
                }
            }
        }
        public virtual string StandardSize
        {
            get
            {
                return this._standardStandardSize;
            }

            set
            {
                if (this._standardStandardSize != value)
                {
                    this.SendPropertyChanging();
                    this._standardStandardSize = value;
                    this.SendPropertyChanged("StandardSize");
                }
            }
        }
        public virtual long RnUserCreator
        {
            get
            {
                return this._rnUserCreator;
            }

            set
            {
                if (this._rnUserCreator != value)
                {
                    this.SendPropertyChanging();
                    this._rnUserCreator = value;
                    this.SendPropertyChanged("RnUserCreator");
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
        public virtual string CreatorFactory
        {
            get
            {
                return this._creatorFactory;
            }

            set
            {
                if (this._creatorFactory != value)
                {
                    this.SendPropertyChanging();
                    this._creatorFactory = value;
                    this.SendPropertyChanged("CreatorFactory");
                }
            }
        }
        public virtual long RnCreatorFactory
        {
            get
            {
                return this._rnCreatorFactory;
            }

            set
            {
                if (this._rnCreatorFactory != value)
                {
                    this.SendPropertyChanging();
                    this._rnCreatorFactory = value;
                    this.SendPropertyChanged("RnCreatorFactory");
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
        public virtual Decimal? Rest
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
        public virtual string Store
        {
            get
            {
                return this._store;
            }

            set
            {
                if (this._store != value)
                {
                    this.SendPropertyChanging();
                    this._store = value;
                    this.SendPropertyChanged("Store");
                }
            }
        }
        public virtual String NameOfCurrency
        {
            get
            {
                return this._nameOfCurrency;
            }

            set
            {
                if (this._nameOfCurrency != value)
                {
                    this.SendPropertyChanging();
                    this._nameOfCurrency = value;
                    this.SendPropertyChanged("NameOfCurrency");
                }
            }
        }
        public virtual DateTime StateDate
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
        public virtual QualityCertificateState State
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
                    this.SendPropertyChanged("StandardSize");
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
            var toCompare = obj as CertificateQualityRestLiteDto;
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
