// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxBandDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the TaxBandDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModelLite.CommonDomain
{
    using System;
    using Halfblood.Common;

    public class TaxLiteDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual long Kind { get; set; }
        public virtual long Type { get; set; }
        public virtual DateTime BeginDate { get; set; }
        public virtual decimal Value { get; set; }
        public virtual decimal ValueRet { get; set; }
        public virtual decimal Sum { get; set; }
        public virtual long IsRound { get; set; }
        public virtual long RetCalc { get; set; }
        public virtual long TaxBandRN { get; set; }
    }
}