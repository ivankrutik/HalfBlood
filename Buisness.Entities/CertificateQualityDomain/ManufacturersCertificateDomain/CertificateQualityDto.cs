// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificateQualityDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CertificateQualityDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using System;
    using System.Collections.Generic;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;

    using Halfblood.Common;

    /// <summary>
    ///     The certificate quality dto.
    /// </summary>
    [RelationEntityToDto(NamesOfSectionSystem.CertificateQuality)]
    public class CertificateQualityDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public DateTime? CreationDate { get; set; }
        public QualityCertificateState State { get; set; }
        public DateTime StateDate { get; set; }
        public string Marka { get; set; }
        public string Cast { get; set; }
        public string FullRepresentation { get; set; }
        public string GostMarka { get; set; }
        public string GostMix { get; set; }
        public DateTime? MakingDate { get; set; }
        public decimal? Numb { get; set; }
        public string Pref { get; set; }
        public string NomerCertificate { get; set; }
        public string Note { get; set; }
        public string Mix { get; set; }
        public DateTime? StorageDate { get; set; }
        public string StandardSize { get; set; }
        public string BoldId { get; set; }
        public string IdMater { get; set; }
        public PlanCertificateDto PlanCertificate { get; set; }
        public UserDto AgnlistCreatorFactory { get; set; }
        public UserDto UserCreator { get; set; }
        public DictionaryPassDto Pass { get; set; }
        public CatalogDto Catalog { get; set; }
        public IList<DestinationDto> Destinations { get; set; }
        public IList<PassDto> Passes { get; set; }
        public IList<ChemicalIndicatorValueDto> ChemicalIndicatorValues { get; set; }
        public IList<MechanicIndicatorValueDto> MechanicIndicatorValues { get; set; }
        public IList<CertificateQualityAttachedDocumentDto> AttachedDocuments { get; set; }
        public long Rn { get; set; }
    }
}