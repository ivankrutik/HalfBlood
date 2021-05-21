// --------------------------------------------------------------------------------------------------------------------
// <copyright company="VZ" file="CuttingOrderMoveLiteDto.cs">
//   maratoss && offan && kesar && icesun
// </copyright>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModelLite.CuttingOrderDomain
{
    using System;
    using System.ComponentModel;

    using Halfblood.Common;

    /// <summary>
    /// There are no comments for ParusModelLite.CuttingOrderDomain.CuttingOrderMoveLiteDto, ParusModelLite in the schema.
    /// </summary>
    public partial class CuttingOrderMoveLiteDto : INotifyPropertyChanging, INotifyPropertyChanged, IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }

        /// <summary>
        /// The empty changing event args.
        /// </summary>
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

        /// <summary>
        /// The _ rn.
        /// </summary>
        private long _Rn;

        /// <summary>
        /// The _ prn.
        /// </summary>
        private long _Prn;

        /// <summary>
        /// The _ creation date.
        /// </summary>
        private DateTime _CreationDate;

        /// <summary>
        /// The _ note.
        /// </summary>
        private string _Note;

        /// <summary>
        /// The _ recipient.
        /// </summary>
        private long _Recipient;

        /// <summary>
        /// The _ recipient name.
        /// </summary>
        private string _RecipientName;

        /// <summary>
        /// The _ creator.
        /// </summary>
        private long? _Creator;

        /// <summary>
        /// The _ recipient memo.
        /// </summary>
        private string _RecipientMemo;

        /// <summary>
        /// The _ creator memo.
        /// </summary>
        private string _CreatorMemo;

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
            CuttingOrderMoveLiteDto toCompare = obj as CuttingOrderMoveLiteDto;
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
        /// There are no comments for OnCreationDateChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnCreationDateChanging(DateTime value);


        /// <summary>
        /// There are no comments for OnCreationDateChanged in the schema.
        /// </summary>
        partial void OnCreationDateChanged();

        /// <summary>
        /// There are no comments for OnNoteChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnNoteChanging(string value);


        /// <summary>
        /// There are no comments for OnNoteChanged in the schema.
        /// </summary>
        partial void OnNoteChanged();

        /// <summary>
        /// There are no comments for OnRecipientChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnRecipientChanging(long value);


        /// <summary>
        /// There are no comments for OnRecipientChanged in the schema.
        /// </summary>
        partial void OnRecipientChanged();

        /// <summary>
        /// There are no comments for OnRecipientNameChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnRecipientNameChanging(string value);


        /// <summary>
        /// There are no comments for OnRecipientNameChanged in the schema.
        /// </summary>
        partial void OnRecipientNameChanged();

        /// <summary>
        /// There are no comments for OnCreatorChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnCreatorChanging(long? value);


        /// <summary>
        /// There are no comments for OnCreatorChanged in the schema.
        /// </summary>
        partial void OnCreatorChanged();

        /// <summary>
        /// There are no comments for OnRecipientMemoChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnRecipientMemoChanging(string value);


        /// <summary>
        /// There are no comments for OnRecipientMemoChanged in the schema.
        /// </summary>
        partial void OnRecipientMemoChanged();

        /// <summary>
        /// There are no comments for OnCreatorMemoChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnCreatorMemoChanging(string value);


        /// <summary>
        /// There are no comments for OnCreatorMemoChanged in the schema.
        /// </summary>
        partial void OnCreatorMemoChanged();

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CuttingOrderMoveLiteDto"/> class. 
        /// There are no comments for CuttingOrderMoveLiteDto constructor in the schema.
        /// </summary>
        public CuttingOrderMoveLiteDto()
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
        /// There are no comments for CreationDate in the schema.
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
                    this.OnCreationDateChanging(value);
                    this.SendPropertyChanging();
                    this._CreationDate = value;
                    this.SendPropertyChanged("CreationDate");
                    this.OnCreationDateChanged();
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
                return this._Note;
            }

            set
            {
                if (this._Note != value)
                {
                    this.OnNoteChanging(value);
                    this.SendPropertyChanging();
                    this._Note = value;
                    this.SendPropertyChanged("Note");
                    this.OnNoteChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for Recipient in the schema.
        /// </summary>
        
        public virtual long Recipient
        {
            get
            {
                return this._Recipient;
            }

            set
            {
                if (this._Recipient != value)
                {
                    this.OnRecipientChanging(value);
                    this.SendPropertyChanging();
                    this._Recipient = value;
                    this.SendPropertyChanged("Recipient");
                    this.OnRecipientChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for RecipientName in the schema.
        /// </summary>
        
        public virtual string RecipientName
        {
            get
            {
                return this._RecipientName;
            }

            set
            {
                if (this._RecipientName != value)
                {
                    this.OnRecipientNameChanging(value);
                    this.SendPropertyChanging();
                    this._RecipientName = value;
                    this.SendPropertyChanged("RecipientName");
                    this.OnRecipientNameChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for Creator in the schema.
        /// </summary>
        
        public virtual long? Creator
        {
            get
            {
                return this._Creator;
            }

            set
            {
                if (this._Creator != value)
                {
                    this.OnCreatorChanging(value);
                    this.SendPropertyChanging();
                    this._Creator = value;
                    this.SendPropertyChanged("Creator");
                    this.OnCreatorChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for RecipientMemo in the schema.
        /// </summary>
        
        public virtual string RecipientMemo
        {
            get
            {
                return this._RecipientMemo;
            }

            set
            {
                if (this._RecipientMemo != value)
                {
                    this.OnRecipientMemoChanging(value);
                    this.SendPropertyChanging();
                    this._RecipientMemo = value;
                    this.SendPropertyChanged("RecipientMemo");
                    this.OnRecipientMemoChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for CreatorMemo in the schema.
        /// </summary>
        
        public virtual string CreatorMemo
        {
            get
            {
                return this._CreatorMemo;
            }

            set
            {
                if (this._CreatorMemo != value)
                {
                    this.OnCreatorMemoChanging(value);
                    this.SendPropertyChanging();
                    this._CreatorMemo = value;
                    this.SendPropertyChanged("CreatorMemo");
                    this.OnCreatorMemoChanged();
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
