// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Filters
{
    using System;
    using System.ComponentModel;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    public class UserFilter : IUserFilter<long>
    {
        public UserFilter()
        {
            ActiveState = new Between<DateTime?>();
        }
        public AgnlistCatalog TypeCatalog { get; set; }
        object IHasUid.Rn { get { return Rn; } }
        public bool IsWorker { get; set; }
        public string OrganizationName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string TableNumber { get; set; }
        public string NameShort { get; set; }
        public Between<DateTime?> ActiveState { get; set; }

        public static UserFilter Default
        {
            get { return new UserFilter(); }
        }

        public long Rn { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}