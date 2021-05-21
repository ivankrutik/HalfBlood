using System.ComponentModel;
using Filtering.Infrastructure;
using Halfblood.Common;

namespace Buisness.Filters.TestSheetsDomain
{
    public class TestResultFilter : IUserFilter<long>, ITestSheetChild
    {
        object IHasUid.Rn
        {
            get { return Rn; }
        }

        public long RnTestSheet { get; set; }

        public long Rn { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}