namespace UI.Entities.CuttingOrderDomain
{
    using System;

    using UI.Entities.CommonDomain;

    public class CuttingOrderMove : EntityBase<CuttingOrderMove>
    {
        public CuttingOrderMove(long rn)
        {
            this.Rn = rn;

        }

        public CuttingOrderMove()
        {

        }

        public long Rn { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Note { get; set; }
        public Catalog Catalog { get; set; }
        public User RecipientDocument { get; set; }
        public CuttingOrder CuttingOrder { get; set; }

    }
}
