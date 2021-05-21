using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class MechanicIndicatorValueFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public string Value { get; set; }
        public CertificateQualityFilter CertificateQuality { get; set; }
        public DictionaryMechanicalIndicatorFilter MechanicalIndicator { get; set; }

        public static MechanicIndicatorValueFilter Default
        {
            get { return new MechanicIndicatorValueFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}