// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificateSetState.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CertificateSetState type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.StoredProcedure.PlanReceiptOrderDomain
{
    using Halfblood.Common;

    using NHibernate.Helper;

    using ParusModel.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The certificate set state.
    /// </summary>
    public class PlanCertificateSetStateSP : IStoredProcedure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanCertificateSetStateSP"/> class.
        /// </summary>
        /// <param name="certificate">
        /// The certificate.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        public PlanCertificateSetStateSP(PlanCertificate certificate, PlanCertificateState state)
        {
            Rn = certificate.Rn;
            State = state;
        }

        /// <summary>
        /// Gets the rn.
        /// </summary>
        [StoredParameter("RN")]
        public long Rn
        {
            get; 
            private set;
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        [StoredParameter("NewState")]
        public PlanCertificateState State
        {
            get; 
            private set;
        }

        /// <summary>
        /// Gets the name stored procedure.
        /// </summary>
        public string Name
        {
            get { return "PCO_CERTIFICATE_SET_STATE"; }
        }
    }
}
