// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxBandDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the TaxBandDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CommonDomain
{
    using System;

    using Halfblood.Common;

    public class TaxDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public long Kind { get; set; }
        public long Typees { get; set; }
        public DateTime BeginDate { get; set; }
        public decimal Value { get; set; }
        public decimal ValueRet { get; set; }
        public decimal Sum { get; set; }
        public long IsRound { get; set; }
        public bool RetCalc { get; set; }
        public TaxBandDto TaxBand { get; set; }
    }
}