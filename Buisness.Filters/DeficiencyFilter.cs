namespace Buisness.Filters
{
    using System.ComponentModel;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    public class DeficiencyFilter : IUserFilter<long>
    {
        public string ShopRecipient { get; set; }
        public string ShopTheManufacturer { get; set; }
        public string DSE { get; set; }
        object IHasUid.Rn
        {
            get
            {
                return Rn;
            }
        }

        public long Rn { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
