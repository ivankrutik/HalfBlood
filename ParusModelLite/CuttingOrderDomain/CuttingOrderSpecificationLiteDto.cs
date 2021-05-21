// --------------------------------------------------------------------------------------------------------------------
// <copyright company="VZ" file="CuttingOrderSpecificationLiteDto.cs">
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
    /// There are no comments for ParusModelLite.CuttingOrderDomain.CuttingOrderSpecificationLiteDto, ParusModelLite in the schema.
    /// </summary>
    public partial class CuttingOrderSpecificationLiteDto : INotifyPropertyChanging, INotifyPropertyChanged, IDto<long>
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
        /// The _ state.
        /// </summary>
        private bool _State;

        /// <summary>
        /// The _ creation date.
        /// </summary>
        private DateTime _CreationDate;

        /// <summary>
        /// The _ assume date.
        /// </summary>
        private DateTime? _AssumeDate;

        /// <summary>
        /// The _ nom modif.
        /// </summary>
        private long _NomModif;

        /// <summary>
        /// The _ nom modif code.
        /// </summary>
        private string _NomModifCode;

        /// <summary>
        /// The _ inspector.
        /// </summary>
        private long? _Inspector;

        /// <summary>
        /// The _ inspector name.
        /// </summary>
        private string _InspectorName;

        /// <summary>
        /// The _ recipient.
        /// </summary>
        private long _Recipient;

        /// <summary>
        /// The _ recipient name.
        /// </summary>
        private string _RecipientName;

        /// <summary>
        /// The _ PersonalAccount.
        /// </summary>
        private long _PersonalAccount;

        /// <summary>
        /// The _ norm expense.
        /// </summary>
        private long _NormExpense;

        /// <summary>
        /// The _ count part with blank.
        /// </summary>
        private long? _CountPartWithBlank;

        /// <summary>
        /// The _ measure norm.
        /// </summary>
        private long? _MeasureNorm;

        /// <summary>
        /// The _ measure weight.
        /// </summary>
        private long? _MeasureWeight;

        /// <summary>
        /// The _ measure weight name.
        /// </summary>
        private string _MeasureWeightName;

        /// <summary>
        /// The _ measure norm name.
        /// </summary>
        private string _MeasureNormName;

        /// <summary>
        /// The _ part blank weight.
        /// </summary>
        private long? _PartBlankWeight;

        /// <summary>
        /// The _ part blank lenght.
        /// </summary>
        private long? _PartBlankLenght;

        /// <summary>
        /// The _ part blank width.
        /// </summary>
        private long? _PartBlankWidth;

        /// <summary>
        /// The _ max deflection lenght.
        /// </summary>
        private long? _MaxDeflectionLenght;

        /// <summary>
        /// The _ min deflection lenght.
        /// </summary>
        private long? _MinDeflectionLenght;

        /// <summary>
        /// The _ demand contract.
        /// </summary>
        private long? _DemandContract;

        /// <summary>
        /// The _ demand goods.
        /// </summary>
        private long? _DemandGoods;

        /// <summary>
        /// The _ demand plan month.
        /// </summary>
        private long? _DemandPlanMonth;

        /// <summary>
        /// The _ controler.
        /// </summary>
        private string _Controler;

        /// <summary>
        /// The _ PersonalAccount name.
        /// </summary>
        private string _PersonalAccountName;

        /// <summary>
        /// The _ creator.
        /// </summary>
        private long _Creator;

        /// <summary>
        /// The _ creator memo.
        /// </summary>
        private string _CreatorMemo;

        /// <summary>
        /// The _ creator name.
        /// </summary>
        private string _CreatorName;

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
            CuttingOrderSpecificationLiteDto toCompare = obj as CuttingOrderSpecificationLiteDto;
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
        /// There are no comments for OnStateChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnStateChanging(bool value);


        /// <summary>
        /// There are no comments for OnStateChanged in the schema.
        /// </summary>
        partial void OnStateChanged();

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
        /// There are no comments for OnAssumeDateChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnAssumeDateChanging(DateTime? value);


        /// <summary>
        /// There are no comments for OnAssumeDateChanged in the schema.
        /// </summary>
        partial void OnAssumeDateChanged();

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
        /// There are no comments for OnInspectorChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnInspectorChanging(long? value);


        /// <summary>
        /// There are no comments for OnInspectorChanged in the schema.
        /// </summary>
        partial void OnInspectorChanged();

        /// <summary>
        /// There are no comments for OnInspectorNameChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnInspectorNameChanging(string value);


        /// <summary>
        /// There are no comments for OnInspectorNameChanged in the schema.
        /// </summary>
        partial void OnInspectorNameChanged();

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
        /// There are no comments for OnPersonalAccountChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnPersonalAccountChanging(long value);


        /// <summary>
        /// There are no comments for OnPersonalAccountChanged in the schema.
        /// </summary>
        partial void OnPersonalAccountChanged();

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
        /// There are no comments for OnCountPartWithBlankChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnCountPartWithBlankChanging(long? value);


        /// <summary>
        /// There are no comments for OnCountPartWithBlankChanged in the schema.
        /// </summary>
        partial void OnCountPartWithBlankChanged();

        /// <summary>
        /// There are no comments for OnMeasureNormChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnMeasureNormChanging(long? value);


        /// <summary>
        /// There are no comments for OnMeasureNormChanged in the schema.
        /// </summary>
        partial void OnMeasureNormChanged();

        /// <summary>
        /// There are no comments for OnMeasureWeightChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnMeasureWeightChanging(long? value);


        /// <summary>
        /// There are no comments for OnMeasureWeightChanged in the schema.
        /// </summary>
        partial void OnMeasureWeightChanged();

        /// <summary>
        /// There are no comments for OnMeasureWeightNameChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnMeasureWeightNameChanging(string value);


        /// <summary>
        /// There are no comments for OnMeasureWeightNameChanged in the schema.
        /// </summary>
        partial void OnMeasureWeightNameChanged();

        /// <summary>
        /// There are no comments for OnMeasureNormNameChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnMeasureNormNameChanging(string value);


        /// <summary>
        /// There are no comments for OnMeasureNormNameChanged in the schema.
        /// </summary>
        partial void OnMeasureNormNameChanged();

        /// <summary>
        /// There are no comments for OnPartBlankWeightChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnPartBlankWeightChanging(long? value);


        /// <summary>
        /// There are no comments for OnPartBlankWeightChanged in the schema.
        /// </summary>
        partial void OnPartBlankWeightChanged();

        /// <summary>
        /// There are no comments for OnPartBlankLenghtChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnPartBlankLenghtChanging(long? value);


        /// <summary>
        /// There are no comments for OnPartBlankLenghtChanged in the schema.
        /// </summary>
        partial void OnPartBlankLenghtChanged();

        /// <summary>
        /// There are no comments for OnPartBlankWidthChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnPartBlankWidthChanging(long? value);


        /// <summary>
        /// There are no comments for OnPartBlankWidthChanged in the schema.
        /// </summary>
        partial void OnPartBlankWidthChanged();

        /// <summary>
        /// There are no comments for OnMaxDeflectionLenghtChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnMaxDeflectionLenghtChanging(long? value);


        /// <summary>
        /// There are no comments for OnMaxDeflectionLenghtChanged in the schema.
        /// </summary>
        partial void OnMaxDeflectionLenghtChanged();

        /// <summary>
        /// There are no comments for OnMinDeflectionLenghtChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnMinDeflectionLenghtChanging(long? value);


        /// <summary>
        /// There are no comments for OnMinDeflectionLenghtChanged in the schema.
        /// </summary>
        partial void OnMinDeflectionLenghtChanged();

        /// <summary>
        /// There are no comments for OnDemandContractChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnDemandContractChanging(long? value);


        /// <summary>
        /// There are no comments for OnDemandContractChanged in the schema.
        /// </summary>
        partial void OnDemandContractChanged();

        /// <summary>
        /// There are no comments for OnDemandGoodsChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnDemandGoodsChanging(long? value);


        /// <summary>
        /// There are no comments for OnDemandGoodsChanged in the schema.
        /// </summary>
        partial void OnDemandGoodsChanged();

        /// <summary>
        /// There are no comments for OnDemandPlanMonthChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnDemandPlanMonthChanging(long? value);


        /// <summary>
        /// There are no comments for OnDemandPlanMonthChanged in the schema.
        /// </summary>
        partial void OnDemandPlanMonthChanged();

        /// <summary>
        /// There are no comments for OnControlerChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnControlerChanging(string value);


        /// <summary>
        /// There are no comments for OnControlerChanged in the schema.
        /// </summary>
        partial void OnControlerChanged();

        /// <summary>
        /// There are no comments for OnPersonalAccountNameChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnPersonalAccountNameChanging(string value);


        /// <summary>
        /// There are no comments for OnPersonalAccountNameChanged in the schema.
        /// </summary>
        partial void OnPersonalAccountNameChanged();

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

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CuttingOrderSpecificationLiteDto"/> class. 
        /// There are no comments for CuttingOrderSpecificationLiteDto constructor in the schema.
        /// </summary>
        public CuttingOrderSpecificationLiteDto()
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
        /// There are no comments for State in the schema.
        /// </summary>
        
        public virtual bool State
        {
            get
            {
                return this._State;
            }

            set
            {
                if (this._State != value)
                {
                    this.OnStateChanging(value);
                    this.SendPropertyChanging();
                    this._State = value;
                    this.SendPropertyChanged("State");
                    this.OnStateChanged();
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
        /// There are no comments for AssumeDate in the schema.
        /// </summary>
        
        public virtual DateTime? AssumeDate
        {
            get
            {
                return this._AssumeDate;
            }

            set
            {
                if (this._AssumeDate != value)
                {
                    this.OnAssumeDateChanging(value);
                    this.SendPropertyChanging();
                    this._AssumeDate = value;
                    this.SendPropertyChanged("AssumeDate");
                    this.OnAssumeDateChanged();
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
        /// There are no comments for Inspector in the schema.
        /// </summary>
        
        public virtual long? Inspector
        {
            get
            {
                return this._Inspector;
            }

            set
            {
                if (this._Inspector != value)
                {
                    this.OnInspectorChanging(value);
                    this.SendPropertyChanging();
                    this._Inspector = value;
                    this.SendPropertyChanged("Inspector");
                    this.OnInspectorChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for InspectorName in the schema.
        /// </summary>
        
        public virtual string InspectorName
        {
            get
            {
                return this._InspectorName;
            }

            set
            {
                if (this._InspectorName != value)
                {
                    this.OnInspectorNameChanging(value);
                    this.SendPropertyChanging();
                    this._InspectorName = value;
                    this.SendPropertyChanged("InspectorName");
                    this.OnInspectorNameChanged();
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
        /// There are no comments for PersonalAccount in the schema.
        /// </summary>
        
        public virtual long PersonalAccount
        {
            get
            {
                return this._PersonalAccount;
            }

            set
            {
                if (this._PersonalAccount != value)
                {
                    this.OnPersonalAccountChanging(value);
                    this.SendPropertyChanging();
                    this._PersonalAccount = value;
                    this.SendPropertyChanged("PersonalAccount");
                    this.OnPersonalAccountChanged();
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
        /// There are no comments for CountPartWithBlank in the schema.
        /// </summary>
        
        public virtual long? CountPartWithBlank
        {
            get
            {
                return this._CountPartWithBlank;
            }

            set
            {
                if (this._CountPartWithBlank != value)
                {
                    this.OnCountPartWithBlankChanging(value);
                    this.SendPropertyChanging();
                    this._CountPartWithBlank = value;
                    this.SendPropertyChanged("CountPartWithBlank");
                    this.OnCountPartWithBlankChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for MeasureNorm in the schema.
        /// </summary>
        
        public virtual long? MeasureNorm
        {
            get
            {
                return this._MeasureNorm;
            }

            set
            {
                if (this._MeasureNorm != value)
                {
                    this.OnMeasureNormChanging(value);
                    this.SendPropertyChanging();
                    this._MeasureNorm = value;
                    this.SendPropertyChanged("MeasureNorm");
                    this.OnMeasureNormChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for MeasureWeight in the schema.
        /// </summary>
        
        public virtual long? MeasureWeight
        {
            get
            {
                return this._MeasureWeight;
            }

            set
            {
                if (this._MeasureWeight != value)
                {
                    this.OnMeasureWeightChanging(value);
                    this.SendPropertyChanging();
                    this._MeasureWeight = value;
                    this.SendPropertyChanged("MeasureWeight");
                    this.OnMeasureWeightChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for MeasureWeightName in the schema.
        /// </summary>
        
        public virtual string MeasureWeightName
        {
            get
            {
                return this._MeasureWeightName;
            }

            set
            {
                if (this._MeasureWeightName != value)
                {
                    this.OnMeasureWeightNameChanging(value);
                    this.SendPropertyChanging();
                    this._MeasureWeightName = value;
                    this.SendPropertyChanged("MeasureWeightName");
                    this.OnMeasureWeightNameChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for MeasureNormName in the schema.
        /// </summary>
        
        public virtual string MeasureNormName
        {
            get
            {
                return this._MeasureNormName;
            }

            set
            {
                if (this._MeasureNormName != value)
                {
                    this.OnMeasureNormNameChanging(value);
                    this.SendPropertyChanging();
                    this._MeasureNormName = value;
                    this.SendPropertyChanged("MeasureNormName");
                    this.OnMeasureNormNameChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for PartBlankWeight in the schema.
        /// </summary>
        
        public virtual long? PartBlankWeight
        {
            get
            {
                return this._PartBlankWeight;
            }

            set
            {
                if (this._PartBlankWeight != value)
                {
                    this.OnPartBlankWeightChanging(value);
                    this.SendPropertyChanging();
                    this._PartBlankWeight = value;
                    this.SendPropertyChanged("PartBlankWeight");
                    this.OnPartBlankWeightChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for PartBlankLenght in the schema.
        /// </summary>
        
        public virtual long? PartBlankLenght
        {
            get
            {
                return this._PartBlankLenght;
            }

            set
            {
                if (this._PartBlankLenght != value)
                {
                    this.OnPartBlankLenghtChanging(value);
                    this.SendPropertyChanging();
                    this._PartBlankLenght = value;
                    this.SendPropertyChanged("PartBlankLenght");
                    this.OnPartBlankLenghtChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for PartBlankWidth in the schema.
        /// </summary>
        
        public virtual long? PartBlankWidth
        {
            get
            {
                return this._PartBlankWidth;
            }

            set
            {
                if (this._PartBlankWidth != value)
                {
                    this.OnPartBlankWidthChanging(value);
                    this.SendPropertyChanging();
                    this._PartBlankWidth = value;
                    this.SendPropertyChanged("PartBlankWidth");
                    this.OnPartBlankWidthChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for MaxDeflectionLenght in the schema.
        /// </summary>
        
        public virtual long? MaxDeflectionLenght
        {
            get
            {
                return this._MaxDeflectionLenght;
            }

            set
            {
                if (this._MaxDeflectionLenght != value)
                {
                    this.OnMaxDeflectionLenghtChanging(value);
                    this.SendPropertyChanging();
                    this._MaxDeflectionLenght = value;
                    this.SendPropertyChanged("MaxDeflectionLenght");
                    this.OnMaxDeflectionLenghtChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for MinDeflectionLenght in the schema.
        /// </summary>
        
        public virtual long? MinDeflectionLenght
        {
            get
            {
                return this._MinDeflectionLenght;
            }

            set
            {
                if (this._MinDeflectionLenght != value)
                {
                    this.OnMinDeflectionLenghtChanging(value);
                    this.SendPropertyChanging();
                    this._MinDeflectionLenght = value;
                    this.SendPropertyChanged("MinDeflectionLenght");
                    this.OnMinDeflectionLenghtChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for DemandContract in the schema.
        /// </summary>
        
        public virtual long? DemandContract
        {
            get
            {
                return this._DemandContract;
            }

            set
            {
                if (this._DemandContract != value)
                {
                    this.OnDemandContractChanging(value);
                    this.SendPropertyChanging();
                    this._DemandContract = value;
                    this.SendPropertyChanged("DemandContract");
                    this.OnDemandContractChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for DemandGoods in the schema.
        /// </summary>
        
        public virtual long? DemandGoods
        {
            get
            {
                return this._DemandGoods;
            }

            set
            {
                if (this._DemandGoods != value)
                {
                    this.OnDemandGoodsChanging(value);
                    this.SendPropertyChanging();
                    this._DemandGoods = value;
                    this.SendPropertyChanged("DemandGoods");
                    this.OnDemandGoodsChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for DemandPlanMonth in the schema.
        /// </summary>
        
        public virtual long? DemandPlanMonth
        {
            get
            {
                return this._DemandPlanMonth;
            }

            set
            {
                if (this._DemandPlanMonth != value)
                {
                    this.OnDemandPlanMonthChanging(value);
                    this.SendPropertyChanging();
                    this._DemandPlanMonth = value;
                    this.SendPropertyChanged("DemandPlanMonth");
                    this.OnDemandPlanMonthChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for Controler in the schema.
        /// </summary>
        
        public virtual string Controler
        {
            get
            {
                return this._Controler;
            }

            set
            {
                if (this._Controler != value)
                {
                    this.OnControlerChanging(value);
                    this.SendPropertyChanging();
                    this._Controler = value;
                    this.SendPropertyChanged("Controler");
                    this.OnControlerChanged();
                }
            }
        }



        /// <summary>
        /// There are no comments for PersonalAccountName in the schema.
        /// </summary>
        
        public virtual string PersonalAccountName
        {
            get
            {
                return this._PersonalAccountName;
            }

            set
            {
                if (this._PersonalAccountName != value)
                {
                    this.OnPersonalAccountNameChanging(value);
                    this.SendPropertyChanging();
                    this._PersonalAccountName = value;
                    this.SendPropertyChanged("PersonalAccountName");
                    this.OnPersonalAccountNameChanged();
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
