// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contract.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.ContractDomain
{
    using System;
    using System.Collections.Generic;
    using Halfblood.Common;
    

    using UI.Entities.CommonDomain;

    /// <summary>
    /// The contract.
    /// </summary>
    public class Contract
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contract"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public Contract(long rn)
        {
            this.RN = rn;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Contract"/> class.
        /// </summary>
        public Contract()
        {
        }

        public long RN { get; private set; }
        public string Docpref { get; set; }
        public string Docnumb { get; set; }
        public DateTime Docdate { get; set; }
        public string Extnumber { get; set; }
        public DateTime? Regdate { get; set; }
        public ContractStatusState Status { get; set; }
        public DateTime? Confirmdate { get; set; }
        public DateTime? Closedate { get; set; }
        public DateTime Begindate { get; set; }
        public DateTime? Enddate { get; set; }
        public User Agent { get; set; }
        public IList<StagesOfTheContract> StagesOfTheContracts { get; set; }
    }
}

