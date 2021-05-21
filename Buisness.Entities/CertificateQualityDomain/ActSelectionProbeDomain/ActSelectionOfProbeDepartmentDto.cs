// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeDepartment.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The selection of probe dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ActSelectionProbeDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    /// <summary>
    ///     The selection of probe dto.
    /// </summary>
    [RelationEntityToDto(NamesOfSectionSystem.PlanReceiptOrderDepartment)]
    public class ActSelectionOfProbeDepartmentDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public DateTime? DateCreate { get; set; }
        public UserDto Creator { get; set; }
        public ActSelectionOfProbeDto ActSelectionOfProbe { get; set; }
        public UserDto AgentDepartment { get; set; }
        public DateTime? AgentDepartmentDate { get; set; }
        public UserDto ControlerOtk { get; set; }
        public DateTime? ControlerOtkDate { get; set; }
        public UserDto Customer { get; set; }
        public DateTime? CustomerDate { get; set; }
        public UserDto ReceiptLaboratory { get; set; }
        public DateTime? ReceiptLaboratoryDate { get; set; }
        public IList<ActSelectionOfProbeDepartmentRequirementDto> Requirements { get; set; }
        public long Rn { get; set; }
        public decimal? Quantity { get; set; }
        public string Note { get; set; }
        public StaffingDivisionDto DepartmentReceiver { get; set; }
        public StaffingDivisionDto DepartmentMakingSample { get; set; }

        public UserDto Receiver { get; set; }
        public decimal? QuantityReceiver { get; set; }
        public DateTime? ReceiverDate { get; set; }
        public CatalogDto Catalog { get; set; }
    }
}