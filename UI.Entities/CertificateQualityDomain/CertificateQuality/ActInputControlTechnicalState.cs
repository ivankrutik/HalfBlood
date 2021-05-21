// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControlTechnicalState.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ActInputControlTechnicalState type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain
{
    using System;
    using System.Collections.Generic;
    
    using CertificateQualityDomain.ActInputControlDomain;

    using UI.Entities.CommonDomain;

    /// <summary>
    /// The act input control technical state.
    /// </summary>
    public class ActInputControlTechnicalState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActInputControlTechnicalState"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public ActInputControlTechnicalState(long rn)
        {
            this.RN = rn;
        }

        public ActInputControlTechnicalState()
        {
            
        }

        public long RN { get; private set; }
        
        public string Note { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ControlerBtkDate { get; set; }
        public DateTime? ControlertOtkDate { get; set; }
        public string Conclusion { get; set; }
        public User UserCreator { get; set; }
        public User ControlerBtk { get; set; }
        public User ControlerOtk { get; set; }
        public IList<TechnicalStateEssential> TechnicalStatesEssential { get; set; }
        public ActInputControl ActInputControl { get; set; }
    }
}
