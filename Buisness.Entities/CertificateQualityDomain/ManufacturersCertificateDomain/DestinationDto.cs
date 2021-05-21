// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DestinationDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DestinationDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using System;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    public class DestinationDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Note { get; set; }
        public DateTime? StateDate { get; set; }
        public UserDto UserCreator { get; set; }
        public UserDto UserWhichSetState { get; set; }
        public CertificateQualityDto CertificateQuality { get; set; }
        public DictionaryPassDto DictionaryPass { get; set; }
        public ManufacturersCertificateDestinationState State { get; set; }
        public long Rn { get; set; }
    }
}