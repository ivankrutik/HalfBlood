// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.PlanReceiptOrderDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    [RelationEntityToDto(NamesOfSectionSystem.PlanReceiptOrder)]
    public class PlanReceiptOrderWithoutPlanCertificateDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public DateTime? CreationDate { get; set; }
        public DateTime? GroundDocumentDate { get; set; }
        public string GroundDocumentNumb { get; set; }
        public string Note { get; set; }
        public long Numb { get; set; }
        public string Pref { get; set; }
        public StaffingDivisionDto StaffingDivision { get; set; }
        public PlanReceiptOrderState State { get; set; }
        public DateTime? StateDate { get; set; }
        public StoreGasStationOilDepotDto StoreGasStationOilDepot { get; set; }
        public TypeOfDocumentDto GroundTypeOfDocument { get; set; }
        public UserDto UserContractor { get; set; }
        public UserDto UserCreator { get; set; }
        public string GroundReceiptDocumentNumb { get; set; }
        public DateTime? GroundReceiptDocumentDate { get; set; }
        public TypeOfDocumentDto GroundReceiptTypeOfDocument { get; set; }
        public CatalogDto Catalog { get; set; }
        public long Rn { get; set; } 
    }

    [RelationEntityToDto(NamesOfSectionSystem.PlanReceiptOrder)]
    public class PlanReceiptOrderDto : PlanReceiptOrderWithoutPlanCertificateDto
    {
        public IList<PlanCertificateDto> PlanCertificates { get; set; }
    }
}