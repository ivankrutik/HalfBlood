namespace UI.Entities.DepartmentOrderDomain
{
    using System;
    using System.Collections.Generic;
    using Halfblood.Common;

    using ReactiveUI;

    using UI.Entities.CommonDomain;

    public class DepartmentOrder : EntityBase<DepartmentOrder>
    {
        public DepartmentOrder()
        {
            Specifications = new ReactiveList<DepartmentOrderSpecification>();
            Comments = new ReactiveList<DepartmentOrderComment>();
        }

        public DepartmentOrder(long rn)
            : this()
        {
            Rn = rn;
        }
        public string Pref { get; set; }
        public string Numb { get; set; }
        public DateTime CreationDate { get; set; }
        public DepartmentOrderState State { get; set; }
        public DateTime? StateDate { get; set; }
        public long? Priority { get; set; }
        public string Admitted { get; set; }
        public decimal RequestedQuantity { get; set; }
        public decimal ConfirmedQuantity { get; set; }
        public byte[] WantDateCreate { get; set; }
        public string Material { get; set; }
        public DepartmentOrderClosedRequirementType ClosedRequirement { get; set; }
        public User UserCreator { get; set; }
        public User Matching { get; set; }
        public StoreGasStationOilDepot WarehouseReceiver { get; set; }
        public StoreGasStationOilDepot WarehouseSource { get; set; }
        public IList<DepartmentOrderSpecification> Specifications { get; set; }
        public IList<DepartmentOrderComment> Comments { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is DepartmentOrder == false) return false;
            if (Object.ReferenceEquals(this, obj)) return true;

            if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
                return false;

            var value = obj as DepartmentOrder;

            return Rn == value.Rn;
        }
        public override int GetHashCode()
        {
            return Rn.GetHashCode();
        }
    }
}
