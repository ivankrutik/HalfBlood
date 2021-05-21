// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoreGasStationOilDepotDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the StoreGasStationOilDepotDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CommonDomain
{
    using Halfblood.Common;

    public class StoreGasStationOilDepotDto : IDto<long>
    {
        public long Rn { get; set; }
        object IHasUid.Rn { get { return Rn; } }
        public string AzsNumber { get; set; }
        public string AzsName { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1}) ", this.AzsNumber, this.AzsName);
        }
    }
}