// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderSpecificationDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CuttingOrderSpecificationDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CuttingOrderDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.NomenclatorDomain;

    using Halfblood.Common;

    public class CuttingOrderSpecificationDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public CuttingOrderState State { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? AssumeDate { get; set; }
        public long? NormExpense { get; set; }
        public long? CountPartWithBlank { get; set; }
        public long? PartBlankWeight { get; set; }
        public long? PartBlankLenght { get; set; }
        public long? PartBlankWidth { get; set; }
        public long? MaxDeflectionLenght { get; set; }
        public long? MinDeflectionLenght { get; set; }
        public long? DemandContract { get; set; }
        public long? DemandGoods { get; set; }
        public long? DemandPlanMonth { get; set; }
        public UnitOfMeasureDto MeasureWeight { get; set; }
        public UnitOfMeasureDto MeasureNorm { get; set; }
        public PersonalAccountDto PersonalAccount { get; set; }
        public CatalogDto Catalog { get; set; }
        public StaffingDivisionDto Department { get; set; }
        public NomenclatureNumberModificationDto NomModif { get; set; }
        public UserDto Inspector { get; set; }
        public CuttingOrderDto CuttingOrder { get; set; }
        public IList<SampleDto> Samples { get; set; }
        public IList<CertificationDto> Certifications { get; set; }
        public long Rn { get; set; }
    }
}