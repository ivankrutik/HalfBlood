namespace Buisness.Workflows.Managers.ExpenditureInvoiceDomain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;

    using Buisness.Components.StoredProcedure.ExpenditureInvoiceDomain;
    using Buisness.Entities.CommonDomain;
    using Buisness.Workflows.Helper;

    using DataAccessLogic.Infrastructure;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;

    using NHibernate.Helper.Filter.Specification;
    using NHibernate.Helper.Repository;

    using ParusModel.Entities;
    using ParusModel.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModel.Entities.CertificateQualityDomain.WarehouseQualityCertificateDomain;
    using ParusModel.Entities.CreditSlipDomain;
    using ParusModel.Entities.ExpenditureInvoiceDomain;
    using ParusModel.Entities.GoodsSupplyDomain;

    using ServiceContracts.Exceptions;

    public class ExpenditureInvoiceManager
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public ExpenditureInvoiceManager(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public long TakeMaterial(
            decimal quantity,
            DateTime dateOfBook,
            string numberOfBook,
            StoreGasStationOilDepot storeGasStationOilDepot,
            long certificateQualityUid,
            EmployeeDto controller,
            EmployeeDto customer)
        {
            var repositoryCertificateQuality = _repositoryFactory.Create<CertificateQuality>();
            var repositoryExpInvoice = _repositoryFactory.Create<ExpenditureInvoice>();
            var repositoryDocumentLinks = _repositoryFactory.Create<RelationshipBetweenDocuments>();
            var repositoryWarehouseQualityCertificate = _repositoryFactory.Create<WarehouseQualityCertificate>();
            var repositoryCreditSlipSpecs = _repositoryFactory.Create<CreditSlipSpecification>();
            var repositoryGoodsSupply = _repositoryFactory.Create<GoodsSupply>();

            var certificateQuality = repositoryCertificateQuality.Get(certificateQualityUid);
            var doclinksUid =
                repositoryDocumentLinks.Specify()
                    .Where(x => x.InDocument == certificateQuality.Rn)
                    .And(x => x.InUnitCode == NamesOfSectionSystem.CertificateQuality)
                    .And(x => x.OutUnitCode == NamesOfSectionSystem.CreditSlipSpecification)
                    .Select(x => x.OutDocument)
                    .Future<long>();

            var creditSlipSpecs =
                repositoryCreditSlipSpecs.Specify()
                    .IsInEmpty(x => x.Rn, doclinksUid.ToArray())
                    .Future<CreditSlipSpecification>();

            var measure = creditSlipSpecs.First().NomenclatureNumberModification.NomenclatureNumber.DicmuntUmeasMain;

            var goodsSupplies =
                repositoryGoodsSupply.Specify()
                    .IsInEmpty(x => x.Rn, creditSlipSpecs.Select(x => x.GOODSSUPPLY).ToArray())
                    .Future<GoodsSupply>();

            var store = goodsSupplies.First().StoreGasStationOilDepot;

            var sumRest = goodsSupplies.Sum(x => x.RESTFACT);
            if (sumRest < quantity)
            {
                throw new DepartmentOrderException(
                    Resource.EIS_0.StringFormat(
                        certificateQuality.FullRepresentation,
                        certificateQuality.NomerCertificata,
                        sumRest,
                        measure.Code,
                        quantity));
            }


            var rest = quantity;
            var dictionaryGoodsSupply = new Dictionary<GoodsSupply, decimal>();
            foreach (var elem in goodsSupplies)
            {
                if (elem.RESTFACT - rest >= 0)
                {
                    dictionaryGoodsSupply.Add(elem, rest);
                    break;
                }

                if (elem.RESTFACT - rest <= 0)
                {
                    dictionaryGoodsSupply.Add(elem, elem.RESTFACT);
                    rest = rest - elem.RESTFACT;
                }
            }


            var expenditureInvoice = new ExpenditureInvoice
                                         {
                                             Catalog = new Catalog(49528001),
                                             LegalPerson = new LegalPerson { Rn = LegalPerson.GPO },
                                             TypeOfDocument = new TypeOfDocument { Rn = TypeOfDocument.ExpenditureInvoice },
                                             Pref = store.Number.ShortYear(),
                                             Docdate = DateTime.Now,
                                             Stoper = new KindOfWarehouseOperations { Rn = KindOfWarehouseOperations.InternalMovingExpense },
                                             Store = store,
                                             ViewShipment = 246316267,
                                             NameOfCurrency = new NameOfCurrency { Rn = NameOfCurrency.Rub },
                                             CurCours = 1,
                                             CurBase = 1,
                                             SummWithnds = 0,
                                             InStore = storeGasStationOilDepot,
                                             InCurcours = 1,
                                             InCurBase = 1,
                                             TypeOfDocumentValidTypeOfDocument = new TypeOfDocument { Rn = 246318164 },
                                             ValidDocDate = dateOfBook,
                                             ValidDocNumb = numberOfBook,
                                         };

            

            dictionaryGoodsSupply.DoForEach(
                x =>
                {
                    var expenditureInvoiceSpecification = new ExpenditureInvoiceSpecification
                    {
                        ExpenditureInvoice = expenditureInvoice,
                        NomenclatureNumberModification = x.Key.GoodsParty.NomenclatureNumberModification,
                        Price = 0,
                        Quantity = x.Value,
                        QuantityAlt = 0,
                        Coeff = 0,
                        CoeffValSign = 0,
                        CoeffValcSign = 1,
                        PriceMeasure = 0,
                        SummWithNDS = 0,
                        GoodsParty = x.Key.GoodsParty
                    };
                    expenditureInvoice.ExpenditureInvoiceSpecifications.Add(expenditureInvoiceSpecification);
                });


            repositoryExpInvoice.Insert(expenditureInvoice);
            expenditureInvoice.WorkDate = DateTime.Now;
            repositoryExpInvoice.ExecuteSPUniqueResult<ExpenditureInvoice>(
                new ExpenditureInvoiceSetStateSP(
                    expenditureInvoice,
                    InvoiceForTransmissionInUnitState.WorkFact,
                    InvoiceForTransmissionInUnitInState.Yes));

            var warehouseQualityCertificate = new WarehouseQualityCertificate
            {
                ControllerQuality = new Contractor { Rn = controller.Rn },
                Customer = new Contractor { Rn = customer.Rn },
                //Catalog = new Catalog(1007400827),
                Catalog = new Catalog(1195988283),
                
                ExpenditureInvoice = expenditureInvoice
            };
            var certificateUid = (long)repositoryWarehouseQualityCertificate.Insert(warehouseQualityCertificate);

            var documentLink = new RelationshipBetweenDocuments
            {
                InDocument = certificateQuality.Rn,
                OutDocument = warehouseQualityCertificate.Rn,
                InUnitCode = NamesOfSectionSystem.CertificateQuality,
                OutUnitCode = NamesOfSectionSystem.WarehouseQualityCertificate
            };

            repositoryDocumentLinks.Insert(documentLink);

            return certificateUid;
        }


        public void Remove(long rnCertificate)
        {
            var repositoryExpInvoice = _repositoryFactory.Create<ExpenditureInvoice>();
            var repositoryDocumentLinks = _repositoryFactory.Create<RelationshipBetweenDocuments>();
            var repositoryWarehouseQualityCertificate = _repositoryFactory.Create<WarehouseQualityCertificate>();

            var certificate = repositoryWarehouseQualityCertificate.Get(rnCertificate);

            repositoryExpInvoice.Delete(certificate.ExpenditureInvoice);
            var rnDoclinks =
                repositoryDocumentLinks.Specify()
                    .Where(x => x.OutDocument == certificate.Rn)
                    .And(x => x.InUnitCode == NamesOfSectionSystem.CertificateQuality)
                    .And(x => x.OutUnitCode == NamesOfSectionSystem.WarehouseQualityCertificate).Future<RelationshipBetweenDocuments>();
            repositoryDocumentLinks.Delete(rnDoclinks.First());
            repositoryWarehouseQualityCertificate.Delete(certificate);
        }
    }
}