// --------------------------------------------------------------------------------------------------------------------
// <copyright company="VZ" file="CertificationLiteDto.cs">
//   maratoss && offan && kesar && icesun
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModelLite.CuttingOrderDomain
{
    using System.ComponentModel;

    using Halfblood.Common;

    /// <summary>
    /// There are no comments for ParusModelLite.CuttingOrderDomain.CertificationLiteDto, ParusModelLite in the schema.
    /// </summary>
    public partial class CertificationLiteDto : INotifyPropertyChanging, INotifyPropertyChanged, IDto<long>
    {
        /// <summary>
        /// The empty changing event args.
        /// </summary>
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

        object IHasUid.Rn { get { return Rn; } }

        /// <summary>
        /// The _ rn.
        /// </summary>
        private long _Rn;

        /// <summary>
        /// The _ prn.
        /// </summary>
        private long _Prn;

        /// <summary>
        /// The _ trans inv dept specs.
        /// </summary>
        private long _TransInvDeptSpecs;

        #region Extensibility Method Definitions

        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();

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
            CertificationLiteDto toCompare = obj as CertificationLiteDto;
            if (toCompare == null)
            {
                return false;
            }

            if (!Equals(this.Rn, toCompare.Rn))
                return false;

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

        /// <summary>
        /// There are no comments for OnRnChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnRnChanging(long value);

        /// <summary>
        /// There are no comments for OnRnChanged in the schema.
        /// </summary>
        partial void OnRnChanged();

        /// <summary>
        /// There are no comments for OnPrnChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnPrnChanging(long value);

        /// <summary>
        /// There are no comments for OnPrnChanged in the schema.
        /// </summary>
        partial void OnPrnChanged();

        /// <summary>
        /// There are no comments for OnTransInvDeptSpecsChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnTransInvDeptSpecsChanging(long value);

        /// <summary>
        /// There are no comments for OnTransInvDeptSpecsChanged in the schema.
        /// </summary>
        partial void OnTransInvDeptSpecsChanged();

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificationLiteDto"/> class. 
        /// There are no comments for CertificationLiteDto constructor in the schema.
        /// </summary>
        public CertificationLiteDto()
        {
            this.OnCreated();
        }

        /// <summary>
        /// There are no comments for Rn in the schema.
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
                    this.OnRnChanging(value);
                    this.SendPropertyChanging();
                    this._Rn = value;
                    this.SendPropertyChanged("Rn");
                    this.OnRnChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for Prn in the schema.
        /// </summary>
        public virtual long Prn
        {
            get
            {
                return this._Prn;
            }

            set
            {
                if (this._Prn != value)
                {
                    this.OnPrnChanging(value);
                    this.SendPropertyChanging();
                    this._Prn = value;
                    this.SendPropertyChanged("Prn");
                    this.OnPrnChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for TransInvDeptSpecs in the schema.
        /// </summary>
        public virtual long TransInvDeptSpecs
        {
            get
            {
                return this._TransInvDeptSpecs;
            }

            set
            {
                if (this._TransInvDeptSpecs != value)
                {
                    this.OnTransInvDeptSpecsChanging(value);
                    this.SendPropertyChanging();
                    this._TransInvDeptSpecs = value;
                    this.SendPropertyChanged("TransInvDeptSpecs");
                    this.OnTransInvDeptSpecsChanged();
                }
            }
        }

        /// <summary>
        /// The property changing.
        /// </summary>
        public virtual event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// The property changed.
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The send property changing.
        /// </summary>
        protected virtual void SendPropertyChanging()
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        /// <summary>
        /// The send property changing.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void SendPropertyChanging(string propertyName)
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        /// <summary>
        /// The send property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void SendPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
