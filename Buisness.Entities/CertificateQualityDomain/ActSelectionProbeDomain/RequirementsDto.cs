// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The requirements dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ActSelectionProbeDomain
{
    using Halfblood.Common;

    /// <summary>
    ///     The requirements dto.
    /// </summary>
    public class ActSelectionOfProbeDepartmentRequirementDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Requirement { get; set; }
        public long Rn { get; set; }
        public ActSelectionOfProbeDepartmentDto ActSelectionOfProbeDepartment { get; set; }
    }
}