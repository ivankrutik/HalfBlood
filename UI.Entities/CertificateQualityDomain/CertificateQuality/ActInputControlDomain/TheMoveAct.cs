// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TheMoveAct.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The the move act.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain.CertificateQualityDomain
{
    using System;

    
    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain.CertificateQualityDomain.ActInputControlDomain;

    /// <summary>
    /// The the move act.
    /// </summary>
    public class TheMoveAct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TheMoveAct"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public TheMoveAct(long rn)
        {
            this.RN = rn;
        }

        public TheMoveAct()
        {
            
        }

        public long RN { get; private set; }
        public DateTime? CreationDate { get; set; }
        public User UserCreator { get; set; }
        public User UserReciver { get; set; }
        public ActInputControl ActInputControl { get; set; }
        public StaffingDivision DepartmentCreator { get; set; }
        public StaffingDivision DepartmentReciver { get; set; }
    }
}
