// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConclusionDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ConclusionDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ActInputControlDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    public class ConclusionDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual DateTime? CREATIONDATE { get; set; }
        public virtual string NOTE { get; set; }
        public virtual string TEXT { get; set; }
        public virtual UserDto AGNLIST { get; set; }
        public virtual IList<ConclusionEssentialDto> ACTINPUTCOENs { get; set; }
        public virtual ActInputControlDto ACTINPUTCONTROL { get; set; }
        public virtual long Rn { get; set; }
    }
}