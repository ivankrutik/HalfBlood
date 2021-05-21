using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class TaxFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long TaxBandRN { get; set; }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}