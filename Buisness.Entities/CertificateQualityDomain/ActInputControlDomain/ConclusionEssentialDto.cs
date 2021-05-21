// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConclusionEssentialDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ConclusionEssentialDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ActInputControlDomain
{
    using System;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    public class ConclusionEssentialDto : IDto<long>
    {
        public virtual DateTime? CreationDate { get; set; }
        public virtual StaffingDivisionDto Department { get; set; }
        public virtual UserDto User { get; set; }
        public virtual ConclusionDto Conclusion { get; set; }
        public virtual long Rn { get; set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}