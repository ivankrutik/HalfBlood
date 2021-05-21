// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleEntity.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the SampleEntity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.BuisnesWorkflow.Tests
{
    using System;

    using DataAccessLogic.Infrastructure;

    using FizzWare.NBuilder;

    using Halfblood.Common;

    using NHibernate;

    using ParusModel.Entities;
    using ParusModel.Entities.ArrivalFromSubdivisionDomain;
    using ParusModel.Entities.AttachedDocumentDomain;
    using ParusModel.Entities.CertificateQualityDomain;
    using ParusModel.Entities.CertificateQualityDomain.ActInputControlDomain;
    using ParusModel.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;
    using ParusModel.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModel.Entities.CertificateQualityDomain.WarehouseQualityCertificateDomain;
    using ParusModel.Entities.Common;
    using ParusModel.Entities.ContractDomain;
    using ParusModel.Entities.CreditSlipDomain;
    using ParusModel.Entities.CuttingOrderDomain;
    using ParusModel.Entities.DepartmentOrderDomain;
    using ParusModel.Entities.ExpenditureInvoiceDomain;
    using ParusModel.Entities.GoodsSupplyDomain;
    using ParusModel.Entities.NomenclatorDomain;
    using ParusModel.Entities.PermissionMaterialDomain;
    using ParusModel.Entities.PlanReceiptOrderDomain;
    using ParusModel.Entities.TestSheetDomain;

    public static class SampleEntity
    {
        public static Contractor CreateAgnlist()
        {
            return new Contractor { Rn = 264833250 };
        }
        public static CertificateQuality CreateCertificateQuality()
        {
            return new CertificateQuality
            {
                UserCreator = CreateAgnlist(),
                CreatorFactory = CreateAgnlist(),
                Cast = "abc",
                CreationDate = Convert.ToDateTime("01.01.2013"),
                Catalog = new Catalog(1007318670),
                DeliveryCondition = "abc",
                FullRepresentation = "abc",
                GostMarka = "abc",
                GostMix = "abc",
                MakingDate = Convert.ToDateTime("01.01.2013"),
                Marka = "abc",
                Mix = "abc",
                ModeThermoTreatment = "abc",
                NomerCertificata = "1",
                Note = "abc",
                Numb = 2,
                Pref = "abc11133",
                StandardSize = "abc",
                StorageDate = Convert.ToDateTime("01.01.2013")
            };
        }
        public static PlanReceiptOrder CreatePlanReceiptOrder()
        {
            return new PlanReceiptOrder
            {
                CreationDate = new DateTime(2013, 1, 5),
                Catalog = new Catalog(1007318777),
                GroundDocumentDate = new DateTime(2013, 3, 10),
                GroundDocumentNumb = "GroundDocNumb",
                Note = "Note",
                Numb = 12,
                Pref = "Pref",
                StaffingDivision = new StaffingDivision { Rn = 411467752 },
                State = PlanReceiptOrderState.NotСonfirm,
                StateDate = new DateTime(2013, 4, 15),
                UserContractor = CreateAgnlist(),
                UserCreator = CreateAgnlist(),
                GroundTypeOfDocument = new TypeOfDocument { Rn = 347089877 },
                StoreGasStationOilDepot = CreateStoreGasStationOilDepot()
            };
        }
        public static StoreGasStationOilDepot CreateStoreGasStationOilDepot()
        {
            return new StoreGasStationOilDepot { Rn = 287457664 };
        }
        public static TypeOfDocument CreateTypeOfDocument()
        {
            return new TypeOfDocument { Rn = 347089877 };
        }
        public static ActInputControl CreateActInputControl(ISession session)
        {
            return new ActInputControl
            {
                Catalog = new Catalog(1007364847),
                ControlerTareDate = new DateTime(2015, 3, 4),
                ManagerStoreAct = CreateAgnlist(),
                Note = "asd",
                OpenningTareDate = new DateTime(2013, 3, 4),
                State = ActInputControlState.New,
                ViewTareStamp = "asd"
            };

        }
        public static Pass CreatePass(ISession session)
        {
            return new Pass
            {
                CertificateQuality = CreateAndSave(session, CreateCertificateQuality),
                CreationDate = new DateTime(2013, 12, 5),
                Creator = GetUserMaratoss(),
                Catalog = new Catalog(1007315958),
                DictionaryPass = CreateAndSave(session, CreateDictionaryPass),
                Note = "Note",
                State = ManufacturersCertificatePassState.SecondState,
                StateDate = new DateTime(2012, 2, 3),
                UserWhichSetState = GetUserMaratoss()
            };
        }
        public static DictionaryPass CreateDictionaryPass()
        {
            return new DictionaryPass
            {
                UserCreator = GetUserMaratoss(),
                CreationDate = new DateTime(2012, 3, 4),
                MemoPass = GetGuid(),
                Pass = "Pass",
                Catalog = new Catalog(1007315958)
            };
        }
        public static TheMoveAct CreateTheMoveAct(ISession session)
        {
            return new TheMoveAct
            {
                ActInputControl = CreateAndSave(session, () => CreateActInputControl(session)),
                DepartmentCreator = new StaffingDivision { Rn = 411467752 },
                DepartmentReciver = new StaffingDivision { Rn = 411447245 },
                UserCreator = GetUserMaratoss(),
                UserReciver = GetUserMaratoss(),
                CreationDate = new DateTime(2022, 3, 4)
            };
        }
        public static ConclusionEssential CreateConclusionEssential(ISession session)
        {
            return new ConclusionEssential
            {
                Conclusion = CreateAndSave(session, () => CreateConclusion(session)),
                User = GetUserMaratoss(),
                CreationDate = new DateTime(2012, 3, 4),
                Department = new StaffingDivision { Rn = 411467752 }
            };
        }
        public static Conclusion CreateConclusion(ISession session)
        {
            return new Conclusion
            {
                Note = "asd",
                Text = "asd",
                CreationDate = new DateTime(2212, 3, 4),
                Contractor = GetUserMaratoss(),
                ActInputControl = CreateAndSave(session, () => CreateActInputControl(session))
            };
        }
        public static ActInputControlTechnicalState CreateActInputControlTechnicalState(ISession session)
        {
            return new ActInputControlTechnicalState
            {
                ActInputControl = CreateAndSave(session, () => CreateActInputControl(session)),
                Conclusion = "Conclusion",
                ControlerBtk = GetUserMaratoss(),
                ControlerBtkDate = new DateTime(2013, 10, 2),
                ControlerOtk = GetUserMaratoss(),
                ControlerOtkDate = new DateTime(2013, 5, 4),
                CreationDate = new DateTime(2012, 4, 4),
                Note = "Note",
                UserCreator = GetUserMaratoss()
            };
        }
        public static Contractor GetUserMaratoss()
        {
            return new Contractor { Rn = 484082568 };
        }
        public static Destination CreateDestination(ISession session)
        {
            return new Destination
            {
                CertificateQuality = CreateAndSave(session, CreateCertificateQuality),
                Creator = GetUserMaratoss(),
                DictionaryPass = CreateAndSave(session, CreateDictionaryPass),
                Note = "asd",
                StateDate = new DateTime(3012, 3, 4),
                UserWhichSetState = GetUserMaratoss(),
                State = ManufacturersCertificateDestinationState.SecondState
            };
        }
        public static ApplySolutionByRemark CreateApplySolutionByRemark(ISession session)
        {
            return new ApplySolutionByRemark
            {
                CreationDate = new DateTime(2012, 4, 4),
                Department = CreateStaffingDivision(),
                SolutionByNote = CreateAndSave(session, () => CreateSolutionByNote(session)),
                User = GetUserMaratoss()
            };
        }
        public static StaffingDivision CreateStaffingDivision()
        {
            return new StaffingDivision { Rn = 411467752 };
        }
        public static SolutionByNote CreateSolutionByNote(ISession session)
        {
            return new SolutionByNote
            {
                ActInputControl = CreateAndSave(session, () => CreateActInputControl(session)),
                Contractor = GetUserMaratoss(),
                Conclusion = "Conclusion",
                CreationDate = new DateTime(2012, 4, 4),
                Note = "NOTE"
            };
        }
        public static QualityStateControlOfTheMake CreateQualityStateControlOfTheMake(ISession session)
        {
            return new QualityStateControlOfTheMake
            {
                ActInputControl = CreateAndSave(session, () => CreateActInputControl(session)),
                Contractor = GetUserMaratoss(),
                Conclusion = "sd",
                CreationDate = new DateTime(2015, 3, 4),
                Note = "asd"
            };
        }
        public static QualityStateControlOfTheMakeSignature CreateQualityStateControlOfTheMakeSignature(ISession session)
        {
            return new QualityStateControlOfTheMakeSignature
            {
                CreationDate = new DateTime(2017, 3, 4),
                Department = CreateStaffingDivision(),
                User = GetUserMaratoss(),
                QualityStateControlOfTheMake = CreateAndSave(session, () => CreateQualityStateControlOfTheMake(session))
            };
        }
        public static ActInputControlFunctioning CreateActInputControlFunctioning(ISession session)
        {
            return new ActInputControlFunctioning
            {
                ActInputControl = CreateAndSave(session, () => CreateActInputControl(session)),
                Contractor = GetUserMaratoss(),
                Conclusion = "asd",
                Note = "dfg",
                CreationDate = new DateTime(2013, 2, 5)
            };
        }
        public static ActInputControlFunctioningSignature CreateActInputControlFunctioningSignature(ISession session)
        {
            return new ActInputControlFunctioningSignature
            {
                ActInputControlFunctioning = CreateAndSave(session, () => CreateActInputControlFunctioning(session)),
                CreationDate = new DateTime(2013, 5, 5),
                Department = CreateStaffingDivision(),
                User = GetUserMaratoss()
            };
        }
        public static TechnicalStateEssential CreateTechnicalStateEssential(ISession session)
        {
            ActInputControlTechnicalState act = CreateActInputControlTechnicalState(session);
            session.Save(act);

            return Builder<TechnicalStateEssential>.CreateNew()
                .With(x => x.User, GetUserMaratoss())
                .With(x => x.Department, CreateStaffingDivision())
                .With(x => x.ActInputControlTechnicalState, act)
                .Build();
        }
        public static UnitOfMeasure GetMeasure()
        {
            return new UnitOfMeasure { Rn = 246492648 };
        }
        public static NomenclatureNumberModification GetNomModif()
        {
            return new NomenclatureNumberModification { Rn = 253392582 };
        }
        public static Company GetCompany()
        {
            return new Company { Rn = 7830001 };
        }
        public static PlanCertificate CreatePlanCertificate(ISession session)
        {
            return new PlanCertificate
            {
                CertificateQuality = CreateAndSave(session, CreateCertificateQuality),
                CountByDocument = 1,
                CreationDate = new DateTime(2013, 2, 2),
                Note = "sd",
                StateDate = new DateTime(2013, 2, 2),
                PlanReceiptOrder = CreateAndSave(session, CreatePlanReceiptOrder),
                Price = 1,
                UserCreator = GetUserMaratoss(),
                CountFact = 3,
                State = PlanCertificateState.Close
            };
        }
        public static PlanReceiptOrderPersonalAccount CreatePlanReceiptOrderPersonalAccountDto(ISession session)
        {
            return new PlanReceiptOrderPersonalAccount
            {
                CountByDocument = 1,
                CountFact = 3,
                CreationDate = new DateTime(2013, 2, 2),
                UserCreator = GetUserMaratoss(),
                Note = "Sd",
                PlaneCertificate = CreateAndSave(session, () => CreatePlanCertificate(session)),
                StateDate = new DateTime(2013, 2, 2),
                UserSetState = GetUserMaratoss(),
                PersonalAccount = GetPersonalAccountDto()
            };
        }
        public static Stage GetStagesOfTheContract(ISession session)
        {
            return new Stage
                {
                    PersonalAccount = CreateAndSave(session, GetPersonalAccountDto)
                };
        }
        public static PersonalAccount GetPersonalAccountDto()
        {
            return new PersonalAccount
                {
                    Rn = 781061228,
                    Numb = "123456789"
                };
        }
        public static AttachedDocument GetFileLinks()
        {
            return new AttachedDocument
            {
                Code = "123456789",
                Catalog = new Catalog(366457146),
                Note = "SDfsd",
                AttachedDocumentType = GetFlinkTypeOfCertificat()
            };
        }
        public static AttachedDocumentType GetFlinkTypeOfCertificat()
        {
            return new AttachedDocumentType { Rn = 784835058, Code = "Сертификат ЗИ" };
        }
        private static SectionOfSystem GetSectionOfSystem()
        {
            return new SectionOfSystem { Rn = "Options" };
        }
        public static DictionaryChemicalIndicator CreateDictionaryChemicalIndicator()
        {
            return new DictionaryChemicalIndicator
            {
                Rn = 1008019069
            };
        }
        public static DictionaryMechanicalIndicator CreateDictionaryMechanicalIndicator()
        {
            return new DictionaryMechanicalIndicator
            {
                Rn = 1008019071
            };
        }
        public static MechanicIndicatorValue CreateMechanicIndicatorValue(ISession session)
        {
            return new MechanicIndicatorValue
            {
                Value = "1",
                MechanicalIndicator = CreateDictionaryMechanicalIndicator(),
                CertificateQuality = CreateAndSave(session, CreateCertificateQuality)
            };
        }
        public static ChemicalIndicatorValue CreateChemicalIndicatorValue(ISession session)
        {
            return new ChemicalIndicatorValue
            {
                Value = "1",
                ChemicalIndicator = CreateDictionaryChemicalIndicator(),
                CertificateQuality = CreateAndSave(session, CreateCertificateQuality)
            };
        }
        public static ActSelectionOfProbe CreateQualityCertificateOfProbe()
        {
            return new ActSelectionOfProbe
            {
                Catalog = new Catalog(1007320164),
                Company = GetCompany(),
                Controler = CreateAgnlist(),
                ControlerDate = new DateTime(2013, 7, 11),
                Sample = "10",
                CreationDate = new DateTime(2013, 7, 11),
                DepartmentCreator = CreateStaffingDivision(),
                Creator = CreateAgnlist(),
            };
        }
        public static CuttingOrder CreateCuttingOrder(ISession session)
        {
            return new CuttingOrder
            {
                Catalog = new Catalog(1007300938),
                AssumeDate = new DateTime(2013, 7, 17),
                Company = GetCompany(),
                CreationDate = new DateTime(2013, 7, 17),
                Creator = CreateAgnlist(),
                DateDocumentIntegration = new DateTime(2013, 7, 17),
                Department = CreateStaffingDivision(),
                District = CreateStaffingDivision(),
                Inspector = CreateAgnlist(),
                Note = "NOTE",
                Numb = 100,
                Pref = "Pref",
                Priority = CuttingOrderPriority.FirstPriority,
                State = CuttingOrderState.FirstState,
                Storekeeper = CreateAgnlist()
            };
        }
        public static ActSelectionOfProbeDepartment CreateQualityCertificateOfProbeDepartment(ISession session)
        {
            return new ActSelectionOfProbeDepartment
            {
                AgentDepartment = CreateAgnlist(),
                Company = GetCompany(),
                AgentDepartmentDate = new DateTime(2013, 7, 12),
                Controler = CreateAgnlist(),
                ControlerDate = new DateTime(2013, 7, 12),
                CreationDate = new DateTime(2013, 7, 12),
                Creator = CreateAgnlist(),
                Customer = CreateAgnlist(),
                CustomerDate = new DateTime(2013, 7, 12),
                DepartmentMakingSample = CreateStaffingDivision(),
                ActSelectionOfProbe = CreateAndSave(session, CreateQualityCertificateOfProbe)
                //Priority = CuttingOrderPriority.FirstPriority
                //                States = CuttingOrderState.NotСonfirm,
                //                Storekeeper = CreateAgnlist()
            };
        }
        public static CuttingOrderMove CreateCuttingOrderMove(ISession session)
        {
            return new CuttingOrderMove
            {
                Catalog = new Catalog(1007300938),
                Company = GetCompany(),
                CreationDate = new DateTime(2013, 7, 17),
                CuttingOrder = CreateAndSave(session, () => CreateCuttingOrder(session)),
                Note = "123",
                RecipientDocument = CreateAgnlist()
            };
        }
        public static CuttingOrderSpecification CreateCuttingOrderSpecification(ISession session)
        {
            return new CuttingOrderSpecification
            {
                Catalog = new Catalog(1007300938),
                AssumeDate = new DateTime(2013, 7, 17),
                Company = GetCompany(),
                CountPartWithBlank = 1,
                CreationDate = new DateTime(2013, 7, 17),
                CuttingOrder = CreateAndSave(session, () => CreateCuttingOrder(session)),
                DemandContract = 1,
                DemandGoods = 1,
                DemandPlanMonth = 1,
                Department = CreateStaffingDivision(),
                PersonalAccount = GetPersonalAccountDto(),
                Inspector = CreateAgnlist(),
                MaxDeflectionLenght = 1,
                MeasureNorm = GetMeasure(),
                MeasureWeight = GetMeasure(),
                MinDeflectionLenght = 1,
                NomenclatureNumberModification = GetNomModif(),
                NormExpense = 1,
                PartBlankLenght = 1,
                PartBlankWeight = 1,
                PartBlankWidth = 1,
                // States = CuttingOrderSpecificationState.NotСonfirm
            };
        }
        public static Sample CreateSample(ISession session)
        {
            return new Sample
            {
                Catalog = new Catalog(1007300938),
                BatchSize = 1,
                Count = 1,
                Creator = CreateAgnlist(),
                CuttingOrderSpecification = CreateAndSave(session, () => CreateCuttingOrderSpecification(session)),
                GeometricsLength = 1,
                GeometricsWidth = 1,
                Measure = GetMeasure(),
                NomenclatureNumberModification = GetNomModif(),
                NormExpense = 1,
                Note = "123",
                Weight = 1
            };
        }
        public static SampleCertification CreateSampleCertification(ISession session)
        {
            return new SampleCertification
            {
                Catalog = new Catalog(1007300938),
                Company = GetCompany(),
                Sample = CreateAndSave(session, () => CreateSample(session))
            };
        }
        public static Certification CreateCertification(ISession session)
        {
            return new Certification
            {
                Catalog = new Catalog(1007300938),
                Company = GetCompany(),
                CuttingOrderSpecification = CreateAndSave(session, () => CreateCuttingOrderSpecification(session)),
            };
        }
        public static ActSelectionOfProbeDepartmentRequirement CreateSelectionOfProbe()
        {
            return Builder<ActSelectionOfProbeDepartmentRequirement>.CreateNew()
                .Build();
        }
        public static NameOfCurrency GetNameOfCurrency()
        {
            return new NameOfCurrency
                {
                    Rn = 269284072,
                };
        }
        public static PermissionMaterial CreatePermissionMaterial(ISession session)
        {
            return new PermissionMaterial
                {
                    Note = "simple note",
                    Justification = "simple justtification",
                    Obj = "simple obj",
                    State = PermissionMaterialState.NotConfirmed,
                    StateDate = new DateTime(2013, 01, 01),
                    Catalog = new Catalog(1007929347),
                    Count = 45,
                    AcceptToDate = new DateTime(2013, 01, 01)
                };
        }
        public static PermissionMaterialExtension CreatePermissionMaterialExtension(ISession session)
        {
            return new PermissionMaterialExtension
                {
                    AcceptToDate = new DateTime(2013, 01, 01),
                    PermissionMaterial = CreateAndSave(session, () => CreatePermissionMaterial(session))
                };
        }

        public static PersonalAccount GetPersonalAccount()
        {
            return new PersonalAccount { Rn = 1007883496 };
        }

        public static DepartmentOrder CreateDepartmentOrder()
        {
            return new DepartmentOrder
            {
                Catalog = new Catalog(1008318811),
                Priority = 1,
            };
        }
        public static DepartmentOrderSpecification CreateDepartmentOrderSpecifacation(ISession session)
        {
            return new DepartmentOrderSpecification
            {
                DepartmentOrder = CreateAndSave(session, CreateDepartmentOrder),
                Quantity = 1,
                Catalog = new Catalog(1008318811)
            };
        }

        public static DepartmentOrderComment CreateDepartmentOrderComment(ISession session)
        {
            return new DepartmentOrderComment
            {
                DepartmentOrder = CreateAndSave(session, CreateDepartmentOrder),

                Comment = "daf",
                Catalog = new Catalog(1008318811)
            };
        }

        public static TestSheet CreateTestSheet()
        {
            return new TestSheet
            {
                Company = GetCompany(),
                Catalog = new Catalog(1008015757),
                State = TestSheetState.NotСonfirm,
                Note = "Тест",
                Number = 1,
                TestCode = "Ф",
                Heater = CreateAgnlist(),
                SampleMaker = CreateAgnlist(),
                LabChief = CreateAgnlist(),
                OtkEmployee = CreateAgnlist(),
                VpEmployee = CreateAgnlist(),
                StateDate = new DateTime(2013, 2, 12),
                CreationDate = new DateTime(2013, 3, 14),
                HeaterDate = new DateTime(2013, 4, 12),
                SampleMakerDate = new DateTime(2013, 5, 15),
                LabChiefDate = new DateTime(2013, 6, 17),
                OtkEmployeeDate = new DateTime(2013, 7, 18),
                VpEmployeeDate = new DateTime(2013, 8, 19)
            };
        }
        public static TestResult CreateTestResult(ISession session)
        {
            return new TestResult
            {
                Company = GetCompany(),
                Catalog = new Catalog(1008015757),
                AnalysesRange = "12335-6789",
                TestingMethod = "Тестовый",
                Requirements = "Необходимые",
                Equipment = "Лучшее",
                Value = "Много",
                Note = "Это тест",
                IndicatorName = "Прочность",
                Unit = "кг",
                CreationDate = new DateTime(2013, 1, 2),
                Creator = CreateAgnlist(),
                TestSheet = CreateAndSave(session, CreateTestSheet)
            };
        }
        public static HeatTreatment CreateHeatTreatment(ISession session)
        {
            return new HeatTreatment
            {
                Company = GetCompany(),
                Catalog = new Catalog(1008015757),
                Operation = "Тест",
                PutTemperature = 25,
                SetTemperature = 50,
                HeatingTime = 10,
                HoldingTime = 20,
                Ambience = "Вода",
                AmbientTemperature = 33,
                TestSheet = CreateAndSave(session, CreateTestSheet)
            };
        }

        public static SampleResultSet CreateSampleResultSet(ISession session)
        {
            return new SampleResultSet
            {
                Company = GetCompany(),
                Catalog = new Catalog(1008015757),
                Title = "Тесты",
                IsRow = true,
                Value1 = "АА",
                Value2 = "ББ",
                Value3 = "ББ",
                Value4 = "ВВ",
                Value5 = "ГГ",
                Value6 = "ДД",
                Value7 = "ЕЕ",
                Value8 = "ЁЁ",
                Value9 = "ЖЖ",
                Value10 = "ЗЗ",
                TestResult = CreateAndSave(session, () => CreateTestResult(session))
            };
        }

        private static string GetGuid()
        {
            string guid = Guid.NewGuid().ToString();
            return guid.Remove(20, guid.Length - 20);
        }
        private static T CreateAndSave<T>(ISession session, Func<T> createAction)
            where T : class
        {
            T entity = createAction();
            session.Save(entity);
            session.Flush();
            session.Evict(entity);

            return entity;
        }

        public static WarehouseQualityCertificate CreateWarehouseQualityCertificate(ISession session)
        {
            return new WarehouseQualityCertificate
            {
                Catalog = new Catalog(1007400827),
                Note = "sdf"
            };
        }

        public static ExpenditureInvoice CreateExpenditureInvoice()
        {
            return new ExpenditureInvoice
            {
           //     Catalog = new Catalog(111141001),
           //     LegalPerson = new LegalPerson { Rn = 244134810 },
           //     TypeOfDocument = new TypeOfDocument { Rn = 246315223 },
           //     Pref = "PA13",
           ////     Numb = "22",
           //     Docdate = new DateTime(2013, 1, 3),
           //     DirNumb = "sd",
           //     DirDate = new DateTime(2013, 2, 2),
           //     Stoper = new KindOfWarehouseOperations { Rn = 246318168 },
           //     PointOfTheGraphAccount = null,
           //     Store = new StoreGasStationOilDepot { Rn = 246304432 },
           //  //   MOL = new Contractor { Rn = 246288203 },
           //     ViewShipment = 246316267,
           //    // StaffingDivision = new StaffingDivision { Rn = 246291085 },
           //     NameOfCurrency = new NameOfCurrency { Rn = 244131017 },
           //     CurCours = 1,
           //     CurBase = 1,
           //     SummWithnds = 0,
           //     RecipNumb = null,
           //     RecipDate = null,
           //     GetConfirm = null,
           //     WayBladeNumb = null,
           //     AgnDriver = null,
           //     AgentCar = null,
           //     Route = null,
           //     Facurcours = null,
           //     FacurBase = null,
           //     InStore = new StoreGasStationOilDepot { Rn = 246719044 },
           //    // InMOL = new Contractor { Rn = 246719043 },
           //     InPartyCode = null,
           //     InCurcours = 1,
           //     InCurBase = 1,
           //     TypeOfDocumentValidTypeOfDocument = new TypeOfDocument { Rn = 246318164 },
           //     ValidDocNumb = "1",
           //     ValidDocDate = new DateTime(2013, 2, 2),
           //     Comment = null
                Catalog = new Catalog(49528001),
                LegalPerson = new LegalPerson { Rn = LegalPerson.GPO },
                TypeOfDocument = new TypeOfDocument { Rn = 246315223 },
                Pref = "44813",
                
                Docdate = DateTime.Now,
                //PKG_PROC_BROKER.SET_PARAM_STR('SDIRDOC', NULL);
                // PKG_PROC_BROKER.SET_PARAM_STR('SDIRNUMB', NULL);
                //PKG_PROC_BROKER.SET_PARAM_DAT('DDIRDATE', NULL);
                Stoper = new KindOfWarehouseOperations { Rn = 246318168 },
                //PKG_PROC_BROKER.SET_PARAM_STR('SFACEACC', NULL);
                //PKG_PROC_BROKER.SET_PARAM_STR('SGRAPHPOINT', NULL);
                //тут надо брать склад гдле лежит сертификат завода изготовителя
                Store = new StoreGasStationOilDepot { Rn = 246304430 },
                //надо PKG_PROC_BROKER.SET_PARAM_STR('SMOL', '448'); брать от склада 
                // MOL = new Contractor { Rn = 246287910 },
                //select * from V_DICSHPVW where SCODE='02/01/00' and NVERSION='1872001'
                ViewShipment = 246316267,
                //  PKG_PROC_BROKER.SET_PARAM_STR('SAGENT', NULL);


                //  StaffingDivision = new StaffingDivision{Rn=}


                NameOfCurrency = new NameOfCurrency { Rn = 244131017 },
                CurCours = 1,
                CurBase = 1,
                SummWithnds = 0,
                // PKG_PROC_BROKER.SET_PARAM_STR('SRECIPDOC', NULL);
                //PKG_PROC_BROKER.SET_PARAM_STR('SRECIPNUMB', NULL);
                //PKG_PROC_BROKER.SET_PARAM_DAT('DRECIPDATE', NULL);
                //PKG_PROC_BROKER.SET_PARAM_STR('SFERRYMAN', NULL);
                //PKG_PROC_BROKER.SET_PARAM_STR('SGETCONFIRM', NULL);
                //PKG_PROC_BROKER.SET_PARAM_STR('SWAYBLADENUMB', NULL);
                //PKG_PROC_BROKER.SET_PARAM_STR('SDRIVER', NULL);
                //PKG_PROC_BROKER.SET_PARAM_STR('SCAR', NULL);
                //PKG_PROC_BROKER.SET_PARAM_STR('SROUTE', NULL);
                //PKG_PROC_BROKER.SET_PARAM_STR('STRAILER1', NULL);
                //PKG_PROC_BROKER.SET_PARAM_STR('STRAILER2', NULL);
                //PKG_PROC_BROKER.SET_PARAM_NUM('NFA_CURCOURS', NULL);
                //PKG_PROC_BROKER.SET_PARAM_NUM('NFA_CURBASE', NULL);
                InStore = new StoreGasStationOilDepot { Rn = 246719044 },
                // PKG_PROC_BROKER.SET_PARAM_STR('SIN_MOL', '022');
                //PKG_PROC_BROKER.SET_PARAM_STR('SIN_STOPER', NULL);
                //PKG_PROC_BROKER.SET_PARAM_STR('SIN_PARTY', NULL);


                InCurcours = 1,
                InCurBase = 1,
                TypeOfDocumentValidTypeOfDocument = new TypeOfDocument { Rn = 246318164 },
                ValidDocDate = new DateTime(2013, 2, 2),
                ValidDocNumb = "1",
            };
        }

        public static ExpenditureInvoiceSpecification CreateExpenditureInvoiceSpecification(ISession session)
        {
            return new ExpenditureInvoiceSpecification
            {
                ExpenditureInvoice = CreateAndSave(session, CreateExpenditureInvoice),
                Note = "test6",
                NomenclatureNumberModification = new NomenclatureNumberModification { Rn = 301424674 },
                Price = 0,
                Quantity = 1,
                QuantityAlt = 0,
                Coeff = 0,
                CoeffValSign = 0,
                CoeffValcSign = 1,
                PriceMeasure = 0,
                SummWithNDS = 0,
                GoodsParty = CreateGoodsParty()
            };
        }

        public static GoodsParty CreateGoodsParty()
        {
            return new GoodsParty { Rn = 716947857 };
        }

        public static ArrivalFromSubdivision CreateArrivalFromSubdivision(ISession session)
        {
            var arrivalFromSubdivision = Builder<ArrivalFromSubdivision>.CreateNew().With(x => x.Rn, 0).Build();
            arrivalFromSubdivision.PointOfTheGraphAccount = null;
            arrivalFromSubdivision.Agnlist_AGENT = CreateAgnlist();
            arrivalFromSubdivision.Agnlist_PARTY_AGENT = CreateAgnlist();
            arrivalFromSubdivision.Batch = CreateAndSave(session, CreateBatch);
            arrivalFromSubdivision.Catalog = new Catalog(301278535);
            arrivalFromSubdivision.KindOfWarehouseOperations = new KindOfWarehouseOperations { Rn = 341518022 };
            arrivalFromSubdivision.StoreGasStationOilDepot_STORE = CreateStoreGasStationOilDepot();
            arrivalFromSubdivision.StoreGasStationOilDepot_OUT_STORE = CreateStoreGasStationOilDepot();
            arrivalFromSubdivision.NameOfCurrency = GetNameOfCurrency();
            arrivalFromSubdivision.TypeOfDocument_VALID_TypeOfDocument = new TypeOfDocument { Rn = 246271967 };
            arrivalFromSubdivision.TypeOfDocument_DOC_TYPE = new TypeOfDocument { Rn = 246315223 };
            arrivalFromSubdivision.PersonalAccount = CreatePersonalAccount();
            arrivalFromSubdivision.StaffingDivision = CreateStaffingDivision();
            arrivalFromSubdivision.LegalPerson = CreateLeagalPerson();
            arrivalFromSubdivision.Agnlist_PARTY_AGENT = CreateAgnlist();
            arrivalFromSubdivision.Agnlist_AGENT = CreateAgnlist();

            return arrivalFromSubdivision;
        }

        public static ArrivalFromSubdivision CreateArrivalFromSubdivisionWithId(long id = 257604604)
        {
            return new ArrivalFromSubdivision { Rn = id };
        }

        public static KindOfWarehouseOperations CreateKindOfWarehouseOperations()
        {
            return new KindOfWarehouseOperations { Rn = 244166259 };
        }

        public static Batch CreateBatch()
        {
            var batch = Builder<Batch>.CreateNew().With(x => x.Rn, 0).Build();
            batch.Agnlist = CreateAgnlist();
            batch.LegalPerson = CreateLeagalPerson();
            batch.StaffingDivision = null;

            return batch;
        }

        public static LegalPerson CreateLeagalPerson()
        {
            return new LegalPerson { Rn = 244134810 };
        }

        public static CreditSlip CreateCreditSlip()
        {
            return new CreditSlip
            {
                Catalog = new Catalog(100067001),
                LegalPerson = CreateLeagalPerson(),
                PersonalAccount = CreatePersonalAccount(),
                StoreGasStationOilDepot = new StoreGasStationOilDepot { Rn = 246304432 },
                KindOfWarehouseOperations = CreateKindOfWarehouseOperations(),
                TypeOfDocument_INTypeOfDocument = new TypeOfDocument { Rn = 246271967 },
                INDOCDATE = new DateTime(2013, 11, 29),

                TypeOfDocument_DIRECTTypeOfDocument = new TypeOfDocument { Rn = 246271968 },
                DIRECTDOCNUMB = "11113/654",
                DIRECTDOCDATE = new DateTime(2013, 3, 19),

                TypeOfDocument_INVTypeOfDocument = new TypeOfDocument { Rn = 316571760 },
                INVDOCNUMB = "5073",
                INVDOCDATE = new DateTime(2013, 11, 29),

                PricesIncludeTaxes = false,
                CURCOURS = 1,
                CURBASECOURS = 1,
                ACCCOURS = 1,
                ACCBASECOURS = 1,
                FACOURS = 1,
                FABASECOURS = 1,
                Agent = new Contractor { Rn = 246288203 },
                Comment = "sad",
                NameOfCurrency = new NameOfCurrency { Rn = 244131017 },
                State = CreditSlipState.NotFulfilled,
                Contragent = new Contractor(),
                Pref = "PAR13",
                WorkDate = new DateTime()
            };
        }

        public static CreditSlipSpecification CreateCreditSlipSpecification(CreditSlip creditSlip, ISession session)
        {
            var creditSlipSpecification = new CreditSlipSpecification
            {
                CreditSlip = creditSlip ?? CreateAndSave(session, CreateCreditSlip),
                NomenclatureNumberModification = new NomenclatureNumberModification { Rn = 452602307 },
                TaxBand = new TaxBand { Rn = 250854500 },
                PLANQUANT = 1,
                FACTQUANT = 1,
                PLANQUANTALT = 0,
                FACTQUANTALT = 0,
                Price = 1,
                PRICEMEAS = false,
                PRICECALCRULE = true,
                ACCPRICE = (decimal)0.85,
                ACCPRICEMEAS = false,
                ACCSUMM = (decimal)0.85,
                PLANSUM = (decimal)0.85,
                PLANSUMTAX = 1,
                PLANSUMNDS = (decimal)0.15,
                FACTSUM = (decimal)0.85,
                FACTSUMTAX = 1,
                FACTSUMNDS = (decimal)0.15,
                AUTOCALCSIGN = true,
                SerNumb = "1Ser"
            };
            return creditSlipSpecification;
        }

        public static PersonalAccount CreatePersonalAccount()
        {
            return new PersonalAccount { Rn = 909328009 };
        }

        public static ArrivalFromSubdivisionSpecification CreateArrivalFromSubdivisionSpecification(ISession session)
        {
            var entity =
                Builder<ArrivalFromSubdivisionSpecification>.CreateNew()
                    .With(x => x.Rn, 0)
                    .With(x => x.STPLCELL, null)
                    .With(x => x.RLARTICLE, null)
                    .With(x => x.NOMNMODIFPACK, null)
                    .With(x => x.GEOGRAFY, null)
                    .With(x => x.UMEASSTORAGE, null)
                    .Build();

            entity.GoodsSupply = CreateGoodsSupply();
            entity.ArrivalFromSubdivision = CreateArrivalFromSubdivisionWithId();
            entity.NomenclatureNumberModification = GetNomModif();
            entity.Agnlist_PARTY_AGENT = CreateAgnlist();
            entity.Agnlist_PRODUCER = CreateAgnlist();

            return entity;
        }

        public static GoodsSupply CreateGoodsSupply()
        {
            return new GoodsSupply { Rn = 253562231 };
        }
    }
}
