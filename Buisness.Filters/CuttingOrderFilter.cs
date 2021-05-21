// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderFilter.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the CuttingOrderFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Filtering.Infrastructure;
using Halfblood.Common;

namespace Buisness.Filters
{
    public class CuttingOrderFilter : IUserFilter<long>
    {
        public CuttingOrderFilter()
        {
            AssumeDate = new Between<DateTime?>();
            CreationDate = new Between<DateTime?>();
            Creator = UserFilter.Default;
            DateDocumentIntegration = new Between<DateTime?>();
            Department = StaffingDivisionFilter.Default;
            District = StaffingDivisionFilter.Default;
            Inspector = UserFilter.Default;
            Priority = new List<CuttingOrderPriority>
            {
                CuttingOrderPriority.FirstPriority,
                CuttingOrderPriority.SecondPriority
            };
            State = new List<CuttingOrderState> {CuttingOrderState.FirstState, CuttingOrderState.SecondState};
            Storekeeper = UserFilter.Default;
        }

        object IHasUid.Rn { get { return Rn; } }
        public decimal? Numb { get; set; }
        public string Pref { get; set; }
        public IList<CuttingOrderState> State { get; set; }
        public string Note { get; set; }
        public Between<DateTime?> DateDocumentIntegration { get; set; }
        public IList<CuttingOrderPriority> Priority { get; set; }
        public Between<DateTime?> CreationDate { get; set; }
        public Between<DateTime?> AssumeDate { get; set; }
        public StaffingDivisionFilter Department { get; set; }
        public StaffingDivisionFilter District { get; set; }
        public UserFilter Storekeeper { get; set; }
        public UserFilter Inspector { get; set; }
        public UserFilter Creator { get; set; }

        public static CuttingOrderFilter Default
        {
            get { return new CuttingOrderFilter(); }
        }

        public long Rn { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}