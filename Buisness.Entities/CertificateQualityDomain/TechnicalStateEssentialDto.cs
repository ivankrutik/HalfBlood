// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TechnicalStateEssentialDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the TechnicalStateEssentialDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain
{
    using Halfblood.Common;

    public class TechnicalStateEssentialDto : IDto<long>
    {
        public long Rn { get; set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}