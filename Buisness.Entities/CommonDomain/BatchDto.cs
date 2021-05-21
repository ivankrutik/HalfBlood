namespace Buisness.Entities.CommonDomain
{
    using System;
    using Halfblood.Common;


    public class BatchDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual string NameSectionOfSystem { get; protected set; }
        public virtual string Code { get; set; }
        public virtual DateTime? ReceiptDate { get; set; }
        public virtual bool OutParty { get; set; }
        public virtual bool ResponsibleStorage { get; set; }
        public virtual bool CommissionGoods { get; set; }
        public virtual bool OverCalcSign { get; set; }
        public virtual StaffingDivisionDto StaffingDivision { get; set; }
        public virtual LegalPersonDto LegalPerson { get; set; }
        public virtual UserDto Agnlist { get; set; }
    }
}
