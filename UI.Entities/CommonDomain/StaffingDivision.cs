// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaffingDivision.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the StaffingDivision type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CommonDomain
{
    using System;

    /// <summary>
    /// The staffing division.
    /// </summary>
    [Serializable]
    public class StaffingDivision
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StaffingDivision"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public StaffingDivision(long rn)
        {
            this.RN = rn;
        }

        public StaffingDivision()
        {
            
        }

        public long? ACTIVPLC { get; set; }
        public User Agnlist_AGENT { get; set; }
        public User Agnlist_OWNER_AGENT { get; set; }
        public DateTime BGNDATE { get; set; }
        public DateTime? CMDOUTDATE { get; set; }
        public long? CMDOUTNOM { get; set; }
        public string CMDOUTNUMB { get; set; }
        public long? CMDOUTTYPE { get; set; }
        public string CODE { get; set; }
        public DateTime? COMMANDDATE { get; set; }
        public long? COMMANDNOM { get; set; }
        public string COMMANDNUMB { get; set; }
        public long? COMMANDTYPE { get; set; }
        public decimal? CRN { get; set; }
        public string DEPARTCODE { get; set; }
        public string DEPARTCTGR { get; set; }
        public string DEPARTDISP { get; set; }
        public string DEPARTNUMB { get; set; }
        public DateTime? ENDDATE { get; set; }
        public bool FLAGPOL { get; set; }
        public bool FLAGSORT { get; set; }
        public string FSSCODE { get; set; }
        public bool GROSSTYPE { get; set; }
        public long HIERLEVEL { get; set; }
        public bool JURSIGN { get; set; }
        public string NAME { get; set; }
        public string NAMEABL { get; set; }
        public string NAMEACC { get; set; }
        public string NAMEDAT { get; set; }
        public string NAMEGEN { get; set; }
        public string NAMENOM { get; set; }
        public bool ORGSIGN { get; set; }
        public bool POSTNAMESIGN { get; set; }
        public long? PRORGLVL { get; set; }
        public long? PRSUBSTS { get; set; }
        public string REASONCODE { get; set; }
        public long RN { get; private set; }
        public bool SENDLISTSIGN { get; set; }
        public string SHORTNAMEGEN { get; set; }
        public string SHORTNAMENOM { get; set; }
        public string SPECIALIZATION { get; set; }
        public bool STAFFSIGN { get; set; }
        public bool TIMESORT { get; set; }

        public override string ToString()
        {
            return this.NAME;
        }
    }
}
