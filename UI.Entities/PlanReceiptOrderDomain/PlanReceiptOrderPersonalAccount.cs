// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderPersonalAccount.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderPersonalAccount type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain
{
    using System;
    using CommonDomain;
    using Halfblood.Common;

    /// <summary>
    /// The plan receipt order personal account.
    /// </summary>
    public class PlanReceiptOrderPersonalAccount : EntityBase<PlanReceiptOrderPersonalAccount>, IHasState<PlanReceiptOrderPersonalAccountState>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanReceiptOrderPersonalAccount"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public PlanReceiptOrderPersonalAccount(long rn)
        {
            this.Rn = rn;
        }

        public PlanReceiptOrderPersonalAccount()
        {
        }
        public decimal? CountByDocument { get; set; }
        public decimal? CountFact { get; set; }
        public DateTime? CreationDate { get; set; }
        public User Creator { get; set; }
        public string Note { get; set; }
        public PlanCertificate PlanCertificate { get; set; }
        public PlanReceiptOrderPersonalAccountState State { get; set; }
        public DateTime? StateDate { get; set; }
        public User UserSetState { get; set; }
        public PersonalAccount PersonalAccount { get; set; }
    }
}