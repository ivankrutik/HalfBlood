namespace Buisness.Entities.ExpenditureInvoiceDomain
{
    using System;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.NomenclatorDomain;
    using Halfblood.Common;

    public class ExpenditureInvoiceSpecificationDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual string NameSectionOfSystem { get; protected set; }
        public virtual CatalogDto Catalog { get; set; }
        public virtual decimal? Price { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual decimal QuantityAlt { get; set; }
        public virtual Int16 PriceMeasure { get; set; }
        public virtual decimal SummWithNDS { get; set; }
        public virtual DateTime? BeginDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual string Note { get; set; }
        public virtual Int16 CoeffValcSign { get; set; }
        public virtual Int16 CoeffValSign { get; set; }
        public virtual decimal? Temperature { get; set; }
        public virtual decimal Coeff { get; set; }
        public virtual GoodsPartyDto GoodsParty { get; set; }
        public virtual NomenclatureNumberModificationDto NomenclatureNumberModification { get; set; }
        public virtual long NomenclatureNumberModificationPack { get; set; }
        public virtual long RLARTICLE { get; set; }
        public virtual long STPLCELL { get; set; }
        public virtual ExpenditureInvoiceDto ExpenditureInvoice { get; set; }
        public virtual UserDto Agent { get; set; }
    }
}
