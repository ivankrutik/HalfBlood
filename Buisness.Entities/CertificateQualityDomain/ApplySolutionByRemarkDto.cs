// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplySolutionByRemarkDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The apply solution by remark dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain
{
    using System;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    /// <summary>
    ///     The apply solution by remark dto.
    /// </summary>
    public class ApplySolutionByRemarkDto : IDto<long>
    {
        public CatalogDto Catalog { get; set; }
        public DateTime? CreationDate { get; set; }
        public StaffingDivisionDto Department { get; set; }
        public UserDto User { get; set; }
        public SolutionByNoteDto SolutionByNote { get; set; }
        public long Rn { get; set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}