// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SolutionByNoteDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the SolutionByNoteDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain
{
    using System;

    using Buisness.Entities.CertificateQualityDomain.ActInputControlDomain;
    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    /// <summary>
    ///     The solution by note DTO.
    /// </summary>
    public class SolutionByNoteDto : IDto<long>
    {
        public long CRN { get; set; }
        public DateTime CreationDate { get; set; }
        public string Note { get; set; }
        public string Conclusion { get; set; }
        public UserDto Agnlist { get; set; }
        public ActInputControlDto ActInputControl { get; set; }
        public long Rn { get; set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}