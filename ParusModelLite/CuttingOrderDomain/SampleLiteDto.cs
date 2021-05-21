// --------------------------------------------------------------------------------------------------------------------
// <copyright company="VZ" file="SampleLiteDto.cs">
//   maratoss && offan && kesar && icesun
// </copyright>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModelLite.CuttingOrderDomain
{
    using System.ComponentModel;

    using Halfblood.Common;

    /// <summary>
    /// There are no comments for ParusModelLite.CuttingOrderDomain.SampleLiteDto, ParusModelLite in the schema.
    /// </summary>
    public partial class SampleLiteDto : INotifyPropertyChanging, INotifyPropertyChanged, IDto<long>
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
        /// The _ nom modif.
        /// </summary>
        private long _NomModif;

        /// <summary>
        /// The _ nom modif code.
        /// </summary>
        private string _NomModifCode;

        /// <summary>
        /// The _ count.
        /// </summary>
        private long _Count;

        /// <summary>
        /// The _ batch size.
        /// </summary>
        private long _BatchSize;

        /// <summary>
        /// The _ geometrics length.
        /// </summary>
        private long? _GeometricsLength;

        /// <summary>
        /// The _ geometrics width.
        /// </summary>
        private long? _GeometricsWidth;

        /// <summary>
        /// The _ measure.
        /// </summary>
        private long _Measure;

        /// <summary>
        /// The _ norm expense.
        /// </summary>
        private long _NormExpense;

        /// <summary>
        /// The _ weight.
        /// </summary>
        private long? _Weight;

        /// <summary>
        /// The _ note.
        /// </summary>
        private string _Note;

        /// <summary>
        /// The _ measure name.
        /// </summary>
        private string _MeasureName;

        /// <summary>
        /// The _ creator.
        /// </summary>
        private long _Creator;

        /// <summary>
        /// The _ creator name.
        /// </summary>
        private string _CreatorName;

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
            SampleLiteDto toCompare = obj as SampleLiteDto;
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
        /// There are no comments for OnNomModifChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnNomModifChanging(long value);


        /// <summary>
        /// There are no comments for OnNomModifChanged in the schema.
        /// </summary>
        partial void OnNomModifChanged();

        /// <summary>
        /// There are no comments for OnNomModifCodeChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnNomModifCodeChanging(string value);


        /// <summary>
        /// There are no comments for OnNomModifCodeChanged in the schema.
        /// </summary>
        partial void OnNomModifCodeChanged();

        /// <summary>
        /// There are no comments for OnCountChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnCountChanging(long value);


        /// <summary>
        /// There are no comments for OnCountChanged in the schema.
        /// </summary>
        partial void OnCountChanged();

        /// <summary>
        /// There are no comments for OnBatchSizeChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnBatchSizeChanging(long value);


        /// <summary>
        /// There are no comments for OnBatchSizeChanged in the schema.
        /// </summary>
        partial void OnBatchSizeChanged();

        /// <summary>
        /// There are no comments for OnGeometricsLengthChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnGeometricsLengthChanging(long? value);


        /// <summary>
        /// There are no comments for OnGeometricsLengthChanged in the schema.
        /// </summary>
        partial void OnGeometricsLengthChanged();

        /// <summary>
        /// There are no comments for OnGeometricsWidthChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnGeometricsWidthChanging(long? value);


        /// <summary>
        /// There are no comments for OnGeometricsWidthChanged in the schema.
        /// </summary>
        partial void OnGeometricsWidthChanged();

        /// <summary>
        /// There are no comments for OnMeasureChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnMeasureChanging(long value);


        /// <summary>
        /// There are no comments for OnMeasureChanged in the schema.
        /// </summary>
        partial void OnMeasureChanged();

        /// <summary>
        /// There are no comments for OnNormExpenseChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnNormExpenseChanging(long value);


        /// <summary>
        /// There are no comments for OnNormExpenseChanged in the schema.
        /// </summary>
        partial void OnNormExpenseChanged();

        /// <summary>
        /// There are no comments for OnWeightChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnWeightChanging(long? value);


        /// <summary>
        /// There are no comments for OnWeightChanged in the schema.
        /// </summary>
        partial void OnWeightChanged();

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
        /// There are no comments for OnMeasureNameChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnMeasureNameChanging(string value);


        /// <summary>
        /// There are no comments for OnMeasureNameChanged in the schema.
        /// </summary>
        partial void OnMeasureNameChanged();

        /// <summary>
        /// There are no comments for OnCreatorChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnCreatorChanging(long value);


        /// <summary>
        /// There are no comments for OnCreatorChanged in the schema.
        /// </summary>
        partial void OnCreatorChanged();

        /// <summary>
        /// There are no comments for OnCreatorNameChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnCreatorNameChanging(string value);


        /// <summary>
        /// There are no comments for OnCreatorNameChanged in the schema.
        /// </summary>
        partial void OnCreatorNameChanged();

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
        /// Initializes a new instance of the <see cref="SampleLiteDto"/> class. 
        /// There are no comments for SampleLiteDto constructor in the schema.
        /// </summary>
        public SampleLiteDto()
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
        /// There are no comments for NomModif in the schema.
        /// </summary>
        public virtual long NomModif
        {
            get
            {
                return this._NomModif;
            }

            set
            {
                if (this._NomModif != value)
                {
                    this.OnNomModifChanging(value);
                    this.SendPropertyChanging();
                    this._NomModif = value;
                    this.SendPropertyChanged("NomModif");
                    this.OnNomModifChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for NomModifCode in the schema.
        /// </summary>
        public virtual string NomModifCode
        {
            get
            {
                return this._NomModifCode;
            }

            set
            {
                if (this._NomModifCode != value)
                {
                    this.OnNomModifCodeChanging(value);
                    this.SendPropertyChanging();
                    this._NomModifCode = value;
                    this.SendPropertyChanged("NomModifCode");
                    this.OnNomModifCodeChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for CountByDocument in the schema.
        /// </summary>
        public virtual long Count
        {
            get
            {
                return this._Count;
            }

            set
            {
                if (this._Count != value)
                {
                    this.OnCountChanging(value);
                    this.SendPropertyChanging();
                    this._Count = value;
                    this.SendPropertyChanged("CountByDocument");
                    this.OnCountChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for BatchSize in the schema.
        /// </summary>
        public virtual long BatchSize
        {
            get
            {
                return this._BatchSize;
            }

            set
            {
                if (this._BatchSize != value)
                {
                    this.OnBatchSizeChanging(value);
                    this.SendPropertyChanging();
                    this._BatchSize = value;
                    this.SendPropertyChanged("BatchSize");
                    this.OnBatchSizeChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for GeometricsLength in the schema.
        /// </summary>
        public virtual long? GeometricsLength
        {
            get
            {
                return this._GeometricsLength;
            }

            set
            {
                if (this._GeometricsLength != value)
                {
                    this.OnGeometricsLengthChanging(value);
                    this.SendPropertyChanging();
                    this._GeometricsLength = value;
                    this.SendPropertyChanged("GeometricsLength");
                    this.OnGeometricsLengthChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for GeometricsWidth in the schema.
        /// </summary>
        public virtual long? GeometricsWidth
        {
            get
            {
                return this._GeometricsWidth;
            }

            set
            {
                if (this._GeometricsWidth != value)
                {
                    this.OnGeometricsWidthChanging(value);
                    this.SendPropertyChanging();
                    this._GeometricsWidth = value;
                    this.SendPropertyChanged("GeometricsWidth");
                    this.OnGeometricsWidthChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for Measure in the schema.
        /// </summary>
        public virtual long Measure
        {
            get
            {
                return this._Measure;
            }

            set
            {
                if (this._Measure != value)
                {
                    this.OnMeasureChanging(value);
                    this.SendPropertyChanging();
                    this._Measure = value;
                    this.SendPropertyChanged("Measure");
                    this.OnMeasureChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for NormExpense in the schema.
        /// </summary>
        public virtual long NormExpense
        {
            get
            {
                return this._NormExpense;
            }

            set
            {
                if (this._NormExpense != value)
                {
                    this.OnNormExpenseChanging(value);
                    this.SendPropertyChanging();
                    this._NormExpense = value;
                    this.SendPropertyChanged("NormExpense");
                    this.OnNormExpenseChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for Weight in the schema.
        /// </summary>
        public virtual long? Weight
        {
            get
            {
                return this._Weight;
            }

            set
            {
                if (this._Weight != value)
                {
                    this.OnWeightChanging(value);
                    this.SendPropertyChanging();
                    this._Weight = value;
                    this.SendPropertyChanged("Weight");
                    this.OnWeightChanged();
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
        /// There are no comments for MeasureName in the schema.
        /// </summary>
        public virtual string MeasureName
        {
            get
            {
                return this._MeasureName;
            }

            set
            {
                if (this._MeasureName != value)
                {
                    this.OnMeasureNameChanging(value);
                    this.SendPropertyChanging();
                    this._MeasureName = value;
                    this.SendPropertyChanged("MeasureName");
                    this.OnMeasureNameChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for Creator in the schema.
        /// </summary>
        public virtual long Creator
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
        /// There are no comments for CreatorName in the schema.
        /// </summary>
        public virtual string CreatorName
        {
            get
            {
                return this._CreatorName;
            }

            set
            {
                if (this._CreatorName != value)
                {
                    this.OnCreatorNameChanging(value);
                    this.SendPropertyChanging();
                    this._CreatorName = value;
                    this.SendPropertyChanged("CreatorName");
                    this.OnCreatorNameChanged();
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
