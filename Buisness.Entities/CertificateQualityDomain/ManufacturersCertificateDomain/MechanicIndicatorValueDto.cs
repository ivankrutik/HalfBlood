// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MechanicIndicatorValueDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the MechanicIndicatorValueDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using Halfblood.Common;

    public class MechanicIndicatorValueDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Value { get; set; }
        public CertificateQualityDto CertificateQuality { get; set; }
        public DictionaryMechanicalIndicatorDto MechanicalIndicator { get; set; }
        public long Rn { get; set; }
    }
}