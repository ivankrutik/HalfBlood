// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControlFunctioningSignature.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The act input control functioning signature.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain.CertificateQualityDomain.ActInputControlDomain
{
    using System;

    
    using UI.Entities.CommonDomain;

    /// <summary>
    /// The act input control functioning signature.
    /// </summary>
    public class ActInputControlFunctioningSignature
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActInputControlFunctioningSignature"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public ActInputControlFunctioningSignature(long rn)
        {
            this.RN = rn;
        }

        public ActInputControlFunctioningSignature()
        {
            
        }

        public long RN { get; private set; }
        public DateTime? CreationDate { get; set; }
        public StaffingDivision Department { get; set; }
        public User User { get; set; }
        public ActInputControlFunctioning ActInputControlFunctioning { get; set; }
    }
}
