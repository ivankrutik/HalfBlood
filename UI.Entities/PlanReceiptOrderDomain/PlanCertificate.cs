// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanCertificate.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanCertificate type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain
{
    using System;
    using System.Collections.Generic;
    using Halfblood.Common;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Entities.CommonDomain;
    using UI.Entities.NomeclatorDomain;

    /// <summary>
    /// The plan certificate.
    /// </summary>
    public class PlanCertificate : EntityBase<PlanCertificate>, IHasState<PlanCertificateState>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanCertificate"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public PlanCertificate(long rn)
            : this()
        {
            this.Rn = rn;
        }
        public PlanCertificate()
        {
            this.CertificateQuality = new CertificateQuality();
        }

        public CertificateQuality CertificateQuality { get; set; }
        public decimal? CountByDocument { get; set; }
        public decimal? CountFact { get; set; }
        public DateTime? CreationDate { get; set; }
        public NameOfCurrency NameOfCurrency { get; set; }
        public string Note { get; set; }
        public IList<PlanReceiptOrderPersonalAccount> PersonalAccounts { get; set; }
        public PlanReceiptOrder PlanReceiptOrder { get; set; }
        public decimal? Price { get; set; }
        public PlanCertificateState State { get; set; }
        public DateTime? StateDate { get; set; }
        public StoreGasStationOilDepot StoreGasStationOilDepot { get; set; }
        public User UserCreator { get; set; }
        public NomenclatureNumberModification ModificationNomenclature { get; set; }
        public NomenclatureNumberModification ModificationNomenclatureGoodsManager { get; set; }
        public TaxBand TaxBand { get; set; }
        public UnitOfMeasure Measure { get; set; }
        public decimal? SumDocumenta { get; set; }
        public decimal? SumWithTaxDocumenta { get; set; }
    }
}
