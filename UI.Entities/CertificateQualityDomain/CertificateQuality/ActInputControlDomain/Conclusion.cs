// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Conclusion.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The conclusion.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain.CertificateQualityDomain.ActInputControlDomain
{
    using System;
    using System.Collections.Generic;

    
    using UI.Entities.CommonDomain;

    /// <summary>
    /// The conclusion.
    /// </summary>
    public class Conclusion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Conclusion"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public Conclusion(long rn)
        {
            this.RN = rn;
        }

        public Conclusion()
        {
            
        }

        public long RN { get; private set; }

        public DateTime? CREATIONDATE { get; set; }
        public string NOTE { get; set; }
        public string TEXT { get; set; }
        public User AGNLIST { get; set; }
        public IList<ConclusionEssential> ACTINPUTCOENs { get; set; }
        public ActInputControl ACTINPUTCONTROL { get; set; }
    }

}
