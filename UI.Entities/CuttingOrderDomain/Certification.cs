// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Certification.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the Certification type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CuttingOrderDomain
{
    using UI.Entities.CommonDomain;

    public class Certification : EntityBase<Certification>
    {
        public Certification(long rn)
        {
            this.Rn = rn;

        }

        public Certification()
        {

        }

        public virtual long Rn { get; set; }
        public virtual long? TransInvDeptSpecs { get; set; }
        public virtual Catalog Catalog { get; set; }
        public virtual CuttingOrderSpecification CuttingOrderSpecification { get; set; }

    }
}
