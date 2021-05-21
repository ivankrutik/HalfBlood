// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderSetGroupState.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderSetGroupState type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.StoredProcedure.PlanReceiptOrderDomain
{
    using NHibernate.Helper;

    using ParusModel.Entities;
    using ParusModel.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The plan receipt order set group state.
    /// </summary>
    public class PlanReceiptOrderSetGroupState : IStoredProcedure
    {
        public PlanReceiptOrderSetGroupState(PlanReceiptOrder planReceiptOrder, PersonalAccount personalAccount)
        {
            RnPlanReceiptOrder = planReceiptOrder.Rn;
            PersonalAccount = personalAccount.Numb;
        }

        [StoredParameter("RN")]
        public long RnPlanReceiptOrder { get; private set; }

        [StoredParameter("sFaceAcc")]
        public string PersonalAccount { get; private set; }

        public string Name
        {
            get { return "PCO_SET_GROUP_STATE"; }
        }
    }
}
