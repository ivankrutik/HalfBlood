using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class QualityStateControlOfTheMakeSignatureFilter : IUserFilter<long>
    {
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        object IHasUid.Rn { get { return Rn; } }
    }
}