// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RnPlanReceiptOrder.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the RnPlanReceiptOrder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Filters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    public class PlanReceiptOrderFilter : IUserFilter<long>
    {
        public PlanReceiptOrderFilter(long rn)
            : this()
        {
            Rn = rn;
        }

        public PlanReceiptOrderFilter()
        {
            GroundDocumentDate = new Between<DateTime?>();
            CreationDate = new Between<DateTime?>();
            StateDate = new Between<DateTime?>();
            States = new List<PlanReceiptOrderState>
            {
                PlanReceiptOrderState.Close,
                PlanReceiptOrderState.Confirm,
                PlanReceiptOrderState.NotСonfirm,
                PlanReceiptOrderState.PartWork
            };
            PlanCertificate = PlanCertificateFilter.Default;
            StaffingDivision = StaffingDivisionFilter.Default;
            StoreGasStationOilDepot = StoreGasStationOilDepotFilter.Default;
            GroundTypeOfDocument = TypeOfDocumentFilter.Default;
            GroundReceiptDocNumb = string.Empty;
            GroundReceiptDocumentDate = new Between<DateTime?>();
            GroundReceiptTypeOfDocument = TypeOfDocumentFilter.Default;
        }

        object IHasUid.Rn { get { return Rn; } }
        public Between<DateTime?> CreationDate { get; set; }
        public Between<DateTime?> GroundDocumentDate { get; set; }
        public string GroundDocumentNumb { get; set; }
        public string Note { get; set; }
        public decimal? Numb { get; set; }
        public string Pref { get; set; }
        public IList<PlanReceiptOrderState> States { get; set; }
        public Between<DateTime?> StateDate { get; set; }
        public PlanCertificateFilter PlanCertificate { get; set; }
        public StaffingDivisionFilter StaffingDivision { get; set; }
        public StoreGasStationOilDepotFilter StoreGasStationOilDepot { get; set; }
        public TypeOfDocumentFilter GroundTypeOfDocument { get; set; }
        public string GroundReceiptDocNumb { get; set; }
        public Between<DateTime?> GroundReceiptDocumentDate { get; set; }
        public TypeOfDocumentFilter GroundReceiptTypeOfDocument { get; set; }

        public static PlanReceiptOrderFilter Default
        {
            get { return new PlanReceiptOrderFilter(); }
        }

        public long Rn { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}