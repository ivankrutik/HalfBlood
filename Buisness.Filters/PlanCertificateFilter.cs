// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanCertificateFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanCertificateFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    /// <summary>
    ///     The plan certificate filter.
    /// </summary>
    public class PlanCertificateFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public NomenclatureNumberModificationFilter ModificationNomenclature { get; set; }
        public long RnPlanReceiptOrder { get; set; }

        public static PlanCertificateFilter Default
        {
            get { return new PlanCertificateFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}