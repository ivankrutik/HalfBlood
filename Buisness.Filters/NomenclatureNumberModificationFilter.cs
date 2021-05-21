using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class NomenclatureNumberModificationFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual NomenclatureNumberFilter NomenclatureNumber { get; set; }

        public static NomenclatureNumberModificationFilter Default
        {
            get { return new NomenclatureNumberModificationFilter(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}