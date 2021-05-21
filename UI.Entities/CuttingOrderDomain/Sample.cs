namespace UI.Entities.CuttingOrderDomain
{
    using System.Collections.Generic;
    using UI.Entities.CommonDomain;
    using UI.Entities.NomeclatorDomain;

    public class Sample : EntityBase<Sample>
    {
        public Sample(long rn)
        {
            this.Rn = rn;

        }

        public Sample()
        {

        }

        public long Rn { get; set; }
        public long? Count { get; set; }
        public long? BatchSize { get; set; }
        public long? GeometricsLength { get; set; }
        public long? GeometricsWidth { get; set; }
        public long? NormExpense { get; set; }
        public long? Weight { get; set; }
        public string Note { get; set; }
        public UnitOfMeasure Measure { get; set; }
        public Catalog Catalog { get; set; }
        public NomenclatureNumberModification NomModif { get; set; }
        public User Creator { get; set; }
        public CuttingOrderSpecification CuttingOrderSpecification { get; set; }
        public IList<SampleCertification> SampleCertification { get; set; }

    }
}
