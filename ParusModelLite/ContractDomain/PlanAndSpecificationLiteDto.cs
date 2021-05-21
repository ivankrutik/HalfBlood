namespace ParusModelLite.ContractDomain
{
    using System;

    using Halfblood.Common;

    public class PlanAndSpecificationLiteDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual DateTime BeginDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual decimal? Price { get; set; }
        public virtual decimal? Quant { get; set; }
        public virtual decimal? SumWithTaxDocumenta { get; set; }
        public virtual decimal PlanQuant { get; set; }
        public virtual decimal FactQuant { get; set; }
        public virtual decimal PlanSum { get; set; }
        public virtual decimal FactSum { get; set; }
        public virtual decimal? SumWithNds { get; set; }
        public virtual string NomenclatureNumberName { get; set; }
        public virtual string NomenclatureNumberCode { get; set; }
        public virtual string NomenclatureNumberModificationName { get; set; }
        public virtual string NomenclatureNumberModificationCode { get; set; }
        public virtual long PersonalAccountRN { get; set; }
    }
}
