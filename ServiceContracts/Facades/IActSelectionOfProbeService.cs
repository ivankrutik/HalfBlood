// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActSelectionOfProbeService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IActSelectionOfProbeService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceContracts.Facades
{
    using Buisness.Entities.CertificateQualityDomain.ActSelectionProbeDomain;

    /// <summary>
    /// The ActSelectionOfProbeService interface.
    /// </summary>
    public interface IActSelectionOfProbeService
    {
        ActSelectionOfProbeDto GetActSelectionOfProbeDto(long rn);
        void UpdateActSelectionOfProbe(ActSelectionOfProbeDto entity);
        ActSelectionOfProbeDto AddActSelectionOfProbe(long certificateQualite);
        void RemoveActSelectionOfProbe(long rn);

        ActSelectionOfProbeDepartmentDto GetActSelectionOfProbeDepartmentDto(long rn);
        void UpdateActSelectionOfProbeDepartment(ActSelectionOfProbeDepartmentDto entity);
        ActSelectionOfProbeDepartmentDto AddActSelectionOfProbeDepartment(ActSelectionOfProbeDepartmentDto entity);
        void RemoveActSelectionOfProbeDepartment(long rn);

        ActSelectionOfProbeDepartmentRequirementDto GetActSelectionOfProbeDepartmentRequirementDto(long rn);
        void UpdateActSelectionOfProbeDepartmentRequirement(ActSelectionOfProbeDepartmentRequirementDto entity);
        ActSelectionOfProbeDepartmentRequirementDto AddActSelectionOfProbeDepartmentRequirement(ActSelectionOfProbeDepartmentRequirementDto entity);
        void RemoveActSelectionOfProbeDepartmentRequirement(long rn);

    }
}
