namespace Buisness.Workflows.Managers.CreditSlipDomain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using Buisness.Workflows.Helper;
    using DataAccessLogic.Infrastructure;
    using Halfblood.AlgorithmsOfCalculation;
    using Halfblood.Common;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.Helper.Repository;
    using ParusModel.Entities;
    using ParusModel.Entities.CreditSlipDomain;
    using ParusModel.Entities.PlanReceiptOrderDomain;

    public class CreditSlipManager
    {
        #region PRIVATE FIELDS
        private static readonly IList<PlanReceiptOrderPersonalAccount> CreateEntities = new List<PlanReceiptOrderPersonalAccount>();
        private static readonly IList<PlanReceiptOrderPersonalAccount> RemoveEntities = new List<PlanReceiptOrderPersonalAccount>();

        private readonly INhRepository<CreditSlip> _repositoryCreditSlip;
        private readonly INhRepository<CreditSlipSpecification> _repositoryCreditSlipSpecs;

        private readonly INhRepository<RelationshipBetweenDocuments> _repositoryLink;
        private readonly INhRepository<Tax> _repositoryTax;
        #endregion

        public CreditSlipManager(IRepositoryFactory repositoryFactory)
        {

            _repositoryCreditSlip = repositoryFactory.Create<CreditSlip>();
            _repositoryLink = repositoryFactory.Create<RelationshipBetweenDocuments>();
            _repositoryCreditSlipSpecs = repositoryFactory.Create<CreditSlipSpecification>();
            _repositoryTax = repositoryFactory.Create<Tax>();
        }

        [STAThread]
        public static void AddCreate(PlanReceiptOrderPersonalAccount entity)
        {
            if (!CreateEntities.Contains(entity))
            {
                CreateEntities.Add(entity);
            }
        }

        [STAThread]
        public static void AddRemove(PlanReceiptOrderPersonalAccount entity)
        {
            if (!RemoveEntities.Contains(entity))
            {
                RemoveEntities.Add(entity);
            }
        }

        [STAThread]
        public static void Clean()
        {
            CreateEntities.Clear();
            RemoveEntities.Clear();
        }


        private CreditSlip FillCreditSlip(PlanReceiptOrderPersonalAccount x)
        {
            var planReceiptOrder = CreateEntities[0].PlaneCertificate.PlanReceiptOrder;

            return new CreditSlip
            {
                //select a.rn into result from acatalog a where a.name = (select 'Склад ' || substr(az.azs_number, 1, 3) from azsazslistmt az where az.rn = nStore) and a.docname = 'IncomingOrders' and a.signs = 1;
                Catalog = new Catalog(28816001),
                LegalPerson = new LegalPerson { Rn = LegalPerson.GPO },
                StoreGasStationOilDepot = planReceiptOrder.StoreGasStationOilDepot,
                KindOfWarehouseOperations = new KindOfWarehouseOperations { Rn = KindOfWarehouseOperations.ReceiptFromSuppliersonWarehouse },
                TypeOfDocument_INTypeOfDocument = new TypeOfDocument { Rn = TypeOfDocument.CreditSlip },
                INDOCDATE = DateTime.Now,
                TypeOfDocument_DIRECTTypeOfDocument = planReceiptOrder.GroundReceiptTypeOfDocument,
                DIRECTDOCNUMB = planReceiptOrder.GroundReceiptDocumentNumb,
                DIRECTDOCDATE = planReceiptOrder.GroundReceiptDocumentDate,
                TypeOfDocument_INVTypeOfDocument = planReceiptOrder.GroundTypeOfDocument,
                INVDOCNUMB = planReceiptOrder.GroundDocumentNumb,
                INVDOCDATE = planReceiptOrder.GroundDocumentDate,
                PricesIncludeTaxes = false,
                CURCOURS = 1,
                CURBASECOURS = 1,
                ACCCOURS = 1,
                ACCBASECOURS = 1,
                FACOURS = 1,
                FABASECOURS = 1,
                NameOfCurrency = new NameOfCurrency { Rn = NameOfCurrency.Rub },
                State = CreditSlipState.NotFulfilled,
                Contragent = new Contractor(),
                WorkDate = DateTime.Now,
                Pref = planReceiptOrder.StoreGasStationOilDepot.Number.ShortYear(),
                PersonalAccount = x.PersonalAccount
            };
        }

        private CreditSlipSpecification FillCreditSlipSpecification(PlanReceiptOrderPersonalAccount x, CreditSlip creditSlip)
        {
            var tax = _repositoryTax.Specify().Where(a => a.TaxBand == x.PlaneCertificate.TaxBand).Future().First().Value;
            var planCertificate = x.PlaneCertificate;

            var creditSlipSpecification = new CreditSlipSpecification
            {
                CreditSlip = creditSlip,
                NomenclatureNumberModification = planCertificate.ModificationNomenclature,
                TaxBand = planCertificate.TaxBand,
                PLANQUANT = (decimal)x.CountByDocument,
                FACTQUANT = (decimal)x.CountFact,
                //тут надо смотреть основную единицу измерения и пересчитавать 
                PLANQUANTALT = 0,
                FACTQUANTALT = 0,
                Price = (decimal)planCertificate.Price,
                PRICEMEAS = false,
                PRICECALCRULE = true,
                ACCPRICE = (decimal)planCertificate.Price,
                ACCPRICEMEAS = false,
                ACCSUMM = CreditSlipDomainAlgorithmsOfCalculation.SumWithoutNDS((decimal)x.CountFact, (decimal)planCertificate.Price),
                PLANSUM = CreditSlipDomainAlgorithmsOfCalculation.SumWithoutNDS((decimal)x.CountByDocument, (decimal)planCertificate.Price),
                PLANSUMTAX = CreditSlipDomainAlgorithmsOfCalculation.SumWithNDS((decimal)x.CountByDocument, (decimal)planCertificate.Price, tax),
                PLANSUMNDS = CreditSlipDomainAlgorithmsOfCalculation.SumNDS((decimal)x.CountByDocument, (decimal)planCertificate.Price, tax),
                FACTSUM = CreditSlipDomainAlgorithmsOfCalculation.SumWithoutNDS((decimal)x.CountFact, (decimal)planCertificate.Price),
                FACTSUMTAX = CreditSlipDomainAlgorithmsOfCalculation.SumWithNDS((decimal)x.CountFact, (decimal)planCertificate.Price, tax),
                FACTSUMNDS = CreditSlipDomainAlgorithmsOfCalculation.SumNDS((decimal)x.CountFact, (decimal)planCertificate.Price, tax),
                AUTOCALCSIGN = true,
                SerNumb = planCertificate.CertificateQuality.Cast
            };

            creditSlip.CreditSlipSpecifications.Add(creditSlipSpecification);
            return creditSlipSpecification;
        }

        private void FillRelationshipBetweenDocuments(long inDocument, long outDocument)
        {
            var documentLink = new RelationshipBetweenDocuments
            {
                InDocument = inDocument,
                OutDocument = outDocument,
                InUnitCode = NamesOfSectionSystem.CertificateQuality,
                OutUnitCode = NamesOfSectionSystem.CreditSlipSpecification
            };
            _repositoryLink.Insert(documentLink);
        }

        [STAThread]
        private void Create()
        {

            var newCreditSlips = new List<CreditSlip>();



            CreateEntities.DoForEach(x =>
            {
                if (!newCreditSlips.Any() ||
                    (newCreditSlips.All(c => c.PersonalAccount != x.PersonalAccount)) ||
                    (newCreditSlips.Any(c => c.PersonalAccount == x.PersonalAccount &&
                                             c.CreditSlipSpecifications.Any(n =>
                                                 n.SerNumb == x.PlaneCertificate.CertificateQuality.Cast &&
                                                 n.NomenclatureNumberModification ==
                                                 x.PlaneCertificate.ModificationNomenclature)
                        ))
                    )
                {
                    var creditSlip = FillCreditSlip(x);
                    var creditSlipSpecification = FillCreditSlipSpecification(x, creditSlip);
                    _repositoryCreditSlip.Insert(creditSlip);
                    FillRelationshipBetweenDocuments(x.PlaneCertificate.CertificateQuality.Rn,
                        creditSlipSpecification.Rn);

                    newCreditSlips.Add(creditSlip);
                }
                else
                {
                    newCreditSlips.DoForEach(z =>
                    {
                        if (z.PersonalAccount == x.PersonalAccount &&
                            !z.CreditSlipSpecifications.Any(n => n.SerNumb == x.PlaneCertificate.CertificateQuality.Cast
                                                                 &&
                                                                 n.NomenclatureNumberModification ==
                                                                 x.PlaneCertificate.ModificationNomenclature))
                        {
                            var creditSlipSpecification = FillCreditSlipSpecification(x, z);
                            _repositoryCreditSlipSpecs.Insert(creditSlipSpecification);
                            FillRelationshipBetweenDocuments(x.PlaneCertificate.CertificateQuality.Rn,
                                creditSlipSpecification.Rn);
                        }
                    });
                }
            });
        }

        [STAThread]
        private void Remove()
        {
            if (!RemoveEntities.Any())
            {
                return;
            }

            var rnCertificateQualities =
                RemoveEntities.Select(x => x.PlaneCertificate.CertificateQuality.Rn).Distinct().ToArray();

            var rnDoclinks =
                _repositoryLink.Specify()
                    .IsInEmpty(x => x.InDocument, rnCertificateQualities)
                    .And(x => x.InUnitCode == NamesOfSectionSystem.CertificateQuality)
                    .And(x => x.OutUnitCode == NamesOfSectionSystem.CreditSlipSpecification)
                    .Select(x => x.OutDocument)
                    .Future<long>();

            var creditSlipSpecs =
                _repositoryCreditSlipSpecs.Specify()
                    .IsInEmpty(x => x.Rn, rnDoclinks.ToArray())
                    .Future<CreditSlipSpecification>();

            creditSlipSpecs.DoForEach(
                creditSlipSpec => creditSlipSpec.CreditSlip.CreditSlipSpecifications.Remove(creditSlipSpec));

            var creditSlips = creditSlipSpecs.Select(x => x.CreditSlip);
            creditSlips.DoForEach(
                creditSlip =>
                {
                    if (creditSlip.CreditSlipSpecifications.Any())
                    {
                        _repositoryCreditSlip.Update(creditSlip);
                    }
                    else
                    {
                        _repositoryCreditSlip.Delete(creditSlip);
                    }
                });
        }

        public void FlushRemove()
        {
            Remove();
        }
        public void FlushCreate()
        {
            Create();
        }
        public void Flush()
        {
            FlushCreate();
            FlushRemove();
            Clean();
        }
    }
}
