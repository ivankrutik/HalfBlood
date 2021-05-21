// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificationDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CertificationDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CuttingOrderDomain
{
    using Halfblood.Common;

    public class CertificationDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long? TransInvDeptSpecs { get; set; }
        public virtual CatalogDto Catalog { get; set; }
        public virtual CuttingOrderSpecificationDto CuttingOrderSpecification { get; set; }
        public virtual long Rn { get; set; }
    }
}