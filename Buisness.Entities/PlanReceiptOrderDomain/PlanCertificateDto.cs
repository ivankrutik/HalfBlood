// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanCertificateDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanCertificateDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Buisness.Entities.PlanReceiptOrderDomain
{
    using System;
    using System.Collections.Generic;
    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.NomenclatorDomain;
    using Halfblood.Common;

    public class PlanCertificateDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public decimal? CountByDocument { get; set; }
        public decimal? CountFact { get; set; }
        public DateTime? CreationDate { get; set; }
        public NameOfCurrencyDto NameOfCurrency { get; set; }
        public string Note { get; set; }
        public decimal? Price { get; set; }
        public PlanCertificateState State { get; set; }
        public DateTime? StateDate { get; set; }
        public StoreGasStationOilDepotDto StoreGasStationOilDepot { get; set; }
        public UserDto UserCreator { get; set; }
        public NomenclatureNumberModificationDto ModificationNomenclature { get; set; }
        public NomenclatureNumberModificationDto ModificationNomenclatureGoodsManager { get; set; }
        public PlanReceiptOrderDto PlanReceiptOrder { get; set; }
        public CatalogDto Catalog { get; set; }
        public CertificateQualityDto CertificateQuality { get; set; }
        public IList<PlanReceiptOrderPersonalAccountDto> PersonalAccounts { get; set; }
        public TaxBandDto TaxBand { get; set; }
        public UnitOfMeasureDto Measure { get; set; }
        public decimal? SumDocumenta { get; set; }
        public decimal? SumWithTaxDocumenta { get; set; }
        public long Rn { get; set; }
    }
}