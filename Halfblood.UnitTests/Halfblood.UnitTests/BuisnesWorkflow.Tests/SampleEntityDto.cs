// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleEntityDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the SampleEntityDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using Buisness.Entities;

namespace Halfblood.UnitTests.BuisnesWorkflow.Tests
{
    using System;
    using Buisness.Entities.AttachedDocumentDomain;
    using Buisness.Entities.CertificateQualityDomain;
    using Buisness.Entities.CertificateQualityDomain.ActInputControlDomain;
    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;

    using Common;
    using NHibernate;

    /// <summary>
    /// The sample entity dto.
    /// </summary>
    public static class SampleEntityDto
    {
        public static CertificateQualityDto CreateCertificateQuality()
        {
            return new CertificateQualityDto
            {
                UserCreator = new UserDto() { Rn = 264833250 },
                AgnlistCreatorFactory = new UserDto() { Rn = 264833250 },
                Cast = "abc",
                CreationDate = Convert.ToDateTime("01.01.2013"),
                Catalog = new CatalogDto(1007318670),
                FullRepresentation = "abc",
                GostMarka = "abc",
                GostMix = "abc",
                MakingDate = Convert.ToDateTime("01.01.2013"),
                Marka = "abc",
                Mix = "abc",
                NomerCertificate = "abc",
                Note = "abc",
                Numb = 1,
                Pref = "abc",
                Pass = CreateDictionaryPassDto(),
                StandardSize = "abc",
                StorageDate = Convert.ToDateTime("01.01.2013")
            };
        }
        public static PlanReceiptOrderDto CreatePlanReceiptOrder()
        {
            return new PlanReceiptOrderDto
            {
                CreationDate = new DateTime(2013, 1, 5),
                Catalog = new CatalogDto(1007318777),
                GroundDocumentDate = new DateTime(2013, 3, 10),
                GroundDocumentNumb = "GroundDocNumb",
                Note = "Note",
                Numb = 12,
                PlanCertificates = { },
                Pref = "Pref",
                StaffingDivision = new StaffingDivisionDto { Rn = 411467752 },
                State = PlanReceiptOrderState.NotСonfirm,
                StateDate = new DateTime(2013, 4, 15),
                UserContractor = new UserDto() { Rn = 484082568 },
                UserCreator = new UserDto() { Rn = 484082568 },
                GroundTypeOfDocument = new Buisness.Entities.TypeOfDocumentDto { Rn = 347089877 },
                StoreGasStationOilDepot = new StoreGasStationOilDepotDto { Rn = 287457664 }
            };
        }
        public static PlanCertificateDto CreatePlanCertificate()
        {
            return  new PlanCertificateDto
                {
                    PlanReceiptOrder = CreatePlanReceiptOrder()
                };
        }
        public static ActInputControlDto CreateActInputControl()
        {
            return new ActInputControlDto
            {
                ControlerTare = new UserDto { Rn = 264833250 },
                ControlerTareDate = DateTime.Now,
                ManagerStoreAct = new UserDto { Rn = 264800645 },
                Note = "asd",
                OpenningTareDate = DateTime.Now,
                State = ActInputControlState.New,
                ViewTareStamp = "asd"
            };
        }
        public static PassDto CreatePassDto()
        {
            return new PassDto
            {
                CertificateQuality = CreateCertificateQuality(),
                CreationDate = new DateTime(2013, 12, 5),
                UserCreator = GetUserMaratoss(),
                Catalog = new CatalogDto(1007315958),
                DictionaryPass = CreateDictionaryPassDto(),
                Note = "Note",
                State = ManufacturersCertificatePassState.FirstState,
                StateDate = new DateTime(2012, 2, 3),
                UserWhichSetState = GetUserMaratoss()
            };
        }
        public static DictionaryPassDto CreateDictionaryPassDto()
        {
            return new DictionaryPassDto
            {
                Agnlist = GetUserMaratoss(),
                CreationDate = new DateTime(2012, 3, 4),
                MemoPass = GetGuid(),
                Pass = "Pass",
                Catalog = new CatalogDto(1007315958)
            };
        }
        public static TheMoveActDto CreateTheMoveAct()
        {
            return new TheMoveActDto
            {
                ActInputControl = CreateActInputControl(),
                DepartmentCreator = new StaffingDivisionDto { Rn = 411467752 },
                DepartmentReciver = new StaffingDivisionDto { Rn = 411447245 },
                UserCreator = GetUserMaratoss(),
                UserReciver = GetUserMaratoss(),
                CreationDate = DateTime.Now
            };
        }
        public static ConclusionEssentialDto CreateConclusionEssential()
        {
            return new ConclusionEssentialDto
            {
                Conclusion = CreateConclusion(),
                User = GetUserMaratoss(),
                CreationDate = DateTime.Now,
                Department = new StaffingDivisionDto { Rn = 411467752 }
            };
        }
        public static ConclusionDto CreateConclusion()
        {
            return new ConclusionDto
            {
                NOTE = "asd",
                TEXT = "asd",
                CREATIONDATE = DateTime.Now,
                AGNLIST = GetUserMaratoss(),
                ACTINPUTCONTROL = CreateActInputControl()
            };
        }
        [Obsolete("Не заполнена коллекция")]
        public static ActInputControlTechnicalStateDto CreateActInputControlTechnicalStateDto()
        {
            return new ActInputControlTechnicalStateDto
            {
                ActInputControl = CreateActInputControl(),
                Conclusion = "Conclusion",
                ControlerBtk = GetUserMaratoss(),
                ControlerBtkDate = new DateTime(2013, 10, 2),
                ControlerOtk = GetUserMaratoss(),
                ControlertOtkDate = new DateTime(2013, 5, 4),
                CreationDate = new DateTime(2012, 4, 4),
                Note = "Note",
                UserCreator = GetUserMaratoss()
            };
        }
        public static UserDto GetUserMaratoss()
        {
            return new UserDto { Rn = 484082568, TableNumber = "087220" };
        }
        public static ActInputControlDestinationDto CreateActInputControlDestinationDto()
        {
            return new ActInputControlDestinationDto
            {
                CertificateQuality = CreateCertificateQuality(),
                Creator = GetUserMaratoss(),
                DICPASS = CreateDictionaryPassDto(),
                Note = "asd",
                StateDate = DateTime.Now,
                UserWhichSetState = GetUserMaratoss(),
                State = ActInputControlDestinationState.Close

            };
        }
        public static ApplySolutionByRemarkDto CreateApplySolutionByRemarkDto()
        {
            return new ApplySolutionByRemarkDto
            {
                CreationDate = new DateTime(2012, 4, 4),
                Department = CreateStaffingDivisionDto(),
                SolutionByNote = CreateSolutionByNote(),
                User = GetUserMaratoss()
            };
        }
        public static StaffingDivisionDto CreateStaffingDivisionDto()
        {
            return new StaffingDivisionDto { Rn = 411467752 };
        }
        public static SolutionByNoteDto CreateSolutionByNote()
        {
            return new SolutionByNoteDto
            {
                ActInputControl = CreateActInputControl(),
                Agnlist = GetUserMaratoss(),
                Conclusion = "Conclusion",
                CreationDate = new DateTime(2012, 4, 4),
                Note = "NOTE"
            };
        }
        public static QualityStateControlOfTheMakeDto CreateQualityStateControlOfTheMake()
        {
            return new QualityStateControlOfTheMakeDto
            {
                ActInputControl = CreateActInputControl(),
                Agnlist = GetUserMaratoss(),
                Conclusion = "sd",
                CreationDate = DateTime.Now,
                Note = "asd"
            };
        }
        public static QualityStateControlOfTheMakeSignatureDto CreateQualityStateControlOfTheMakeSignature()
        {
            return new QualityStateControlOfTheMakeSignatureDto
            {
                CreationDate = DateTime.Now,
                Department = CreateStaffingDivisionDto(),
                User = GetUserMaratoss(),
                QualityStateControlOfTheMake = CreateQualityStateControlOfTheMake()
            };
        }
        private static string GetGuid()
        {
            string guid = Guid.NewGuid().ToString();
            return guid.Remove(20, guid.Length - 20);
        }

        public static AttachedDocumentTypeDto CreateAttachedDocument(ISession session)
        {
            return new AttachedDocumentTypeDto
                {
                    Code = "Сертифкаты ЗИ"
                };
        }
    }
}
