using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class DictionaryPassFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public string Pass { get; set; }
        public string MemoPass { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public static DictionaryPassFilter Default
        {
            get { return new DictionaryPassFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}