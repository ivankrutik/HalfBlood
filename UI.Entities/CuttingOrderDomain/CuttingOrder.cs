namespace UI.Entities.CuttingOrderDomain
{
    using System;
    using System.Collections.Generic;
    using Halfblood.Common;
    using UI.Entities.CommonDomain;

    public class CuttingOrder : EntityBase<CuttingOrder>
    {
        public CuttingOrder(long rn)
        {
            this.Rn = rn;

        }

        public CuttingOrder()
        {

        }

        public long Rn { get; set; }
        public decimal? Numb { get; set; }
        public string Pref { get; set; }
        public CuttingOrderState State { get; set; }
        public string Note { get; set; }
        public DateTime? DateDocumentIntegration { get; set; }
        public CuttingOrderPriority Priority { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? AssumeDate { get; set; }
        public Catalog Catalog { get; set; }
        public StaffingDivision Department { get; set; }
        public StaffingDivision District { get; set; }
        public User Storekeeper { get; set; }
        public User Inspector { get; set; }
        public User Creator { get; set; }
        public IList<CuttingOrderMove> Moves { get; set; }
        public IList<CuttingOrderSpecification> Specifications { get; set; }

        public override string ToString()
        {
            return String.Format("НАРЯД: {0}-{1} от {2};", Pref, Numb, CreationDate);
        }
    }
}
