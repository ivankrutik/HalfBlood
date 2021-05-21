// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SolutionByNote.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The solution by note.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain
{
    using System;
    using CertificateQualityDomain.ActInputControlDomain;

    using UI.Entities.CommonDomain;

    /// <summary>
    /// The solution by note.
    /// </summary>
    public class SolutionByNote
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionByNote"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public SolutionByNote(long rn)
        {
            this.RN = rn;
        }

        public SolutionByNote()
        {
            
        }

        public long RN { get; private set; }
        public DateTime? CreationDate { get; set; }
        public string Note { get; set; }
        public string Conclusion { get; set; }
        public User Agnlist { get; set; }
        public ActInputControl ActInputControl { get; set; }
    }
}
