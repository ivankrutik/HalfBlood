// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestData.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the TestData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;

    using DataAccessLogic.Infrastructure;

    using FizzWare.NBuilder;

    using Halfblood.Common;
    using Halfblood.UnitTests.BuisnesWorkflow.Tests;
    using Halfblood.UnitTests.Extension;

    using NHibernate;

    using ParusModel.Entities.CertificateQualityDomain;
    using ParusModel.Entities.CertificateQualityDomain.ActInputControlDomain;
    using ParusModel.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;
    using ParusModel.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModel.Entities.ExpenditureInvoiceDomain;
    using ParusModel.Entities.PlanReceiptOrderDomain;

    public static class TestData
    {
        private static void ClearDB(ISession session)
        {
            TestExtension.CleanUpTable<PlanReceiptOrderPersonalAccount>(session.SessionFactory);
            TestExtension.CleanUpTable<PlanCertificate>(session.SessionFactory);
            TestExtension.CleanUpTable<Destination>(session.SessionFactory);
            TestExtension.CleanUpTable<Pass>(session.SessionFactory);
            TestExtension.CleanUpTable<CertificateQuality>(session.SessionFactory);
            TestExtension.CleanUpTable<PlanReceiptOrder>(session.SessionFactory);
            TestExtension.CleanUpTable<ChemicalIndicatorValue>(session.SessionFactory);
            TestExtension.CleanUpTable<MechanicIndicatorValue>(session.SessionFactory);
            TestExtension.CleanUpTable<DictionaryChemicalIndicator>(session.SessionFactory);
            TestExtension.CleanUpTable<DictionaryMechanicalIndicator>(session.SessionFactory);
            TestExtension.CleanUpTable<DictionaryPass>(session.SessionFactory);
        }

        public static void Create(ISession session)
        {
            ClearDB(session);

            var dictionaryPass = Builder<DictionaryPass>.CreateNew()
                    .With(x => x.Rn = 0)
                    .With(x => x.Catalog = new Catalog(1007315958))
                    .With(x => x.UserCreator = SampleEntity.GetUserMaratoss())
                .Do(x => session.Save(x))
                .Build();

            var DictionaryChemicalIndicator = Builder<DictionaryChemicalIndicator>.CreateNew()
                  .With(x => x.Rn = 0)
                  .With(x => x.Catalog = new Catalog(1007856817))
                  .With(x => x.Code = "1")
                  .With(x => x.Name = "2")
              .Do(x => session.Save(x))
              .Build();

            var DictionaryMechanicalIndicator = Builder<DictionaryMechanicalIndicator>.CreateNew()
                  .With(x => x.Rn = 0)
                  .With(x => x.Catalog = new Catalog(1007857018))
                  .With(x => x.Code = "1")
                  .With(x => x.Name = "2")
              .Do(x => session.Save(x))
              .Build();


            var actsInputControlFunctioning = Builder<ActInputControlFunctioning>.CreateListOfSize(10)
                    .All()
                        .With(x => x.Rn = 0)
                        .With(x => x.Company = SampleEntity.GetCompany())
                        .With(x => x.Contractor = SampleEntity.GetUserMaratoss())
                    .Build();

            var technicalStatesEssential = Builder<TechnicalStateEssential>.CreateListOfSize(10)
                .All()
                    .With(x => x.Rn = 0)
                    .With(x => x.Company = SampleEntity.GetCompany())
                    .With(x => x.Department = SampleEntity.CreateStaffingDivision())
                .Build();

            var actsInputControlTechnicalState = Builder<ActInputControlTechnicalState>.CreateListOfSize(10)
                .All()
                    .With(x => x.Rn = 0)
                    .With(x => x.Company = SampleEntity.GetCompany())
                .Build();

            foreach (var item in actsInputControlTechnicalState)
            {
                var conEss = technicalStatesEssential.First(x => x.ActInputControlTechnicalState == null);
                conEss.ActInputControlTechnicalState = item;
                item.TechnicalStateEssentials = new List<TechnicalStateEssential>() { conEss };
            }

            var conclusionsEssential = Builder<ConclusionEssential>.CreateListOfSize(10)
                .All()
                    .With(x => x.Rn = 0)
                    .With(x => x.Company = SampleEntity.GetCompany())
                    .With(x => x.User = SampleEntity.GetUserMaratoss())
                    .With(x => x.Department = SampleEntity.CreateStaffingDivision())
                .Build();

            var conclusions = Builder<Conclusion>.CreateListOfSize(10)
                .All()
                    .With(x => x.Rn = 0)
                    .With(x => x.Company = SampleEntity.GetCompany())
                    .With(x => x.Contractor = SampleEntity.GetUserMaratoss())
                .Build();

            foreach (var item in conclusions)
            {
                var conEss = conclusionsEssential.First(x => x.Conclusion == null);
                conEss.Conclusion = item;
                item.ConclusionEssentials = new List<ConclusionEssential>() { conEss };
            }

            var qualityStatesControlOfTheMakeSignature = Builder<QualityStateControlOfTheMakeSignature>.CreateListOfSize(10)
                .All()
                    .With(x => x.Rn = 0)
                    .With(x => x.Company = SampleEntity.GetCompany())
                    .With(x => x.User = SampleEntity.GetUserMaratoss())
                    .With(x => x.Department = SampleEntity.CreateStaffingDivision())
                .Build();

            var qualityStatesControlOfTheMake = Builder<QualityStateControlOfTheMake>.CreateListOfSize(10)
                .All()
                    .With(x => x.Rn = 0)
                    .With(x => x.Company = SampleEntity.GetCompany())
                    .With(x => x.Contractor = SampleEntity.GetUserMaratoss())
                .Build();

            foreach (var item in qualityStatesControlOfTheMake)
            {
                var conEss = qualityStatesControlOfTheMakeSignature.First(x => x.QualityStateControlOfTheMake == null);
                conEss.QualityStateControlOfTheMake = item;
                item.QualityStateControlOfTheMakeSignatures = new List<QualityStateControlOfTheMakeSignature> { conEss };
            }

            var solutionByNotes = Builder<SolutionByNote>.CreateListOfSize(10)
                .All()
                    .With(x => x.Rn = 0)
                    .With(x => x.Company = SampleEntity.GetCompany())
                    .With(x => x.Contractor = SampleEntity.GetUserMaratoss())
                .Build();

            var theMoveActs = Builder<TheMoveAct>.CreateListOfSize(10)
                .All()
                    .With(x => x.Rn = 0)
                    .With(x => x.Company = SampleEntity.GetCompany())
                    .With(x => x.UserCreator = SampleEntity.GetUserMaratoss())
                    .With(x => x.UserReciver = SampleEntity.GetUserMaratoss())
                    .With(x => x.DepartmentCreator = SampleEntity.CreateStaffingDivision())
                    .With(x => x.DepartmentReciver = SampleEntity.CreateStaffingDivision())
                .Build();

            var actsInputControl = Builder<ActInputControl>
                .CreateListOfSize(10)
                .All()
                    .With(x => x.Rn = 0)
                    .With(x => x.Catalog = new Catalog(1007364847))
                    .With(x => x.Company = SampleEntity.GetCompany())
                    .With(x => x.ManagerStoreAct = SampleEntity.GetUserMaratoss())
                    .With(x => x.ManagerStoreTare = SampleEntity.GetUserMaratoss())
                    .With(x => x.ControlerTare = SampleEntity.GetUserMaratoss())
                .TheFirst(2)
                    .With(x => x.ActInputControlFunctionings = actsInputControlFunctioning.Take(2).ToList())
                    .With(x => x.TheMoveActs = theMoveActs.Skip(0).Take(2).ToList())
                    .With(x => x.Conclusions = conclusions.Skip(0).Take(2).ToList())
                    .With(x => x.ActInputControlTechnicalStates = actsInputControlTechnicalState.Skip(0).Take(2).ToList())
                    .With(x => x.QualityStateControlOfTheMakes = qualityStatesControlOfTheMake.Skip(0).Take(2).ToList())
                    .With(x => x.SolutionByNotes = solutionByNotes.Take(2).ToList())
                .TheNext(2)
                    .With(x => x.ActInputControlFunctionings = actsInputControlFunctioning.Skip(2).Take(2).ToList())
                    .With(x => x.TheMoveActs = theMoveActs.Skip(2).Take(2).ToList())
                    .With(x => x.Conclusions = conclusions.Skip(2).Take(2).ToList())
                    .With(x => x.ActInputControlTechnicalStates = actsInputControlTechnicalState.Skip(2).Take(2).ToList())
                    .With(x => x.QualityStateControlOfTheMakes = qualityStatesControlOfTheMake.Skip(2).Take(2).ToList())
                    .With(x => x.SolutionByNotes = solutionByNotes.Skip(0).Take(2).ToList())
                .TheNext(2)
                    .With(x => x.ActInputControlFunctionings = actsInputControlFunctioning.Skip(4).Take(2).ToList())
                    .With(x => x.TheMoveActs = theMoveActs.Skip(4).Take(2).ToList())
                    .With(x => x.Conclusions = conclusions.Skip(4).Take(2).ToList())
                    .With(x => x.ActInputControlTechnicalStates = actsInputControlTechnicalState.Skip(4).Take(2).ToList())
                    .With(x => x.QualityStateControlOfTheMakes = qualityStatesControlOfTheMake.Skip(4).Take(2).ToList())
                    .With(x => x.SolutionByNotes = solutionByNotes.Skip(4).Take(2).ToList())
                .TheNext(2)
                    .With(x => x.ActInputControlFunctionings = actsInputControlFunctioning.Skip(6).Take(2).ToList())
                    .With(x => x.TheMoveActs = theMoveActs.Skip(6).Take(2).ToList())
                    .With(x => x.Conclusions = conclusions.Skip(6).Take(2).ToList())
                    .With(x => x.ActInputControlTechnicalStates = actsInputControlTechnicalState.Skip(6).Take(2).ToList())
                    .With(x => x.QualityStateControlOfTheMakes = qualityStatesControlOfTheMake.Skip(6).Take(2).ToList())
                    .With(x => x.SolutionByNotes = solutionByNotes.Skip(6).Take(2).ToList())
                .TheNext(2)
                    .With(x => x.ActInputControlFunctionings = actsInputControlFunctioning.Skip(8).Take(2).ToList())
                    .With(x => x.TheMoveActs = theMoveActs.Skip(8).Take(2).ToList())
                    .With(x => x.Conclusions = conclusions.Skip(8).Take(2).ToList())
                    .With(x => x.ActInputControlTechnicalStates = actsInputControlTechnicalState.Skip(8).Take(2).ToList())
                    .With(x => x.QualityStateControlOfTheMakes = qualityStatesControlOfTheMake.Skip(8).Take(2).ToList())
                    .With(x => x.SolutionByNotes = solutionByNotes.Skip(8).Take(2).ToList())
                .Build();

            foreach (ActInputControl item in actsInputControl)
            {
                foreach (var subItem in item.TheMoveActs) subItem.ActInputControl = item;
                foreach (var subItem in item.Conclusions) subItem.ActInputControl = item;
                foreach (var subItem in item.ActInputControlTechnicalStates) subItem.ActInputControl = item;
                foreach (var subItem in item.QualityStateControlOfTheMakes) subItem.ActInputControl = item;
                foreach (var subItem in item.SolutionByNotes) subItem.ActInputControl = item;
                foreach (var subItem in item.ActInputControlFunctionings) subItem.ActInputControl = item;

                session.Save(item);
            }

            IList<PlanReceiptOrder> plansReceiptOrder = GetPlasnReceiptOrder();
            foreach (PlanReceiptOrder item in plansReceiptOrder)
            {
                session.Save(item);
                foreach (PlanCertificate item1 in item.PlanCertificates)
                {
                    session.Save(item1.CertificateQuality);

                    item1.PlanReceiptOrder = item;
                    session.Save(item1);
                    foreach (PlanReceiptOrderPersonalAccount item2 in item1.PlanReceiptOrderPersonalAccounts)
                    {
                        item2.PlaneCertificate = item1;
                        session.Save(item2);
                    }
                }
            }

            ActSelectionOfProbeGenerator(session);
            GenerateExpenditureInvoices(session);
        }

        private static int i;

        internal static IList<ActSelectionOfProbeDepartmentRequirement>
            ActSelectionOfProbeDepartmentRequirementGenerator(
            ISession session,
            ActSelectionOfProbeDepartment actSelectionOfProbeDepartment)
        {
            return
                Builder<ActSelectionOfProbeDepartmentRequirement>.CreateListOfSize(10)
                    .All()
                    .Do(x => i++)
                    .With(x => x.Rn, 0)
                    .With(x => x.ActSelectionOfProbeDepartment = actSelectionOfProbeDepartment)
                    .With(x => x.Catalog, new Catalog(actSelectionOfProbeDepartment.Rn))
                    .With(x => x.Requirement, string.Format("требование  {0} ", i++))
                    .Build();
        }
        internal static IList<ActSelectionOfProbeDepartment> ActSelectionOfProbeDepartmentGenerator(ISession session, ActSelectionOfProbe actSelectionOfProbe)
        {
            var i = 2010;
            return
                Builder<ActSelectionOfProbeDepartment>.CreateListOfSize(10)
                    .All()
                    .Do(x => i++)
                    .With(x => x.Rn, 0)
                    .With(
                        x =>
                        x.ActSelectionOfProbeDepartmentRequirements =
                        ActSelectionOfProbeDepartmentRequirementGenerator(session, x))
                    .With(x => x.ActSelectionOfProbe = actSelectionOfProbe)
                    .With(x => x.Catalog, new Catalog(actSelectionOfProbe.Rn))
                    .With(x => x.AgentDepartment, SampleEntity.CreateAgnlist())
                    .With(x => x.Creator, SampleEntity.CreateAgnlist())
                    .With(x => x.Customer, SampleEntity.CreateAgnlist())
                    .Build();
        }
        internal static IList<ActSelectionOfProbe> ActSelectionOfProbeGenerator(ISession session)
        {
            return
                Builder<ActSelectionOfProbe>.CreateListOfSize(10)
                    .All()
                    .With(x => x.Rn, 0)
                    .With(
                        act => act.ActSelectionOfProbeDepartments = ActSelectionOfProbeDepartmentGenerator(session, act))
                    .With(x => x.Catalog, new Catalog(1007320164))
                    .With(x => x.Creator, SampleEntity.CreateAgnlist())
                    .With(x => x.DepartmentCreator, SampleEntity.CreateStaffingDivision())
                    .Do(x => session.Save(x))
                    .Build();
        }
        private static IList<PlanReceiptOrderPersonalAccount> GetPersonalAccounts()
        {
            return Builder<PlanReceiptOrderPersonalAccount>.CreateListOfSize(10)
                .All()
                    .With(x => x.UserCreator, SampleEntity.GetUserMaratoss())
                    .With(x => x.UserSetState, SampleEntity.GetUserMaratoss())
                    .With(x => x.PersonalAccount, SampleEntity.GetPersonalAccount())
                .Build();
        }
        private static IList<PlanCertificate> GetPlanCertificates()
        {
            return Builder<PlanCertificate>.CreateListOfSize(10)
                .All()
                    .With(x => x.UserCreator, SampleEntity.GetUserMaratoss())
                    .With(x => x.PlanReceiptOrderPersonalAccounts, GetPersonalAccounts())
                    .With(x => x.CertificateQuality, GetCertificateQualiti())
                    .Build();
        }
        private static IList<PlanReceiptOrder> GetPlasnReceiptOrder()
        {
            return Builder<PlanReceiptOrder>.CreateListOfSize(10)
                 .All()
                     .With(x => x.Company, SampleEntity.GetCompany())
                     .With(x => x.StaffingDivision, SampleEntity.CreateStaffingDivision())
                     .With(x => x.UserContractor, SampleEntity.GetUserMaratoss())
                     .With(x => x.UserCreator, SampleEntity.GetUserMaratoss())
                     .With(x => x.GroundTypeOfDocument, SampleEntity.CreateTypeOfDocument())
                     .With(x => x.GroundReceiptTypeOfDocument, SampleEntity.CreateTypeOfDocument())
                     .With(x => x.StoreGasStationOilDepot, SampleEntity.CreateStoreGasStationOilDepot())
                     .With(x => x.GroundReceiptDocumentNumb, "asd")
                     .With(x => x.Catalog, new Catalog(1007318777))
                     .With(x => x.PlanCertificates, GetPlanCertificates())
                 .Build();
        }
        private static CertificateQuality GetCertificateQualiti()
        {
            return Builder<CertificateQuality>.CreateNew()
                .With(x => x.Catalog = new Catalog(1007318670))
                .With(x => x.UserCreator, SampleEntity.CreateAgnlist())
                .With(x => x.CreatorFactory, SampleEntity.CreateAgnlist())
                .Build();
        }
        internal static IList<ExpenditureInvoiceSpecification> GenerateExpenditureInvoiceSpecifications(
            ISession session,
            ExpenditureInvoice parent)
        {
            return
                Builder<ExpenditureInvoiceSpecification>.CreateListOfSize(5)
                    .All()
                    .With(x => x.GoodsParty = SampleEntity.CreateGoodsParty())
                    .With(x => x.ExpenditureInvoice = parent)
                    .With(x => x.NomenclatureNumberModification = SampleEntity.GetNomModif())
                    .Build();
        }
        internal static IList<ExpenditureInvoice> GenerateExpenditureInvoices(ISession session)
        {
            var entity = SampleEntity.CreateExpenditureInvoice();
            entity.ExpenditureInvoiceSpecifications = GenerateExpenditureInvoiceSpecifications(session, entity);
            entity.Status = InvoiceForTransmissionInUnitState.NotWork;
            entity.InStatus = InvoiceForTransmissionInUnitInState.Not;
            session.Save(entity);
            return new List<ExpenditureInvoice> { entity };
        }
    }
}
