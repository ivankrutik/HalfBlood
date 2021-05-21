using System.Collections.Generic;
using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class StaffingDivisionFilter : IUserFilter<long>
    {
        public StaffingDivisionFilter()
        {
            Code = new List<string>();
        }

        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public IList<string> Code { get; set; }
        public string Name { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public static StaffingDivisionFilter Default
        {
            get { return new StaffingDivisionFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}