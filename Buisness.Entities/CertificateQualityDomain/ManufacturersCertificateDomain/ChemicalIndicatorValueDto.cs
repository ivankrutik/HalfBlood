// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChemicalIndicatorValueDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ChemicalIndicatorValueDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using Halfblood.Common;

    /// <summary>
    ///     The chemical indicator value dto.
    /// </summary>
    public class ChemicalIndicatorValueDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Value { get; set; }
        public CertificateQualityDto CertificateQuality { get; set; }
        public DictionaryChemicalIndicatorDto ChemicalIndicator { get; set; }
        public long Rn { get; set; }
    }
}