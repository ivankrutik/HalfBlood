// --------------------------------------------------------------------------------------------------------------------
// <copyright company="VZ" file="CuttingOrderLiteDto.cs">
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
    /// There are no comments for ParusModelLite.CuttingOrderDomain.CuttingOrderLiteDto, ParusModelLite in the schema.
    /// </summary>
    public partial class CuttingOrderLiteDto : INotifyPropertyChanging, INotifyPropertyChanged, IDto<long>
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
        /// The _ numb.
        /// </summary>
        private decimal _Numb;

        /// <summary>
        /// The _ pref.
        /// </summary>
        private string _Pref;

        /// <summary>
        /// The _ state.
        /// </summary>
        private bool _State;

        /// <summary>
        /// The _ note.
        /// </summary>
        private string _Note;

        /// <summary>
        /// The _ date document integration.
        /// </summary>
        private DateTime? _DateDocumentIntegration;

        /// <summary>
        /// The _ priority.
        /// </summary>
        private long? _Priority;

        /// <summary>
        /// The _ creation date.
        /// </summary>
        private DateTime _CreationDate;

        /// <summary>
        /// The _ assume date.
        /// </summary>
        private DateTime? _AssumeDate;

        /// <summary>
        /// The _ inspector.
        /// </summary>
        private long? _Inspector;

        /// <summary>
        /// The _ inspector name.
        /// </summary>
        private string _InspectorName;

        /// <summary>
        /// The _ storekeeper.
        /// </summary>
        private long? _Storekeeper;

        /// <summary>
        /// The _ storekeeper name.
        /// </summary>
        private string _StorekeeperName;

        /// <summary>
        /// The _ creator.
        /// </summary>
        private long _Creator;

        /// <summary>
        /// The _ creator name.
        /// </summary>
        private string _CreatorName;

        /// <summary>
        /// The _ department.
        /// </summary>
        private long _Department;

        /// <summary>
        /// The _ department code.
        /// </summary>
        private string _DepartmentCode;

        /// <summary>
        /// The _ district.
        /// </summary>
        private long _District;

        /// <summary>
        /// The _ district code.
        /// </summary>
        private string _DistrictCode;

        /// <summary>
        /// The _ inspector memo.
        /// </summary>
        private string _InspectorMemo;

        /// <summary>
        /// The _ creator memo.
        /// </summary>
        private string _CreatorMemo;

        /// <summary>
        /// The _ storekeeper memo.
        /// </summary>
        private string _StorekeeperMemo;

        /// <summary>
        /// The _ delivery date.
        /// </summary>
        private DateTime? _DeliveryDate;

        /// <summary>
        /// The _ packer.
        /// </summary>
        private long? _Packer;

        /// <summary>
        /// The _ packer memo.
        /// </summary>
        private string _PackerMemo;

        /// <summary>
        /// The _ packer name.
        /// </summary>
        private string _PackerName;

        /// <summary>
        /// The _ last date.
        /// </summary>
        private DateTime _LastDate;

        /// <summary>
        /// The _ last recipient.
        /// </summary>
        private long _LastRecipient;

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
            CuttingOrderLiteDto toCompare = obj as CuttingOrderLiteDto;
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
        /// There are no comments for OnNumbChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnNumbChanging(decimal value);

        /// <summary>
        /// There are no comments for OnNumbChanged in the schema.
        /// </summary>
        partial void OnNumbChanged();

        /// <summary>
        /// There are no comments for OnPrefChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnPrefChanging(string value);

        /// <summary>
        /// There are no comments for OnPrefChanged in the schema.
        /// </summary>
        partial void OnPrefChanged();

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
        /// There are no comments for OnDateDocumentIntegrationChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnDateDocumentIntegrationChanging(DateTime? value);

        /// <summary>
        /// There are no comments for OnDateDocumentIntegrationChanged in the schema.
        /// </summary>
        partial void OnDateDocumentIntegrationChanged();

        /// <summary>
        /// There are no comments for OnPriorityChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnPriorityChanging(long? value);

        /// <summary>
        /// There are no comments for OnPriorityChanged in the schema.
        /// </summary>
        partial void OnPriorityChanged();

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
        /// There are no comments for OnStorekeeperChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnStorekeeperChanging(long? value);

        /// <summary>
        /// There are no comments for OnStorekeeperChanged in the schema.
        /// </summary>
        partial void OnStorekeeperChanged();

        /// <summary>
        /// There are no comments for OnStorekeeperNameChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnStorekeeperNameChanging(string value);

        /// <summary>
        /// There are no comments for OnStorekeeperNameChanged in the schema.
        /// </summary>
        partial void OnStorekeeperNameChanged();

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
        /// There are no comments for OnDepartmentChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnDepartmentChanging(long value);

        /// <summary>
        /// There are no comments for OnDepartmentChanged in the schema.
        /// </summary>
        partial void OnDepartmentChanged();

        /// <summary>
        /// There are no comments for OnDepartmentCodeChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnDepartmentCodeChanging(string value);

        /// <summary>
        /// There are no comments for OnDepartmentCodeChanged in the schema.
        /// </summary>
        partial void OnDepartmentCodeChanged();

        /// <summary>
        /// There are no comments for OnDistrictChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnDistrictChanging(long value);

        /// <summary>
        /// There are no comments for OnDistrictChanged in the schema.
        /// </summary>
        partial void OnDistrictChanged();

        /// <summary>
        /// There are no comments for OnDistrictCodeChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnDistrictCodeChanging(string value);

        /// <summary>
        /// There are no comments for OnDistrictCodeChanged in the schema.
        /// </summary>
        partial void OnDistrictCodeChanged();

        /// <summary>
        /// There are no comments for OnInspectorMemoChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnInspectorMemoChanging(string value);

        /// <summary>
        /// There are no comments for OnInspectorMemoChanged in the schema.
        /// </summary>
        partial void OnInspectorMemoChanged();

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
        /// There are no comments for OnStorekeeperMemoChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnStorekeeperMemoChanging(string value);

        /// <summary>
        /// There are no comments for OnStorekeeperMemoChanged in the schema.
        /// </summary>
        partial void OnStorekeeperMemoChanged();

        /// <summary>
        /// There are no comments for OnDeliveryDateChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnDeliveryDateChanging(DateTime? value);

        /// <summary>
        /// There are no comments for OnDeliveryDateChanged in the schema.
        /// </summary>
        partial void OnDeliveryDateChanged();

        /// <summary>
        /// There are no comments for OnPackerChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnPackerChanging(long? value);

        /// <summary>
        /// There are no comments for OnPackerChanged in the schema.
        /// </summary>
        partial void OnPackerChanged();

        /// <summary>
        /// There are no comments for OnPackerMemoChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnPackerMemoChanging(string value);

        /// <summary>
        /// There are no comments for OnPackerMemoChanged in the schema.
        /// </summary>
        partial void OnPackerMemoChanged();

        /// <summary>
        /// There are no comments for OnPackerNameChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnPackerNameChanging(string value);

        /// <summary>
        /// There are no comments for OnPackerNameChanged in the schema.
        /// </summary>
        partial void OnPackerNameChanged();

        /// <summary>
        /// There are no comments for OnLastDateChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnLastDateChanging(DateTime value);

        /// <summary>
        /// There are no comments for OnLastDateChanged in the schema.
        /// </summary>
        partial void OnLastDateChanged();

        /// <summary>
        /// There are no comments for OnLastRecipientChanging in the schema.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        partial void OnLastRecipientChanging(long value);

        /// <summary>
        /// There are no comments for OnLastRecipientChanged in the schema.
        /// </summary>
        partial void OnLastRecipientChanged();

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CuttingOrderLiteDto"/> class. 
        /// There are no comments for CuttingOrderLiteDto constructor in the schema.
        /// </summary>
        public CuttingOrderLiteDto()
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
        /// There are no comments for Numb in the schema.
        /// </summary>
        public virtual decimal Numb
        {
            get
            {
                return this._Numb;
            }

            set
            {
                if (this._Numb != value)
                {
                    this.OnNumbChanging(value);
                    this.SendPropertyChanging();
                    this._Numb = value;
                    this.SendPropertyChanged("Numb");
                    this.OnNumbChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for Pref in the schema.
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
                    this.OnPrefChanging(value);
                    this.SendPropertyChanging();
                    this._Pref = value;
                    this.SendPropertyChanged("Pref");
                    this.OnPrefChanged();
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
        /// There are no comments for DateDocumentIntegration in the schema.
        /// </summary>
        public virtual DateTime? DateDocumentIntegration
        {
            get
            {
                return this._DateDocumentIntegration;
            }

            set
            {
                if (this._DateDocumentIntegration != value)
                {
                    this.OnDateDocumentIntegrationChanging(value);
                    this.SendPropertyChanging();
                    this._DateDocumentIntegration = value;
                    this.SendPropertyChanged("DateDocumentIntegration");
                    this.OnDateDocumentIntegrationChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for Priority in the schema.
        /// </summary>
        public virtual long? Priority
        {
            get
            {
                return this._Priority;
            }

            set
            {
                if (this._Priority != value)
                {
                    this.OnPriorityChanging(value);
                    this.SendPropertyChanging();
                    this._Priority = value;
                    this.SendPropertyChanged("Priority");
                    this.OnPriorityChanged();
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
        /// There are no comments for Storekeeper in the schema.
        /// </summary>
        
        public virtual long? Storekeeper
        {
            get
            {
                return this._Storekeeper;
            }

            set
            {
                if (this._Storekeeper != value)
                {
                    this.OnStorekeeperChanging(value);
                    this.SendPropertyChanging();
                    this._Storekeeper = value;
                    this.SendPropertyChanged("Storekeeper");
                    this.OnStorekeeperChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for StorekeeperName in the schema.
        /// </summary>
        
        public virtual string StorekeeperName
        {
            get
            {
                return this._StorekeeperName;
            }

            set
            {
                if (this._StorekeeperName != value)
                {
                    this.OnStorekeeperNameChanging(value);
                    this.SendPropertyChanging();
                    this._StorekeeperName = value;
                    this.SendPropertyChanged("StorekeeperName");
                    this.OnStorekeeperNameChanged();
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
        /// There are no comments for Department in the schema.
        /// </summary>
        
        public virtual long Department
        {
            get
            {
                return this._Department;
            }

            set
            {
                if (this._Department != value)
                {
                    this.OnDepartmentChanging(value);
                    this.SendPropertyChanging();
                    this._Department = value;
                    this.SendPropertyChanged("Department");
                    this.OnDepartmentChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for DepartmentCode in the schema.
        /// </summary>
        
        public virtual string DepartmentCode
        {
            get
            {
                return this._DepartmentCode;
            }

            set
            {
                if (this._DepartmentCode != value)
                {
                    this.OnDepartmentCodeChanging(value);
                    this.SendPropertyChanging();
                    this._DepartmentCode = value;
                    this.SendPropertyChanged("DepartmentCode");
                    this.OnDepartmentCodeChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for District in the schema.
        /// </summary>
        
        public virtual long District
        {
            get
            {
                return this._District;
            }

            set
            {
                if (this._District != value)
                {
                    this.OnDistrictChanging(value);
                    this.SendPropertyChanging();
                    this._District = value;
                    this.SendPropertyChanged("District");
                    this.OnDistrictChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for DistrictCode in the schema.
        /// </summary>
        
        public virtual string DistrictCode
        {
            get
            {
                return this._DistrictCode;
            }

            set
            {
                if (this._DistrictCode != value)
                {
                    this.OnDistrictCodeChanging(value);
                    this.SendPropertyChanging();
                    this._DistrictCode = value;
                    this.SendPropertyChanged("DistrictCode");
                    this.OnDistrictCodeChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for InspectorMemo in the schema.
        /// </summary>
        
        public virtual string InspectorMemo
        {
            get
            {
                return this._InspectorMemo;
            }

            set
            {
                if (this._InspectorMemo != value)
                {
                    this.OnInspectorMemoChanging(value);
                    this.SendPropertyChanging();
                    this._InspectorMemo = value;
                    this.SendPropertyChanged("InspectorMemo");
                    this.OnInspectorMemoChanged();
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
        /// There are no comments for StorekeeperMemo in the schema.
        /// </summary>
        
        public virtual string StorekeeperMemo
        {
            get
            {
                return this._StorekeeperMemo;
            }

            set
            {
                if (this._StorekeeperMemo != value)
                {
                    this.OnStorekeeperMemoChanging(value);
                    this.SendPropertyChanging();
                    this._StorekeeperMemo = value;
                    this.SendPropertyChanged("StorekeeperMemo");
                    this.OnStorekeeperMemoChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for DeliveryDate in the schema.
        /// </summary>
        
        public virtual DateTime? DeliveryDate
        {
            get
            {
                return this._DeliveryDate;
            }

            set
            {
                if (this._DeliveryDate != value)
                {
                    this.OnDeliveryDateChanging(value);
                    this.SendPropertyChanging();
                    this._DeliveryDate = value;
                    this.SendPropertyChanged("DeliveryDate");
                    this.OnDeliveryDateChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for Packer in the schema.
        /// </summary>
        
        public virtual long? Packer
        {
            get
            {
                return this._Packer;
            }

            set
            {
                if (this._Packer != value)
                {
                    this.OnPackerChanging(value);
                    this.SendPropertyChanging();
                    this._Packer = value;
                    this.SendPropertyChanged("Packer");
                    this.OnPackerChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for PackerMemo in the schema.
        /// </summary>
        
        public virtual string PackerMemo
        {
            get
            {
                return this._PackerMemo;
            }

            set
            {
                if (this._PackerMemo != value)
                {
                    this.OnPackerMemoChanging(value);
                    this.SendPropertyChanging();
                    this._PackerMemo = value;
                    this.SendPropertyChanged("PackerMemo");
                    this.OnPackerMemoChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for PackerName in the schema.
        /// </summary>
        
        public virtual string PackerName
        {
            get
            {
                return this._PackerName;
            }

            set
            {
                if (this._PackerName != value)
                {
                    this.OnPackerNameChanging(value);
                    this.SendPropertyChanging();
                    this._PackerName = value;
                    this.SendPropertyChanged("PackerName");
                    this.OnPackerNameChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for LastDate in the schema.
        /// </summary>
        
        public virtual DateTime LastDate
        {
            get
            {
                return this._LastDate;
            }

            set
            {
                if (this._LastDate != value)
                {
                    this.OnLastDateChanging(value);
                    this.SendPropertyChanging();
                    this._LastDate = value;
                    this.SendPropertyChanged("LastDate");
                    this.OnLastDateChanged();
                }
            }
        }

        /// <summary>
        /// There are no comments for LastRecipient in the schema.
        /// </summary>
        
        public virtual long LastRecipient
        {
            get
            {
                return this._LastRecipient;
            }

            set
            {
                if (this._LastRecipient != value)
                {
                    this.OnLastRecipientChanging(value);
                    this.SendPropertyChanging();
                    this._LastRecipient = value;
                    this.SendPropertyChanged("LastRecipient");
                    this.OnLastRecipientChanged();
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
