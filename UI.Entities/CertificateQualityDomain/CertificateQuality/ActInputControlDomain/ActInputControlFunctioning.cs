// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControlFunctioning.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ActInputControlFunctioning type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain.CertificateQualityDomain.ActInputControlDomain
{
    using System;
    using System.Collections.Generic;

    
    using UI.Entities.CommonDomain;

    /// <summary>
    /// The act input control functioning.
    /// </summary>
    public class ActInputControlFunctioning
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActInputControlFunctioning"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public ActInputControlFunctioning(long rn)
        {
            this.RN = rn;
        }

        public ActInputControlFunctioning()
        {
            
        }

        public long RN { get; private set; }
        public DateTime CreationDate { get; set; }
        public string Note { get; set; }
        public string Conclusion { get; set; }
        public User Agnlist { get; set; }
        public ActInputControl ActInputControl { get; set; }
        public IList<ActInputControlFunctioningSignature> ActInputControlFunctioningSignatures{ get; set; }
    }
}
