// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleCertificationDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the SampleCertificationDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CuttingOrderDomain
{
    using Halfblood.Common;

    public class SampleCertificationDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long? TransInvDeptSpecs { get; set; }
        public CatalogDto Catalog { get; set; }
        public SampleDto Sample { get; set; }
        public long Rn { get; set; }
    }
}