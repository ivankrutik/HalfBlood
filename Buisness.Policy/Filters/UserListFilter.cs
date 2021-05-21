namespace Buisness.InternalEntity.Filters
{
    using Halfblood.Common;
    using System.ComponentModel;
    using Filtering.Infrastructure;


    public class UserListFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Authi { get; set; }
        public string Name { get; set; }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}