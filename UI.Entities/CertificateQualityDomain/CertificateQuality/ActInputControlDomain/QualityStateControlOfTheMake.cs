// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QualityStateControlOfTheMake.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The quality state control of the make.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain.CertificateQualityDomain.ActInputControlDomain
{
    using System;
    using System.Collections.Generic;

    using UI.Entities.CommonDomain;

    /// <summary>
    /// The quality state control of the make.
    /// </summary>
    public class QualityStateControlOfTheMake
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QualityStateControlOfTheMake"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public QualityStateControlOfTheMake(long rn)
        {
            this.RN = rn;
        }

        public QualityStateControlOfTheMake()
        {
            
        }

        public long RN { get; private set; }
        public DateTime? CreationDate { get; set; }
        public string Note { get; set; }
        public string Conclusion { get; set; }
        public User Agnlist { get; set; }
        public ActInputControl ActInputControl { get; set; }
        public IList<QualityStateControlOfTheMakeSignature> QualityStateControlOfTheMakeSignatureS { get; set; }
    }
}
