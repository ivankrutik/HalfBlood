// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeDepartmentRequirement.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The act selection of probe destination.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain
{
    /// <summary>
    /// The act selection of probe destination.
    /// </summary>
    public class ActSelectionOfProbeDepartmentRequirement : EntityBase<ActSelectionOfProbeDepartmentRequirement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActSelectionOfProbe"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public ActSelectionOfProbeDepartmentRequirement(long rn) : this()
        {
            Rn = rn;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActSelectionOfProbeDepartmentRequirement"/> class.
        /// </summary>
        public ActSelectionOfProbeDepartmentRequirement()
        {
        }

        public long Rn { get; set; }
        public string Requirement { get; set; }
        public ActSelectionOfProbeDepartment ActSelectionOfProbeDepartment { get; set; }
    }
}
