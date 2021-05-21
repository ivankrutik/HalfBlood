using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class StoreGasStationOilDepotFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public string AzsNumber { get; set; }
        public string AzsName { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public static StoreGasStationOilDepotFilter Default
        {
            get { return new StoreGasStationOilDepotFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}