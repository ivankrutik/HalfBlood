// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrudAll.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CertificateQualityCrud type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.CrudTest
{
    using System;

    using DataAccessLogic.Infrastructure;

    using Halfblood.Common;
    using Halfblood.UnitTests.BuisnesWorkflow.Tests;

    using NHibernate;

    using NUnit.Framework;

    using ParusModel.Entities;
    using ParusModel.Entities.ArrivalFromSubdivisionDomain;
    using ParusModel.Entities.AttachedDocumentDomain;
    using ParusModel.Entities.CertificateQualityDomain;
    using ParusModel.Entities.CertificateQualityDomain.ActInputControlDomain;
    using ParusModel.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;
    using ParusModel.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModel.Entities.CertificateQualityDomain.WarehouseQualityCertificateDomain;
    using ParusModel.Entities.Common;
    using ParusModel.Entities.CreditSlipDomain;
    using ParusModel.Entities.CuttingOrderDomain;
    using ParusModel.Entities.DepartmentOrderDomain;
    using ParusModel.Entities.ExpenditureInvoiceDomain;
    using ParusModel.Entities.GoodsSupplyDomain;
    using ParusModel.Entities.PermissionMaterialDomain;
    using ParusModel.Entities.PlanReceiptOrderDomain;
    using ParusModel.Entities.TestSheetDomain;

    using UnitTestHelpers.CrudHelpers;

    public class Initializer : IInitializerTestData
    {
        public void Create(ISession session)
        {
            TestData.Create(session);
        }

        public void Dispose(ISession session)
        {
        }
    }

    public abstract class CrudFixtureEx<TEntity> : CrudFixture<TEntity, long>
        where TEntity : class, IHasUid<long>
    {
        static CrudFixtureEx()
        {
            InitializerTestData = new Initializer();
        }
    }

    public class CertificateQualityCrud : CrudFixtureEx<CertificateQuality>
    {
        protected override CertificateQuality BuildEntity()
        {
            return SampleEntity.CreateCertificateQuality();
        }

        protected override void ModifyEntity(CertificateQuality entity)
        {
            entity.Note = "ALALALAA";
        }

        protected override void AssertAreEqual(CertificateQuality expectedEntity, CertificateQuality actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(CertificateQuality entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class DictionaryPassCrud : CrudFixtureEx<DictionaryPass>
    {
        public DictionaryPassCrud()
        {
            IsReadOnly = true;
        }

        protected override DictionaryPass BuildEntity()
        {
            throw new NotImplementedException();
        }

        protected override void ModifyEntity(DictionaryPass entity)
        {
        }

        protected override void AssertAreEqual(DictionaryPass expectedEntity, DictionaryPass actualEntity)
        {
        }

        protected override void AssertValidId(DictionaryPass entity)
        {
        }
    }

    public class PassCrud : CrudFixtureEx<Pass>
    {
        protected override Pass BuildEntity()
        {
            return SampleEntity.CreatePass(Session);
        }

        protected override void ModifyEntity(Pass entity)
        {
            entity.Note = "asdasdasdasd";
        }

        protected override void AssertAreEqual(Pass expectedEntity, Pass actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(Pass entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class SolutionByNoteCrud : CrudFixtureEx<SolutionByNote>
    {
        protected override SolutionByNote BuildEntity()
        {
            return SampleEntity.CreateSolutionByNote(Session);
        }

        protected override void ModifyEntity(SolutionByNote entity)
        {
            entity.Note = "asdasdasd";
        }

        protected override void AssertAreEqual(SolutionByNote expectedEntity, SolutionByNote actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(SolutionByNote entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class ActInputControlCrud : CrudFixtureEx<ActInputControl>
    {
        protected override ActInputControl BuildEntity()
        {
            return SampleEntity.CreateActInputControl(Session);
        }

        protected override void ModifyEntity(ActInputControl entity)
        {
            entity.Note = "new note!!!!";
        }

        protected override void AssertAreEqual(ActInputControl expectedEntity, ActInputControl actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(ActInputControl entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class ActInputControlTechnicalStateCrud : CrudFixtureEx<ActInputControlTechnicalState>
    {
        protected override ActInputControlTechnicalState BuildEntity()
        {
            return SampleEntity.CreateActInputControlTechnicalState(Session);
        }

        protected override void ModifyEntity(ActInputControlTechnicalState entity)
        {
            entity.Note = "new note!!!!";
        }

        protected override void AssertAreEqual(ActInputControlTechnicalState expectedEntity, ActInputControlTechnicalState actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(ActInputControlTechnicalState entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class ApplySolutionByRemarkCrud : CrudFixtureEx<ApplySolutionByRemark>
    {
        protected override ApplySolutionByRemark BuildEntity()
        {
            return SampleEntity.CreateApplySolutionByRemark(Session);
        }

        protected override void ModifyEntity(ApplySolutionByRemark entity)
        {
            entity.SolutionByNote = SampleEntity.CreateSolutionByNote(Session);
        }

        protected override void AssertAreEqual(ApplySolutionByRemark expectedEntity, ApplySolutionByRemark actualEntity)
        {
            Assert.AreEqual(expectedEntity.SolutionByNote.Rn, actualEntity.SolutionByNote.Rn);
        }

        protected override void AssertValidId(ApplySolutionByRemark entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class TheMoveActCrud : CrudFixtureEx<TheMoveAct>
    {
        protected override TheMoveAct BuildEntity()
        {
            return SampleEntity.CreateTheMoveAct(Session);
        }

        protected override void ModifyEntity(TheMoveAct entity)
        {
            entity.UserCreator = SampleEntity.GetUserMaratoss();
        }

        protected override void AssertAreEqual(TheMoveAct expectedEntity, TheMoveAct actualEntity)
        {
            Assert.AreEqual(expectedEntity.UserCreator.Rn, actualEntity.UserCreator.Rn);
        }

        protected override void AssertValidId(TheMoveAct entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class ConclusionEssentialCrud : CrudFixtureEx<ConclusionEssential>
    {
        protected override ConclusionEssential BuildEntity()
        {
            return SampleEntity.CreateConclusionEssential(Session);
        }

        protected override void ModifyEntity(ConclusionEssential entity)
        {
            Conclusion conclusion = SampleEntity.CreateConclusion(Session);
            Session.Save(conclusion);
            Session.Evict(conclusion);

            entity.Conclusion = conclusion;
        }

        protected override void AssertAreEqual(ConclusionEssential expectedEntity, ConclusionEssential actualEntity)
        {
            Assert.AreEqual(expectedEntity.Conclusion.Rn, actualEntity.Conclusion.Rn);
        }

        protected override void AssertValidId(ConclusionEssential entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class ConclusionCrud : CrudFixtureEx<Conclusion>
    {
        protected override Conclusion BuildEntity()
        {
            return SampleEntity.CreateConclusion(Session);
        }

        protected override void ModifyEntity(Conclusion entity)
        {
            entity.Note = "asdasdasd";
        }

        protected override void AssertAreEqual(Conclusion expectedEntity, Conclusion actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(Conclusion entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class DestinationCrud : CrudFixtureEx<Destination>
    {
        protected override Destination BuildEntity()
        {
            return SampleEntity.CreateDestination(Session);
        }

        protected override void ModifyEntity(Destination entity)
        {
            entity.Note = "new note!!!!!!!";
        }

        protected override void AssertAreEqual(Destination expectedEntity, Destination actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(Destination entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class QualityStateControlOfTheMakeCrud : CrudFixtureEx<QualityStateControlOfTheMake>
    {
        protected override QualityStateControlOfTheMake BuildEntity()
        {
            return SampleEntity.CreateQualityStateControlOfTheMake(Session);
        }

        protected override void ModifyEntity(QualityStateControlOfTheMake entity)
        {
            entity.Note = "new note!!!!!!!";
        }

        protected override void AssertAreEqual(QualityStateControlOfTheMake expectedEntity, QualityStateControlOfTheMake actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(QualityStateControlOfTheMake entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class QualityStateControlOfTheMakeSignatureCrud : CrudFixtureEx<QualityStateControlOfTheMakeSignature>
    {
        protected override QualityStateControlOfTheMakeSignature BuildEntity()
        {
            return SampleEntity.CreateQualityStateControlOfTheMakeSignature(Session);
        }

        protected override void ModifyEntity(QualityStateControlOfTheMakeSignature entity)
        {
            entity.Department = SampleEntity.CreateStaffingDivision();
        }

        protected override void AssertAreEqual(QualityStateControlOfTheMakeSignature expectedEntity, QualityStateControlOfTheMakeSignature actualEntity)
        {
            Assert.AreEqual(expectedEntity.Department, actualEntity.Department);
        }

        protected override void AssertValidId(QualityStateControlOfTheMakeSignature entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class PlanReceiptOrderCrud : CrudFixtureEx<PlanReceiptOrder>
    {
        protected override PlanReceiptOrder BuildEntity()
        {
            return SampleEntity.CreatePlanReceiptOrder();
        }

        protected override void ModifyEntity(PlanReceiptOrder entity)
        {
            entity.Note = "asdasdasd";
        }

        protected override void AssertAreEqual(PlanReceiptOrder expectedEntity, PlanReceiptOrder actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(PlanReceiptOrder entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class ActInputControlFunctioningCrud : CrudFixtureEx<ActInputControlFunctioning>
    {
        protected override ActInputControlFunctioning BuildEntity()
        {
            return SampleEntity.CreateActInputControlFunctioning(Session);
        }

        protected override void ModifyEntity(ActInputControlFunctioning entity)
        {
            entity.Note = "asdasd";
        }

        protected override void AssertAreEqual(ActInputControlFunctioning expectedEntity, ActInputControlFunctioning actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(ActInputControlFunctioning entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class ActinputControlFunctioningSignatureCrud : CrudFixtureEx<ActInputControlFunctioningSignature>
    {
        protected override ActInputControlFunctioningSignature BuildEntity()
        {
            return SampleEntity.CreateActInputControlFunctioningSignature(Session);
        }

        protected override void ModifyEntity(ActInputControlFunctioningSignature entity)
        {
            ActInputControlFunctioning actInputControlFunctioning = SampleEntity.CreateActInputControlFunctioning(Session);
            actInputControlFunctioning.Rn = (long)Session.Save(SampleEntity.CreateActInputControlFunctioning(Session));

            entity.ActInputControlFunctioning = actInputControlFunctioning;
        }

        protected override void AssertAreEqual(ActInputControlFunctioningSignature expectedEntity, ActInputControlFunctioningSignature actualEntity)
        {
            Assert.AreEqual(expectedEntity.ActInputControlFunctioning.Rn, actualEntity.ActInputControlFunctioning.Rn);
        }

        protected override void AssertValidId(ActInputControlFunctioningSignature entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class TechnicalStateEssentialCrud : CrudFixtureEx<TechnicalStateEssential>
    {
        protected override TechnicalStateEssential BuildEntity()
        {
            return SampleEntity.CreateTechnicalStateEssential(Session);
        }

        protected override void ModifyEntity(TechnicalStateEssential entity)
        {
            entity.User = SampleEntity.GetUserMaratoss();
        }

        protected override void AssertAreEqual(TechnicalStateEssential expectedEntity, TechnicalStateEssential actualEntity)
        {
            Assert.AreEqual(expectedEntity.User.Rn, actualEntity.User.Rn);
        }

        protected override void AssertValidId(TechnicalStateEssential entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class SampleCrud : CrudFixtureEx<Sample>
    {
        protected override Sample BuildEntity()
        {
            return SampleEntity.CreateSample(Session);
        }

        protected override void ModifyEntity(Sample entity)
        {
            entity.Note = "df";
        }

        protected override void AssertAreEqual(Sample expectedEntity, Sample actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(Sample entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class PlanCertificateCrud : CrudFixtureEx<PlanCertificate>
    {
        protected override PlanCertificate BuildEntity()
        {
            return SampleEntity.CreatePlanCertificate(Session);
        }

        protected override void ModifyEntity(PlanCertificate entity)
        {
            entity.Price = 2;
        }

        protected override void AssertAreEqual(PlanCertificate expectedEntity, PlanCertificate actualEntity)
        {
            Assert.AreEqual(expectedEntity.Price, actualEntity.Price);
        }

        protected override void AssertValidId(PlanCertificate entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class PlanReceiptOrderPersonalAccountCrud : CrudFixtureEx<PlanReceiptOrderPersonalAccount>
    {
        protected override PlanReceiptOrderPersonalAccount BuildEntity()
        {
            return SampleEntity.CreatePlanReceiptOrderPersonalAccountDto(Session);
        }

        protected override void ModifyEntity(PlanReceiptOrderPersonalAccount entity)
        {
            entity.Note = "2";
        }

        protected override void AssertAreEqual(PlanReceiptOrderPersonalAccount expectedEntity, PlanReceiptOrderPersonalAccount actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(PlanReceiptOrderPersonalAccount entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class FileLinksCrud : CrudFixtureEx<AttachedDocument>
    {
        protected override AttachedDocument BuildEntity()
        {
            return SampleEntity.GetFileLinks();
        }

        protected override void ModifyEntity(AttachedDocument entity)
        {
            entity.Note = "DSd";
        }

        protected override void AssertAreEqual(AttachedDocument expectedEntity, AttachedDocument actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(AttachedDocument entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class DictionaryChemicalIndicatorCrud : CrudFixtureEx<DictionaryChemicalIndicator>
    {
        public DictionaryChemicalIndicatorCrud()
        {
            IsReadOnly = true;
        }

        protected override DictionaryChemicalIndicator BuildEntity()
        {
            throw new NotImplementedException();
        }

        protected override void ModifyEntity(DictionaryChemicalIndicator entity)
        {
            throw new NotImplementedException();
        }

        protected override void AssertAreEqual(DictionaryChemicalIndicator expectedEntity, DictionaryChemicalIndicator actualEntity)
        {
            throw new NotImplementedException();
        }

        protected override void AssertValidId(DictionaryChemicalIndicator entity)
        {
            throw new NotImplementedException();
        }
    }

    public class DictionaryMechanicalIndicatorCrud : CrudFixtureEx<DictionaryMechanicalIndicator>
    {
        public DictionaryMechanicalIndicatorCrud()
        {
            IsReadOnly = true;
        }

        protected override DictionaryMechanicalIndicator BuildEntity()
        {
            throw new NotImplementedException();
        }

        protected override void ModifyEntity(DictionaryMechanicalIndicator entity)
        {
            throw new NotImplementedException();
        }

        protected override void AssertAreEqual(DictionaryMechanicalIndicator expectedEntity, DictionaryMechanicalIndicator actualEntity)
        {
            throw new NotImplementedException();
        }

        protected override void AssertValidId(DictionaryMechanicalIndicator entity)
        {
            throw new NotImplementedException();
        }
    }

    public class ChemicalIndicatorValueCrud : CrudFixtureEx<ChemicalIndicatorValue>
    {
        protected override ChemicalIndicatorValue BuildEntity()
        {
            return SampleEntity.CreateChemicalIndicatorValue(Session);
        }

        protected override void ModifyEntity(ChemicalIndicatorValue entity)
        {
            entity.Value = "d";
        }

        protected override void AssertAreEqual(ChemicalIndicatorValue expectedEntity, ChemicalIndicatorValue actualEntity)
        {
            Assert.AreEqual(expectedEntity.Value, actualEntity.Value);
        }

        protected override void AssertValidId(ChemicalIndicatorValue entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class MechanicIndicatorValueCrud : CrudFixtureEx<MechanicIndicatorValue>
    {
        protected override MechanicIndicatorValue BuildEntity()
        {
            return SampleEntity.CreateMechanicIndicatorValue(Session);
        }

        protected override void ModifyEntity(MechanicIndicatorValue entity)
        {
            entity.Value = "d";
        }

        protected override void AssertAreEqual(MechanicIndicatorValue expectedEntity, MechanicIndicatorValue actualEntity)
        {
            Assert.AreEqual(expectedEntity.Value, actualEntity.Value);
        }

        protected override void AssertValidId(MechanicIndicatorValue entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class ActSelectionOfProbeCrud : CrudFixtureEx<ActSelectionOfProbe>
    {
        protected override ActSelectionOfProbe BuildEntity()
        {
            return SampleEntity.CreateQualityCertificateOfProbe();
        }

        protected override void ModifyEntity(ActSelectionOfProbe entity)
        {
            entity.Sample = "100";
        }

        protected override void AssertAreEqual(ActSelectionOfProbe expectedEntity, ActSelectionOfProbe actualEntity)
        {
            Assert.AreEqual(expectedEntity.Sample, actualEntity.Sample);
        }

        protected override void AssertValidId(ActSelectionOfProbe entity)
        {
            Assert.That(entity.Rn, Is.GreaterThan(0));
        }
    }

    public class ActSelectionOfProbeDepartmentCrud : CrudFixtureEx<ActSelectionOfProbeDepartment>
    {
        protected override ActSelectionOfProbeDepartment BuildEntity()
        {
            return SampleEntity.CreateQualityCertificateOfProbeDepartment(Session);
        }

        protected override void ModifyEntity(ActSelectionOfProbeDepartment entity)
        {
            entity.CustomerDate = new DateTime(2013, 7, 11);
        }

        protected override void AssertAreEqual(ActSelectionOfProbeDepartment expectedEntity, ActSelectionOfProbeDepartment actualEntity)
        {
            Assert.AreEqual(expectedEntity.CustomerDate, actualEntity.CustomerDate);
        }

        protected override void AssertValidId(ActSelectionOfProbeDepartment entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class PermissionMaterialCrud : CrudFixtureEx<PermissionMaterial>
    {
        protected override PermissionMaterial BuildEntity()
        {
            return SampleEntity.CreatePermissionMaterial(Session);
        }

        protected override void ModifyEntity(PermissionMaterial entity)
        {
            entity.Note = "Sda";
        }

        protected override void AssertAreEqual(PermissionMaterial expectedEntity, PermissionMaterial actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(PermissionMaterial entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class PermissionMaterialExtensionCrud : CrudFixtureEx<PermissionMaterialExtension>
    {
        protected override PermissionMaterialExtension BuildEntity()
        {
            return SampleEntity.CreatePermissionMaterialExtension(Session);
        }

        protected override void ModifyEntity(PermissionMaterialExtension entity)
        {
            entity.AcceptToDate = new DateTime(2013, 02, 02);
        }

        protected override void AssertAreEqual(PermissionMaterialExtension expectedEntity, PermissionMaterialExtension actualEntity)
        {
            Assert.AreEqual(expectedEntity.AcceptToDate, actualEntity.AcceptToDate);
        }

        protected override void AssertValidId(PermissionMaterialExtension entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class CuttingOrderCrud : CrudFixtureEx<CuttingOrder>
    {
        protected override CuttingOrder BuildEntity()
        {
            return SampleEntity.CreateCuttingOrder(this.Session);
        }

        protected override void ModifyEntity(CuttingOrder entity)
        {
            entity.Pref = "preff1";
        }

        protected override void AssertAreEqual(CuttingOrder expectedEntity, CuttingOrder actualEntity)
        {
            Assert.AreEqual(expectedEntity.Pref, actualEntity.Pref);
        }

        protected override void AssertValidId(CuttingOrder entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class CuttingOrderMoveCrud : CrudFixtureEx<CuttingOrderMove>
    {
        protected override CuttingOrderMove BuildEntity()
        {
            return SampleEntity.CreateCuttingOrderMove(this.Session);
        }

        protected override void ModifyEntity(CuttingOrderMove entity)
        {
            entity.Note = "2";
        }

        protected override void AssertAreEqual(CuttingOrderMove expectedEntity, CuttingOrderMove actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(CuttingOrderMove entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class CuttingOrderSpecificationCrud : CrudFixtureEx<CuttingOrderSpecification>
    {
        protected override CuttingOrderSpecification BuildEntity()
        {
            return SampleEntity.CreateCuttingOrderSpecification(this.Session);
        }

        protected override void ModifyEntity(CuttingOrderSpecification entity)
        {
            entity.State = CuttingOrderSpecificationState.FirstState;
        }

        protected override void AssertAreEqual(CuttingOrderSpecification expectedEntity, CuttingOrderSpecification actualEntity)
        {
            Assert.AreEqual(expectedEntity.State, actualEntity.State);
        }

        protected override void AssertValidId(CuttingOrderSpecification entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class SampleCertificationCrud : CrudFixtureEx<SampleCertification>
    {
        protected override SampleCertification BuildEntity()
        {
            return SampleEntity.CreateSampleCertification(this.Session);
        }

        protected override void ModifyEntity(SampleCertification entity)
        {
            entity.TransInvDeptSpecs = 254134273;
        }

        protected override void AssertAreEqual(SampleCertification expectedEntity, SampleCertification actualEntity)
        {
            Assert.AreEqual(expectedEntity.TransInvDeptSpecs, actualEntity.TransInvDeptSpecs);
        }

        protected override void AssertValidId(SampleCertification entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class CertificationCrud : CrudFixtureEx<Certification>
    {
        protected override Certification BuildEntity()
        {
            return SampleEntity.CreateCertification(this.Session);
        }

        protected override void ModifyEntity(Certification entity)
        {
            entity.TransInvDeptSpecs = 254134273;
        }

        protected override void AssertAreEqual(Certification expectedEntity, Certification actualEntity)
        {
            Assert.AreEqual(expectedEntity.TransInvDeptSpecs, actualEntity.TransInvDeptSpecs);
        }

        protected override void AssertValidId(Certification entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class DepartmentOrderCrud : CrudFixture<DepartmentOrder, long>
    {
        protected override DepartmentOrder BuildEntity()
        {
            return SampleEntity.CreateDepartmentOrder();
        }

        protected override void ModifyEntity(DepartmentOrder entity)
        {
            entity.Priority = 2;
        }

        protected override void AssertAreEqual(DepartmentOrder expectedEntity, DepartmentOrder actualEntity)
        {
            Assert.AreEqual(expectedEntity.Priority, actualEntity.Priority);
        }

        protected override void AssertValidId(DepartmentOrder entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class DepartmentOrderSpecificationCrud : CrudFixture<DepartmentOrderSpecification, long>
    {
        protected override DepartmentOrderSpecification BuildEntity()
        {
            return SampleEntity.CreateDepartmentOrderSpecifacation(this.Session);
        }

        protected override void ModifyEntity(DepartmentOrderSpecification entity)
        {
            entity.Quantity = 3;
        }

        protected override void AssertAreEqual(DepartmentOrderSpecification expectedEntity, DepartmentOrderSpecification actualEntity)
        {
            Assert.AreEqual(expectedEntity.Quantity, actualEntity.Quantity);
        }

        protected override void AssertValidId(DepartmentOrderSpecification entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class DepartmentOrderCommentCrud : CrudFixture<DepartmentOrderComment, long>
    {
        protected override DepartmentOrderComment BuildEntity()
        {
            return SampleEntity.CreateDepartmentOrderComment(this.Session);
        }

        protected override void ModifyEntity(DepartmentOrderComment entity)
        {
            entity.Comment = "3";
        }

        protected override void AssertAreEqual(DepartmentOrderComment expectedEntity, DepartmentOrderComment actualEntity)
        {
            Assert.AreEqual(expectedEntity.Comment, actualEntity.Comment);
        }

        protected override void AssertValidId(DepartmentOrderComment entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class TestSheetCrud : CrudFixtureEx<TestSheet>
    {
        protected override TestSheet BuildEntity()
        {
            return SampleEntity.CreateTestSheet();
        }

        protected override void ModifyEntity(TestSheet entity)
        {
            entity.Note = "ляляля";
            entity.StateDate = new DateTime(2013, 2, 2);
            entity.Number = 5;
            entity.OtkEmployee = SampleEntity.GetUserMaratoss();
            entity.VpEmployee = SampleEntity.GetUserMaratoss();
        }

        protected override void AssertAreEqual(TestSheet expectedEntity, TestSheet actualEntity)
        {
            Assert.AreEqual(expectedEntity.Number, actualEntity.Number);
        }

        protected override void AssertValidId(TestSheet entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class TestResultCrud : CrudFixtureEx<TestResult>
    {
        protected override TestResult BuildEntity()
        {
            return SampleEntity.CreateTestResult(this.Session);
        }

        protected override void ModifyEntity(TestResult entity)
        {
          //  entity.AnalysesRange = "123-456";
            entity.TestingMethod = "Тестовый2";
            entity.Requirements = "Самые необходимые";
            entity.Equipment = "Самое лучшее";
            entity.Value = "Чуть-чуть";
            entity.Note = "Тестик";
            entity.IndicatorName = "Гибкость";
            entity.Unit = "м";
            entity.CreationDate = new DateTime(2013, 2, 8);
            entity.Creator = SampleEntity.GetUserMaratoss();
        }

        protected override void AssertAreEqual(TestResult expectedEntity, TestResult actualEntity)
        {
            Assert.AreEqual(expectedEntity.Value, actualEntity.Value);
        }

        protected override void AssertValidId(TestResult entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class HeatTreatmentCrud : CrudFixtureEx<HeatTreatment>
    {
        protected override HeatTreatment BuildEntity()
        {
            return SampleEntity.CreateHeatTreatment(this.Session);
        }

        protected override void ModifyEntity(HeatTreatment entity)
        {
            entity.Operation = "ляляля";
            entity.PutTemperature = 30;
            entity.SetTemperature = 40;
            entity.HeatingTime = 5;
            entity.HoldingTime = 9;
            entity.Ambience = "Снег";
            entity.AmbientTemperature = 99;
        }

        protected override void AssertAreEqual(HeatTreatment expectedEntity, HeatTreatment actualEntity)
        {
            Assert.AreEqual(expectedEntity.PutTemperature, actualEntity.PutTemperature);
        }

        protected override void AssertValidId(HeatTreatment entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class SampleResultSetCrud : CrudFixtureEx<SampleResultSet>
    {
        protected override SampleResultSet BuildEntity()
        {
            return SampleEntity.CreateSampleResultSet(this.Session);
        }

        protected override void ModifyEntity(SampleResultSet entity)
        {
            entity.Title = "Тесты 2";
            entity.Value1 = "АА1";
            entity.Value2 = "АА2";
            entity.Value3 = "АА3";
            entity.Value4 = "АА4";
            entity.Value5 = "АА5";
            entity.Value6 = "АА6";
            entity.Value7 = "АА7";
            entity.Value8 = "АА8";
            entity.Value9 = "АА9";
            entity.Value9 = "АА10";
        }

        protected override void AssertAreEqual(SampleResultSet expectedEntity, SampleResultSet actualEntity)
        {
            Assert.AreEqual(expectedEntity.Value1, actualEntity.Value1);
        }

        protected override void AssertValidId(SampleResultSet entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class WarehouseQualityCertificateSetCrud : CrudFixtureEx<WarehouseQualityCertificate>
    {
        protected override WarehouseQualityCertificate BuildEntity()
        {
            return SampleEntity.CreateWarehouseQualityCertificate(this.Session);
        }

        protected override void ModifyEntity(WarehouseQualityCertificate entity)
        {
            entity.Note = "Тесты 2";

        }

        protected override void AssertAreEqual(WarehouseQualityCertificate expectedEntity, WarehouseQualityCertificate actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(WarehouseQualityCertificate entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class ExpenditureInvoiceCrud : CrudFixtureEx<ExpenditureInvoice>
    {
        protected override ExpenditureInvoice BuildEntity()
        {
            return SampleEntity.CreateExpenditureInvoice();
        }

        protected override void ModifyEntity(ExpenditureInvoice entity)
        {
            entity.Docdate = new DateTime(2013, 1, 1);

        }

        protected override void AssertAreEqual(ExpenditureInvoice expectedEntity, ExpenditureInvoice actualEntity)
        {
            Assert.AreEqual(expectedEntity.Comment, actualEntity.Comment);
        }

        protected override void AssertValidId(ExpenditureInvoice entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class ExpenditureInvoiceSpecificationCrud : CrudFixtureEx<ExpenditureInvoiceSpecification>
    {
        protected override ExpenditureInvoiceSpecification BuildEntity()
        {
            return SampleEntity.CreateExpenditureInvoiceSpecification(this.Session);
        }

        protected override void ModifyEntity(ExpenditureInvoiceSpecification entity)
        {
            entity.Note = "Тест2";
        }

        protected override void AssertAreEqual(ExpenditureInvoiceSpecification expectedEntity, ExpenditureInvoiceSpecification actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }

        protected override void AssertValidId(ExpenditureInvoiceSpecification entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class CreditSlipCrud : CrudFixtureEx<CreditSlip>
    {
        protected override CreditSlip BuildEntity()
        {
            return SampleEntity.CreateCreditSlip();
        }
        protected override void ModifyEntity(CreditSlip entity)
        {
            entity.Comment = "Тест1";
        }
        protected override void AssertAreEqual(CreditSlip expectedEntity, CreditSlip actualEntity)
        {
            Assert.AreEqual(expectedEntity.Comment, actualEntity.Comment);
        }
        protected override void AssertValidId(CreditSlip entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class CreditSlipSpecificationCrud : CrudFixtureEx<CreditSlipSpecification>
    {
        protected override CreditSlipSpecification BuildEntity()
        {
            return SampleEntity.CreateCreditSlipSpecification(null, Session);
        }
        protected override void ModifyEntity(CreditSlipSpecification entity)
        {
            entity.Note = "Тест1";
        }
        protected override void AssertAreEqual(CreditSlipSpecification expectedEntity, CreditSlipSpecification actualEntity)
        {
            Assert.AreEqual(expectedEntity.Note, actualEntity.Note);
        }
        protected override void AssertValidId(CreditSlipSpecification entity)
        {
            Assert.That(entity.Rn > 0);
        }
    }

    public class GoodsSupplyCrud : CrudFixtureEx<GoodsSupply>
    {
        public GoodsSupplyCrud()
        {
            IsReadOnly = true;
        }

        protected override GoodsSupply BuildEntity()
        {
            throw new NotImplementedException();
        }

        protected override void ModifyEntity(GoodsSupply entity)
        {
            throw new NotImplementedException();
        }

        protected override void AssertAreEqual(GoodsSupply expectedEntity, GoodsSupply actualEntity)
        {
            throw new NotImplementedException();
        }

        protected override void AssertValidId(GoodsSupply entity)
        {
            throw new NotImplementedException();
        }
    }

    public class ArrivalFromSubdivisionCrud : CrudFixtureEx<ArrivalFromSubdivision>
    {
        protected override ArrivalFromSubdivision BuildEntity()
        {
            var entity = SampleEntity.CreateArrivalFromSubdivision(Session);
            return entity;
        }

        protected override void ModifyEntity(ArrivalFromSubdivision entity)
        {
            entity.CURBASECOURS = 777;
            entity.Agnlist_AGENT = SampleEntity.GetUserMaratoss();
        }

        protected override void AssertAreEqual(ArrivalFromSubdivision expectedEntity, ArrivalFromSubdivision actualEntity)
        {
            Assert.That(expectedEntity.CURBASECOURS, Is.EqualTo(actualEntity.CURBASECOURS));
            Assert.That(expectedEntity.Agnlist_AGENT.Rn, Is.EqualTo(actualEntity.Agnlist_AGENT.Rn));
        }

        protected override void AssertValidId(ArrivalFromSubdivision entity)
        {
            Assert.IsTrue(entity.Rn > 0);
        }
    }

    public class ArrivalFromSubdivisionSpecificationCrud : CrudFixtureEx<ArrivalFromSubdivisionSpecification>
    {
        protected override ArrivalFromSubdivisionSpecification BuildEntity()
        {
            var entity = SampleEntity.CreateArrivalFromSubdivisionSpecification(Session);
            return entity;
        }
        protected override void ModifyEntity(ArrivalFromSubdivisionSpecification entity)
        {
            entity.NOTE = "ASDASDASD";
        }
        protected override void AssertAreEqual(
            ArrivalFromSubdivisionSpecification expectedEntity,
            ArrivalFromSubdivisionSpecification actualEntity)
        {
            Assert.That(expectedEntity.NOTE, Is.EqualTo(actualEntity.NOTE));
        }
        protected override void AssertValidId(ArrivalFromSubdivisionSpecification entity)
        {
            Assert.IsTrue(entity.Rn > 0);
        }
    }

    public class BatchCrud : CrudFixtureEx<Batch>
    {
        protected override Batch BuildEntity()
        {
            var batch = SampleEntity.CreateBatch();
            return batch;
        }

        protected override void ModifyEntity(Batch entity)
        {
            entity.Code = "NEW CODE!!!";
        }

        protected override void AssertAreEqual(Batch expectedEntity, Batch actualEntity)
        {
            Assert.That(expectedEntity.Code, Is.EqualTo(actualEntity.Code));
        }

        protected override void AssertValidId(Batch entity)
        {
            Assert.IsTrue(entity.Rn > 0);
        }
    }

    public class RelationshipBetweenDocumentsCrud : CrudFixtureEx<RelationshipBetweenDocuments>
    {
        protected override RelationshipBetweenDocuments BuildEntity()
        {
            var doclinks = new RelationshipBetweenDocuments
            {
                InUnitCode = "GoodsTransInvoicesToDepts",
                OutUnitCode = "OrderByInvoice",
            };

            return doclinks;
        }

        protected override void ModifyEntity(RelationshipBetweenDocuments entity)
        {
            throw new NotImplementedException();
        }

        protected override void AssertAreEqual(RelationshipBetweenDocuments expectedEntity, RelationshipBetweenDocuments actualEntity)
        {
            throw new NotImplementedException();
        }

        protected override void AssertValidId(RelationshipBetweenDocuments entity)
        {
            Assert.IsTrue(entity.Rn > 0);
        }
    }

    public class SettingsCrud : CrudFixtureEx<Settings>
    {
        protected override Settings BuildEntity()
        {
            return new Settings
            {
                Application = "Halfblood",
                SettingsInJson = "json",
                User = "140MUHAMADIEV",
                Catalog = new Catalog(1008335823)
            };
        }

        protected override void ModifyEntity(Settings entity)
        {
            entity.SettingsInJson = "json2";
        }

        protected override void AssertAreEqual(Settings expectedEntity, Settings actualEntity)
        {
            Assert.IsTrue(expectedEntity.SettingsInJson == actualEntity.SettingsInJson);
        }

        protected override void AssertValidId(Settings entity)
        {
            Assert.IsTrue(entity.Rn > 0);
        }
    }
}