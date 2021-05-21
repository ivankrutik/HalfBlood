// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QualityStateControlOfTheMakeSignatureDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the QualityStateControlOfTheMakeSignatureDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ActInputControlDomain
{
    using System;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    /// <summary>
    ///     The quality state control of the make signature DTO.
    /// </summary>
    public class QualityStateControlOfTheMakeSignatureDto : IDto<long>
    {
        public virtual DateTime? CreationDate { get; set; }
        public virtual StaffingDivisionDto Department { get; set; }
        public virtual UserDto User { get; set; }
        public virtual QualityStateControlOfTheMakeDto QualityStateControlOfTheMake { get; set; }
        public virtual long Rn { get; set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}