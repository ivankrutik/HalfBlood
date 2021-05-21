using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class ConclusionFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}