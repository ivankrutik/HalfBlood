using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class SampleCertificationFilter : IUserFilter<long>
    {
        public SampleCertificationFilter()
        {
            Sample = new SampleFilter();
        }

        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public long? TransInvDeptSpecs { get; set; }
        public long? Acatalog { get; set; }
        public SampleFilter Sample { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public static SampleCertificationFilter Default
        {
            get { return new SampleCertificationFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}