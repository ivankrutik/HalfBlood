// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Stage.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the Stage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModelLite.ContractDomain
{
    using System;
    using Halfblood.Common;

    public class StagesOfTheContractLiteDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual string Numb { get; set; }
        public virtual StageStatusState State { get; set; }
        public virtual DateTime BeginDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string Description { get; set; }
        public virtual string Comments { get; set; }
        public virtual string PersonalAccountNumb { get; set; }

        public virtual long PersonalAccountRN { get; set; }
        public virtual long ContractRN { get; set; }
    }
}