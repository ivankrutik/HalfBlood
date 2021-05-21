// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControlDestinationDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ActInputControlDestinationDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ActInputControlDomain
{
    using System;

    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    public class ActInputControlDestinationDto : IDto<long>
    {
        public virtual string Note { get; set; }
        public virtual ActInputControlDestinationState State { get; set; }
        public virtual DateTime? StateDate { get; set; }
        public virtual UserDto Creator { get; set; }
        public virtual UserDto UserWhichSetState { get; set; }
        public virtual CertificateQualityDto CertificateQuality { get; set; }
        public virtual DictionaryPassDto DICPASS { get; set; }
        public virtual long Rn { get; set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}