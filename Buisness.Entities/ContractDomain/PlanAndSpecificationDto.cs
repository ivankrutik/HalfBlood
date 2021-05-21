// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanAndSpecificationDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the PlanAndSpecificationDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.ContractDomain
{
    using System;

    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.NomenclatorDomain;
    using Halfblood.Common;

    public class PlanAndSpecificationDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? Price { get; set; }
        public decimal? Quant { get; set; }
        public decimal? SumWithTaxDocumenta { get; set; }
        public decimal PlanQuant { get; set; }
        public decimal FactQuant { get; set; }
        public decimal PlanSum { get; set; }
        public decimal FactSum { get; set; }
        public decimal? SumWithNds { get; set; }
        public CatalogDto Catalog { get; set; }
        public NomenclatureNumberDto NomenclatureNumber { get; set; }
        public TaxBandDto TaxBand { get; set; }
        public PersonalAccountDto PersonalAccount { get; set; }
        public NomenclatureNumberModificationDto ModificationNomenclature { get; set; }
    }
}
