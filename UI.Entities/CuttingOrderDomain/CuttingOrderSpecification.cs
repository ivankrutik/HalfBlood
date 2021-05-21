// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderSpecification.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The plan certificate.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CuttingOrderDomain
{
    using System;
    using System.Collections.Generic;
    using Halfblood.Common;
    using UI.Entities;
    using UI.Entities.CommonDomain;
    using UI.Entities.NomeclatorDomain;
    using UI.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The plan certificate.
    /// </summary>
    public class CuttingOrderSpecification : EntityBase<CuttingOrderSpecification>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanCertificate"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public CuttingOrderSpecification(long rn)
        {
            this.Rn = rn;
          
        }

        public CuttingOrderSpecification()
        {
        }

        public long Rn { get; set; }
        public CuttingOrderSpecificationState State { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? AssumeDate { get; set; }
        public long? NormExpense { get; set; }
        public long? CountPartWithBlank { get; set; }
        public long? PartBlankWeight { get; set; }
        public long? PartBlankLenght { get; set; }
        public long? PartBlankWidth { get; set; }
        public long? MaxDeflectionLenght { get; set; }
        public long? MinDeflectionLenght { get; set; }
        public long? DemandContract { get; set; }
        public long? DemandGoods { get; set; }
        public long? DemandPlanMonth { get; set; }
        public UnitOfMeasure MeasureWeight { get; set; }
        public UnitOfMeasure MeasureNorm { get; set; }
        public PersonalAccount PersonalAccount { get; set; }
        public Catalog Catalog { get; set; }
        public StaffingDivision Department { get; set; }
        public NomenclatureNumberModification NomModif { get; set; }
        public User Inspector { get; set; }
        public CuttingOrder CuttingOrder { get; set; }
        public IList<Sample> Samples { get; set; }
        public IList<Certification> Certifications { get; set; }
    }
}
