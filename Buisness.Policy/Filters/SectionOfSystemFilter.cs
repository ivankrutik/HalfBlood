using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.InternalEntity.Filters
{
    using Halfblood.Common;

    public class SectionOfSystemFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}