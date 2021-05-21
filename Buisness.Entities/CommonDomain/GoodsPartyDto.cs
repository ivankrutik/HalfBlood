namespace Buisness.Entities.CommonDomain
{
    using System;
    using Buisness.Entities.ExpenditureInvoiceDomain;
    using Buisness.Entities.NomenclatorDomain;
    using Halfblood.Common;

    public class GoodsPartyDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual string NameSectionOfSystem { get; protected set; }
        public virtual DateTime? WorkingLife { get; set; }
        public virtual string Certificate { get; set; }
        public virtual bool? SignBreak { get; set; }
        public virtual string SerialNumber { get; set; }
        public virtual string BarCode { get; set; }
        public virtual string GTD { get; set; }
        public virtual decimal? PeriodStorage { get; set; }
        public virtual UnitOfMeasureDto UnitOfMeasure { get; set; }
        public virtual long Geografy { get; set; }
        public virtual BatchDto Batch { get; set; }
        public virtual LegalPersonDto LegalPerson { get; set; }
        public virtual NomenclatureNumberModificationDto NomenclatureNumberModification { get; set; }
        public virtual long NomenclatureNumberModificationPack { get; set; }
        public virtual UserDto Agnlist { get; set; }
    }
}
