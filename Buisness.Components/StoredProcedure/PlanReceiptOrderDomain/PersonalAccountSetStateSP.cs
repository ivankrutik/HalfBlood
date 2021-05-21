// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonalAccountSetStatus.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PersonalAccountSetStatus type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.StoredProcedure.PlanReceiptOrderDomain
{
    using Halfblood.Common;

    using NHibernate.Helper;

    using ParusModel.Entities.PlanReceiptOrderDomain;

    public class PersonalAccountSetStateSP : IStoredProcedure
    {
        public PersonalAccountSetStateSP(
            PlanReceiptOrderPersonalAccount planReceiptOrderPersonalAccount, 
            PlanReceiptOrderPersonalAccountState state)
        {
            Rn = planReceiptOrderPersonalAccount.Rn;
            this.State = state;
        }

        [StoredParameter("RN")]
        public long Rn
        {
            get; 
            private set;
        }

        [StoredParameter("NewStatus")]
        public PlanReceiptOrderPersonalAccountState State
        {
            get; 
            private set;
        }

        public string Name
        {
            get { return "PCO_PERSONAL_ACCOUNT_SET_STATE"; }
        }
    }
}
