using System.ComponentModel;
using Filtering.Infrastructure;
using Halfblood.Common;

namespace Buisness.Filters
{
    public class EmployeeFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }

        public string Fullname { get; set; }

        public long Rn { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public static EmployeeFilter Default
        {
            get { return new EmployeeFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
