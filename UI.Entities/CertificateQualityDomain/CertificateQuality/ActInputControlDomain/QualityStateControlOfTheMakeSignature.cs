// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QualityStateControlOfTheMakeSignature.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The quality state control of the make signature.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain.CertificateQualityDomain.ActInputControlDomain
{
    using System;

    
    using UI.Entities.CommonDomain;

    /// <summary>
    /// The quality state control of the make signature.
    /// </summary>
    public class QualityStateControlOfTheMakeSignature
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QualityStateControlOfTheMakeSignature"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public QualityStateControlOfTheMakeSignature(long rn)
        {
            this.RN = rn;
        }

        public QualityStateControlOfTheMakeSignature()
        {
            
        }

        public long RN { get; private set; }
        public DateTime? CreationDate { get; set; }
        public StaffingDivision Department { get; set; }
        public User User { get; set; }
        public QualityStateControlOfTheMake QualityStateControlOfTheMake { get; set; }
    }
}
