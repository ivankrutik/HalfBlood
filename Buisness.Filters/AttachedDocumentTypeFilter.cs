using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class AttachedDocumentTypeFilter : IUserFilter<long>
    {
        public long Rn { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        object IHasUid.Rn { get { return Rn; } }
        public int Skip { get; set; }
        public int Take { get; set; }

        public static AttachedDocumentTypeFilter Default
        {
            get { return new AttachedDocumentTypeFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}