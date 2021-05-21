// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StagesOfTheContractDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the StagesOfTheContractDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.ContractDomain
{
    using System;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    public class StagesOfTheContractDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual string Numb { get; set; }
        public virtual StageStatusState Status { get; set; }
        public virtual bool Extagreement { get; set; }
        public virtual bool SignSum { get; set; }
        public virtual DateTime BeginDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual PersonalAccountDto PersonalAccount { get; set; }
        public virtual bool SumType { get; set; }
        public virtual decimal Stagesum { get; set; }
        public virtual decimal StageSumTax { get; set; }
        public virtual string Description { get; set; }
        public virtual string Comments { get; set; }
        public virtual decimal Stagesumnds { get; set; }
        public virtual ContractDto Contract { get; set; }
        public virtual long Rn { get; set; }
    }
}