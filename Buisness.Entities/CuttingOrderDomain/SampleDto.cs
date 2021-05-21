// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the SampleDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CuttingOrderDomain
{
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.NomenclatorDomain;

    using Halfblood.Common;

    public class SampleDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long? Count { get; set; }
        public long? BatchSize { get; set; }
        public long? GeometricsLength { get; set; }
        public long? GeometricsWidth { get; set; }
        public long? NormExpense { get; set; }
        public long? Weight { get; set; }
        public string Note { get; set; }
        public UnitOfMeasureDto Measure { get; set; }
        public CatalogDto Catalog { get; set; }
        public NomenclatureNumberModificationDto NomModif { get; set; }
        public UserDto Creator { get; set; }
        public CuttingOrderSpecificationDto CuttingOrderSpecification { get; set; }
        public IList<SampleCertificationDto> SampleCertification { get; set; }
        public long Rn { get; set; }
    }
}