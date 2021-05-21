// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QualityStateControlOfTheMakeDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the QualityStateControlOfTheMakeDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ActInputControlDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    public class QualityStateControlOfTheMakeDto : IDto<long>
    {
        public virtual DateTime? CreationDate { get; set; }
        public virtual string Note { get; set; }
        public virtual string Conclusion { get; set; }
        public virtual UserDto Agnlist { get; set; }
        public virtual ActInputControlDto ActInputControl { get; set; }
        object IHasUid.Rn { get { return Rn; } }
        public virtual IList<QualityStateControlOfTheMakeSignatureDto> QualityStateControlOfTheMakeSignatureS { get; set; }
        public virtual long Rn { get; set; }
    }
}