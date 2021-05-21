// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoreGasStationOilDepot.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The store gas station oil depot.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CommonDomain
{
    /// <summary>
    /// The store gas station oil depot.
    /// </summary>
    public class StoreGasStationOilDepot
    {
        public StoreGasStationOilDepot(long rn)
        {
            this.Rn = rn;
        }

        public StoreGasStationOilDepot()
        {           
        }

        public long Rn { get; private set; }
        public string AzsNumber { get; set; }
        public string AzsName { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1}) ", AzsNumber, AzsName);
        }
    }
}
