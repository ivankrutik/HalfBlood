// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The act selection of probe view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModelLite.CertificateQualityDomain.ActSelectionOfProbeDomain
{
    using Halfblood.Common;

    public partial class ActSelectionOfProbeDepartmentRequirementLiteDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn{get;set;}
        public virtual long Crn{get;set;}
        public virtual string Requirement{get;set;}
        public virtual ActSelectionOfProbeDepartmentLiteDto ActSelectionOfProbeDepartment{get;set;}
    }
}
