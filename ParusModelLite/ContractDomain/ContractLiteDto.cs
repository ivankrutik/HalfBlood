// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contract.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the Contract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModelLite.ContractDomain
{
    using System;

    using Halfblood.Common;

    public class ContractLiteDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual string Pref { get; set; }
        public virtual string Numb { get; set; }
        public virtual ContractStatusState State { get; set; }
        public virtual string ExtNumber { get; set; }
        public virtual string TypeOfDocument { get; set; }
        public virtual string StaffingDivision { get; set; }
        public virtual string ContractorAgent { get; set; }
        public virtual string ContractorAgentMemo { get; set; }
        public virtual DateTime DocDate { get; set; }
        public virtual DateTime? RegDate { get; set; }
        public virtual DateTime? ConfirmDate { get; set; }
        public virtual DateTime? CloseDate { get; set; }
        public virtual DateTime BeginDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
    }
}
