using System.Collections.Generic;
using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class SampleFilter : IUserFilter<long>
    {
        public SampleFilter()
        {
            CuttingOrderSpecification = new CuttingOrderSpecificationFilter();
        }

        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public long? Count { get; set; }
        public long? BatchSize { get; set; }
        public long? GeometricsLength { get; set; }
        public long? GeometricsWidth { get; set; }
        public long? NormExpense { get; set; }
        public long? Weight { get; set; }
        public string Note { get; set; }
        public long Crn { get; set; }
        public NomenclatureNumberModificationFilter NomModif { get; set; }
        public UserFilter Creator { get; set; }
        public CuttingOrderSpecificationFilter CuttingOrderSpecification { get; set; }
        public IList<SampleCertificationFilter> SampleCertification { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public static SampleFilter Default
        {
            get { return new SampleFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}