// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryChemicalIndicatorDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DictionaryChemicalIndicatorDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain
{
    using Halfblood.Common;

    public class DictionaryChemicalIndicatorDto : IDto<long>
    {
        public CatalogDto Catalog { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long Rn { get; set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}