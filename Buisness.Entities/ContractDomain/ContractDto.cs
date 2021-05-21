// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ContractDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.ContractDomain
{
    using System;
    using System.Collections.Generic;
    using Buisness.Entities.CommonDomain;
    using Halfblood.Common;

    /// <summary>
    ///     The contract dto.
    /// </summary>
    public class ContractDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Pref { get; set; }
        public string Numb { get; set; }
        public DateTime DocDate { get; set; }
        public string ExtNumber { get; set; }
        public DateTime? RegDate { get; set; }
        public ContractStatusState Status { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public UserDto ContractorAgent { get; set; }
        public IList<StagesOfTheContractDto> StagesOfTheContracts { get; set; }
        public long Rn { get; set; }
    }
}