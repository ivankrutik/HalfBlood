using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class TypeOfDocumentFilter : IUserFilter<long>
    {
        public TypeOfDocumentFilter()
        {
            DocCode = string.Empty;
            DocName = string.Empty;
        }

        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public string DocCode { get; set; }
        public string DocName { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public static TypeOfDocumentFilter Default
        {
            get { return new TypeOfDocumentFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}