namespace Buisness.Filters
{
    using System.ComponentModel;
    using Filtering.Infrastructure;
    using Halfblood.Common;


    public class GoodsManagerFilter : IUserFilter<long>
    {

        public UserFilter Contractor { get; set; }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        object IHasUid.Rn
        {
            get { return Rn; }
        }

        public static GoodsManagerFilter Default
        {
            get { return new GoodsManagerFilter { Contractor = new UserFilter() }; }
        }

        public GoodsManagerFilter()
        {
            Contractor = new UserFilter();
        }
    }
}
