// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetState.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the SetState type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.StoredProcedure.PlanReceiptOrderDomain
{
    using Halfblood.Common;

    using NHibernate.Helper;

    using ParusModel.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The set state.
    /// </summary>
    public class PlanReceiptOrderSetState : IStoredProcedure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanReceiptOrderSetState"/> class.
        /// </summary>
        /// <param name="planReceiptOrder">
        /// The plan receipt order.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        public PlanReceiptOrderSetState(PlanReceiptOrder planReceiptOrder, PlanReceiptOrderState state)
        {
            RN = planReceiptOrder.Rn;
            State = state;
        }

        /// <summary>
        /// Gets the rn.
        /// </summary>
        [StoredParameter("RN")]
        public long RN
        {
            get; 
            private set;
        }

        /// <summary>
        /// Gets the new status.
        /// </summary>
        [StoredParameter("NewStatus")]
        public PlanReceiptOrderState State
        {
            get; 
            private set;
        }

        /// <summary>
        /// Gets the name stored procedure.
        /// </summary>
        public string Name
        {
            get { return "PCO_SET_STATE"; }
        }
    }
}
