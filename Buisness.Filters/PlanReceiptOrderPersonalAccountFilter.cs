// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderPersonalAccountFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderPersonalAccountFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Filters
{
    using System;
    using System.ComponentModel;

    using Buisness.Entities.CommonDomain;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    public class PlanReceiptOrderPersonalAccountFilter : IUserFilter<long>
    {
        public PlanReceiptOrderPersonalAccountFilter()
        {
            PlanCertificate = PlanCertificateFilter.Default;
        }

        object IHasUid.Rn { get { return Rn; } }
        public string PersonalAccount { get; set; }
        public decimal? Count { get; set; }
        public decimal? CountAlt { get; set; }
        public DateTime? CreationDate { get; set; }
        public UserDto Creator { get; set; }
        public long CRN { get; set; }
        //public NameOfCurrency NameOfCurrency { get; set; }
        public string Note { get; set; }
        public PlanCertificateFilter PlanCertificate { get; set; }
        public long Rn { get; set; }
        public long? State { get; set; }
        public DateTime? StateDate { get; set; }
        public UserFilter UserSetState { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public static PlanReceiptOrderPersonalAccountFilter Default
        {
            get { return new PlanReceiptOrderPersonalAccountFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}