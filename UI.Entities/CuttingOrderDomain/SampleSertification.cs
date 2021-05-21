namespace UI.Entities.CuttingOrderDomain
{
    using UI.Entities.CommonDomain;

    public class SampleCertification : EntityBase<SampleCertification>
    {
        public SampleCertification(long rn)
        {
            this.Rn = rn;

        }

        public SampleCertification()
        {

        }

        public long Rn { get; set; }
        public long? TransInvDeptSpecs { get; set; }
        public Catalog Catalog { get; set; }
        public Sample Sample { get; set; }

    }
}
