// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderMoveFilter.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the CuttingOrderMoveFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class CuttingOrderMoveFilter : IUserFilter<long>
    {
        public CuttingOrderMoveFilter()
        {
            CuttingOrder = new CuttingOrderFilter();
        }

        object IHasUid.Rn { get { return Rn; } }
        public Between<DateTime> CreationDate { get; set; }
        public string Note { get; set; }
        public long Crn { get; set; }
        public UserFilter RecipientDocument { get; set; }
        public CuttingOrderFilter CuttingOrder { get; set; }

        public static CuttingOrderMoveFilter Default
        {
            get { return new CuttingOrderMoveFilter(); }
        }

        public long Rn { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}