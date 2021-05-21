using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class DepartmentOrderSpecifacationFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public NomenclatureNumberFilter NomenclatureNumber { get; set; }

        public static DepartmentOrderSpecifacationFilter Default
        {
            get
            {
                return new DepartmentOrderSpecifacationFilter {NomenclatureNumber = NomenclatureNumberFilter.Default};
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}