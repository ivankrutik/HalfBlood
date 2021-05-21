// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplySolutionByRemark.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ApplySolutionByRemark type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain
{
    using System;
    

    using UI.Entities.CommonDomain;

    /// <summary>
    /// The apply solution by remark.
    /// </summary>
    public class ApplySolutionByRemark
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplySolutionByRemark"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public ApplySolutionByRemark(long rn)
        {
            this.RN = rn;
        }

        public ApplySolutionByRemark()
        {
            
        }

        public long RN { get; private set; }
        public DateTime? CreationDate { get; set; }
        public StaffingDivision Department { get; set; }
        public User User { get; set; }
        public SolutionByNote SolutionByNote { get; set; }
    }
}
