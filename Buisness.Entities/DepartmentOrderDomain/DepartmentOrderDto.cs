// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentOrderDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DepartmentOrderDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.DepartmentOrderDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;
    using Halfblood.Common;

    [RelationEntityToDto(NamesOfSectionSystem.DepartmentsOrder)]
    public class DepartmentOrderDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public string Pref { get; set; }
        public string Numb { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual DepartmentOrderState State { get; set; }
        public DateTime? StateDate { get; set; }
        public long? Priority { get; set; }
        public string Admitted { get; set; }
        public decimal RequestedQuantity { get; set; }
        public decimal ConfirmedQuantity { get; set; }
        public byte[] WantDateCreate { get; set; }
        public string Material { get; set; }
        public DepartmentOrderClosedRequirementType ClosedRequirement { get; set; }
        public UserDto UserCreator { get; set; }
        public UserDto Matching { get; set; }
        public StoreGasStationOilDepotDto WarehouseReceiver { get; set; }
        public StoreGasStationOilDepotDto WarehouseSource { get; set; }
        public IList<DepartmentOrderSpecifacationDto> Specifications { get; set; }
        public IList<DepartmentOrderCommentDto> Comments { get; set; }
        public CatalogDto Catalog { get; set; }
    }
}