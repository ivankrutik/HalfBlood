// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanCertificateSetGroupState.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The plan certificate set group state.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.StoredProcedure.PlanReceiptOrderDomain
{
    using NHibernate.Helper;

    using ParusModel.Entities;
    using ParusModel.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The plan certificate set group state.
    /// </summary>
    public class PlanCertificateSetGroupState : IStoredProcedure
    {
        public PlanCertificateSetGroupState(PlanCertificate planCertificate, PersonalAccount personalAccount)
        {
            Rn = planCertificate.Rn;
            PersonalAccount = personalAccount.Numb;
        }

        [StoredParameter("nPcoSert")]
        public long Rn { get; private set; }

        [StoredParameter("sFaceAcc")]
        public string PersonalAccount { get; private set; }

        public string Name
        {
            get { return "PCO_CERTIFICATE_SET_GROUP_STATE"; }
        }
    }
}
