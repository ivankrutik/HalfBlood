// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificationFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CertificationFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Filters
{
    using System.ComponentModel;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    public class CertificationFilter : IUserFilter<long>
    {
        public CertificationFilter()
        {
            CuttingOrderSpecification = new CuttingOrderSpecificationFilter();
        }
        object IHasUid.Rn { get { return Rn; } }
        public long? TransInvDeptSpecs { get; set; }
        public long Acatalog { get; set; }
        public CuttingOrderSpecificationFilter CuttingOrderSpecification { get; set; }

        public static CertificationFilter Default
        {
            get { return new CertificationFilter(); }
        }

        public long Rn { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}