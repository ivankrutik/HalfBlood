using System.ComponentModel;
using Filtering.Infrastructure;
using Halfblood.Common;

namespace Buisness.Filters
{
    public class LinkFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public DirectionFind Direction { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
