// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControl.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ActInputControl type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain.CertificateQualityDomain.ActInputControlDomain
{
    using System;
    using System.Collections.Generic;

    using Halfblood.Common;

    
    using UI.Entities.CommonDomain;

    /// <summary>
    /// The act input control.
    /// </summary>
    public class ActInputControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActInputControl"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public ActInputControl(long rn)
        {
            this.RN = rn;
        }

        public ActInputControl()
        {
            
        }

        public long RN { get; private set; }
        public string ViewTareStamp { get; set; }
        public DateTime? OpenningTareDate { get; set; }
        public DateTime? ControlerTareDate { get; set; }
        public ActInputControlState State { get; set; }
        public string Note { get; set; }
        public User ControlerTare { get; set; }
        public User ManagerStoreAct { get; set; }
        public User ManagerStoreTare { get; set; }
        public IList<TheMoveAct> TheMoveActs { get; set; }
        public IList<Conclusion> Conclusions { get; set; }
        public IList<QualityStateControlOfTheMake> QualityStateControlOfTheMakes { get; set; }
        public IList<SolutionByNote> SolutionByNotes { get; set; }
        public IList<ActInputControlTechnicalState> ActInputControlTechnicalStates { get; set; }
        public IList<ActInputControlFunctioning> ActInputControlFunctionings { get; set; }
    }
}