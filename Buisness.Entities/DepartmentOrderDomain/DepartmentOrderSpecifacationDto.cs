// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentOrderSpecifacationDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DepartmentOrderSpecifacationDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.DepartmentOrderDomain
{
    using Halfblood.Common;
    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    public class DepartmentOrderSpecifacationDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public decimal Quantity { get; set; }
        public CertificateQualityDto CertificateQuality { get; set;}
        public CatalogDto Catalog { get; set; }
        public DepartmentOrderDto DepartmentOrder { get; set; }
    }
}