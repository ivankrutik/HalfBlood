// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConclusionEssential.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The conclusion essential.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain.CertificateQualityDomain.ActInputControlDomain
{
    using System;

    
    using UI.Entities.CommonDomain;

    /// <summary>
    /// The conclusion essential.
    /// </summary>
    public class ConclusionEssential
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConclusionEssential"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public ConclusionEssential(long rn)
        {
            this.RN = rn;
        }

        public ConclusionEssential()
        {
            
        }

        public long RN { get; private set; }

        public DateTime? CreationDate { get; set; }
        public StaffingDivision Department { get; set; }
        public User User { get; set; }
        public Conclusion Conclusion { get; set; }
    }
}
