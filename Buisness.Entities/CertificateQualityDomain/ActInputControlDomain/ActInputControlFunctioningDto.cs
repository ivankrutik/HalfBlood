// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControlFunctioningDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ActInputControlFunctioningDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ActInputControlDomain

{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    public class ActInputControlFunctioningDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual DateTime? CreationDate { get; set; }
        public virtual string Note { get; set; }
        public virtual string Conclusion { get; set; }
        public virtual UserDto Agnlist { get; set; }
        public virtual ActInputControlDto ActInputControl { get; set; }
        public virtual IList<ActInputControlFunctioningSignatureDto> ActInputControlFunctioningSignatures { get; set; }
        public virtual long Rn { get; set; }
    }
}