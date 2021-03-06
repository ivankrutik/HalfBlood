// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StagesOfTheContract.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the StagesOfTheContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.ContractDomain
{
    using CommonDomain;

    /// <summary>
    /// The stages of the contract.
    /// </summary>
    public class StagesOfTheContract
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StagesOfTheContract"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public StagesOfTheContract(long rn)
        {
            this.RN = rn;
        }

        public StagesOfTheContract()
        {
            
        }

        public long RN { get; private set; }
        public string NUMB { get; set; }
        public bool STATUS { get; set; }
        public bool EXTAGREEMENT { get; set; }
        public bool SIGNSUM { get; set; }
        public System.DateTime BEGINDATE { get; set; }
        public System.DateTime ENDDATE { get; set; }
        public PersonalAccount PersonalAccount { get; set; }
        public bool SUMTYPE { get; set; }
        public decimal STAGESUM { get; set; }
        public decimal STAGESUMTAX { get; set; }
        public string DESCRIPTION { get; set; }
        public string COMMENTS { get; set; }
        public decimal STAGESUMNDS { get; set; }
        public bool AUTOCALCSIGN { get; set; }
        public Contract Contract { get; set; }
    }
}
