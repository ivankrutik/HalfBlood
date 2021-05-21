using System;
using System.Collections.Generic;
using System.ComponentModel;
using Filtering.Infrastructure;
using Halfblood.Common;

namespace Buisness.Filters
{
    public class DepartmentOrderFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Pref { get; set; }
        public int Numb { get; set; }
        public DepartmentOrderState State { get; set; }
        public Between<DateTime?> StateDate { get; set; }
        public StoreGasStationOilDepotFilter WarehouseReceiver { get; set; }
        public StoreGasStationOilDepotFilter WarehouseSource { get; set; }

        public static DepartmentOrderFilter Default
        {
            get
            {
                return new DepartmentOrderFilter
                {
                };
            }
        }

        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}