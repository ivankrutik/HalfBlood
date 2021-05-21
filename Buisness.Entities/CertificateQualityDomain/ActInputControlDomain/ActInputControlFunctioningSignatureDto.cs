// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControlFunctioningSignatureDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ActInputControlFunctioningSignatureDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ActInputControlDomain
{
    using System;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    public class ActInputControlFunctioningSignatureDto : IDto<long>
    {
        public virtual DateTime? CreationDate { get; set; }
        object IHasUid.Rn { get { return Rn; } }
        public virtual StaffingDivisionDto Department { get; set; }
        public virtual UserDto User { get; set; }
        public virtual ActInputControlFunctioningDto ActInputControlFunctioning { get; set; }
        public virtual long Rn { get; set; }
    }
}