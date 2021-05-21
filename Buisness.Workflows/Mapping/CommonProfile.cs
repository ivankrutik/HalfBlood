// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CommonProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using ParusModel.Entities.GoodsSupplyDomain;

namespace Buisness.Workflows.Mapping
{
    using AutoMapper;

    using Buisness.Entities;
    using Buisness.Entities.CommonDomain;

    using DataAccessLogic.Infrastructure;

    using Halfblood.Common.Mappers;

    using ParusModel.Entities;

    using ParusModel.Entities.Common;

    /// <summary>
    /// The common profile.
    /// </summary>
    [AutoMapperProfile]
    public class CommonProfile : Profile
    {
        /// <summary>
        /// The configure.
        /// </summary>
        protected override void Configure()
        {
            CreateUser();
            CreateStaffingDivision();
            CreatePersonalAccount();
            CreateUnitOfMeasure();
            CreateNameOfCurrency();
            CreateTypeOfDocument();
            CreateStoreGasStationOilDepot();
            CreateTaxBand();
            CreateCatalog();
            CreateTax();
            CtreateGoodsManafer();
            CreateLegalPerson();
            CreateBatch();
            CreateKindOfWarehouseOperations();
            CreateGoodsParty();
        }

        private void CtreateGoodsManafer()
        {
            Mapper.CreateMap<GoodsManager, GoodsManagerDto>()
                .ForMember(x => x.Contractor, o => o.MapFrom(x => x.Contractor))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<GoodsManagerDto, GoodsManager>()
                .ForMember(x => x.Contractor, o => o.MapFrom(x => x.Contractor))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }
        private void CreateCatalog()
        {
            Mapper.CreateMap<Catalog, CatalogDto>()
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<CatalogDto, Catalog>()
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }
        private void CreateTaxBand()
        {
            Mapper.CreateMap<TaxBand, TaxBandDto>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<TaxBandDto, TaxBand>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }
        private void CreateTax()
        {
            Mapper.CreateMap<Tax, TaxDto>()
                //  .ForMember(x => x.IsRound, o => o.MapFrom(x => x.IsRound))
                .ForMember(x => x.Kind, o => o.MapFrom(x => x.Kind))
                //.ForMember(x => x.BeginDate, o => o.MapFrom(x => x.BeginDate))
                //.ForMember(x => x.RetCalc, o => o.MapFrom(x => x.RetCalc))
                //.ForMember(x => x.Sum, o => o.MapFrom(x => x.Sum))
                //.ForMember(x => x.Typees, o => o.MapFrom(x => x. Typees))
                //.ForMember(x => x.Value, o => o.MapFrom(x => x.Value))
                //.ForMember(x => x.ValueRet, o => o.MapFrom(x => x.ValueRet))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<TaxDto, Tax>()
                // .ForMember(x => x.IsRound, o => o.MapFrom(x => x.IsRound))
                .ForMember(x => x.Kind, o => o.MapFrom(x => x.Kind))
                //.ForMember(x => x.BeginDate, o => o.MapFrom(x => x.BeginDate))
                //.ForMember(x => x.RetCalc, o => o.MapFrom(x => x.RetCalc))
                //.ForMember(x => x.Sum, o => o.MapFrom(x => x.Sum))
                //.ForMember(x => x.Typees, o => o.MapFrom(x => x.Typees))
                //.ForMember(x => x.Value, o => o.MapFrom(x => x.Value))
                //.ForMember(x => x.ValueRet, o => o.MapFrom(x => x.ValueRet))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }
        private void CreateStoreGasStationOilDepot()
        {
            Mapper.CreateMap<StoreGasStationOilDepot, StoreGasStationOilDepotDto>()
                .ForMember(x => x.AzsName, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.AzsNumber, o => o.MapFrom(x => x.Number));
            Mapper.CreateMap<StoreGasStationOilDepotDto, StoreGasStationOilDepot>()
                .ForMember(x => x.Name, o => o.MapFrom(x => x.AzsName))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Number, o => o.MapFrom(x => x.AzsNumber));
        }
        private void CreateTypeOfDocument()
        {
            Mapper.CreateMap<TypeOfDocument, TypeOfDocumentDto>()
                .ForMember(x => x.Code, o => o.MapFrom(x => x.DocumentCode))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.DocumentName))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<TypeOfDocumentDto, TypeOfDocument>()
                .ForMember(x => x.DocumentCode, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.DocumentName, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }
        private void CreateNameOfCurrency()
        {
            Mapper.CreateMap<NameOfCurrency, NameOfCurrencyDto>()
                .ForMember(x => x.Code, o => o.MapFrom(x => x.IntCode))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name));
            Mapper.CreateMap<NameOfCurrencyDto, NameOfCurrency>()
                .ForMember(x => x.IntCode, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name));
        }
        private static void CreateUser()
        {
            Mapper.CreateMap<Contractor, UserDto>()
                .ForMember(user => user.Rn, x => x.MapFrom(user => user.Rn))
                .ForMember(user => user.TableNumber, x => x.MapFrom(user => user.ClockNumber))
                .ForMember(user => user.OrganizationName, x => x.MapFrom(user => user.Name))
                .ForMember(user => user.Firstname, x => x.MapFrom(user => user.Firstname))
                .ForMember(user => user.NameShort, x => x.MapFrom(user => user.NameShort))
                .ForMember(user => user.Lastname, x => x.MapFrom(user => user.Family));
            Mapper.CreateMap<UserDto, Contractor>()
                .ForMember(user => user.Rn, x => x.MapFrom(user => user.Rn))
                .ForMember(user => user.ClockNumber, x => x.MapFrom(user => user.TableNumber))
                .ForMember(user => user.Name, x => x.MapFrom(user => user.OrganizationName))
                .ForMember(user => user.Firstname, x => x.MapFrom(user => user.Firstname))
                .ForMember(user => user.NameShort, x => x.MapFrom(user => user.NameShort))
                .ForMember(user => user.Family, x => x.MapFrom(user => user.Lastname));
        }
        private static void CreateStaffingDivision()
        {
            Mapper.CreateMap<StaffingDivision, StaffingDivisionDto>()
                .ForMember(x => x.Rn, y => y.MapFrom(x => x.Rn))
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                .ForMember(x => x.Code, y => y.MapFrom(x => x.Code));
            Mapper.CreateMap<StaffingDivisionDto, StaffingDivision>()
                .ForMember(x => x.Rn, y => y.MapFrom(x => x.Rn))
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                .ForMember(x => x.Code, y => y.MapFrom(x => x.Code));
        }
        private static void CreatePersonalAccount()
        {
            Mapper.CreateMap<PersonalAccount, PersonalAccountDto>()
                .ForMember(x => x.Numb, y => y.MapFrom(x => x.Numb))
                .ForMember(x => x.Rn, y => y.MapFrom(x => x.Rn))
                .ForMember(x => x.StagesOfTheContract, y => y.Ignore());
            Mapper.CreateMap<PersonalAccountDto, PersonalAccount>()
                .ForMember(x => x.Rn, y => y.MapFrom(x => x.Rn))
                .ForMember(x => x.Numb, y => y.MapFrom(x => x.Numb));
            Mapper.CreateMap<PersonalAccount, PersonalAccountDtoForView>().Include<PersonalAccount, PersonalAccountDto>();
            Mapper.CreateMap<PersonalAccountDtoForView, PersonalAccount>().Include<PersonalAccountDto, PersonalAccount>();
        }
        private static void CreateUnitOfMeasure()
        {
            Mapper.CreateMap<UnitOfMeasure, UnitOfMeasureDto>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name));
            Mapper.CreateMap<UnitOfMeasureDto, UnitOfMeasure>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name));
        }

        private static void CreateLegalPerson()
        {
            Mapper.CreateMap<LegalPerson, LegalPersonDto>();
            Mapper.CreateMap<LegalPersonDto, LegalPerson>();

        }

        private static void CreateBatch()
        {
            Mapper.CreateMap<Batch, BatchDto>();
            Mapper.CreateMap<BatchDto, Batch>();

        }
        private static void CreateKindOfWarehouseOperations()
        {
            Mapper.CreateMap<KindOfWarehouseOperationsDto, KindOfWarehouseOperationsDto>();
            Mapper.CreateMap<KindOfWarehouseOperationsDto, KindOfWarehouseOperations>();

        }

        private static void CreateGoodsParty()
        {
            Mapper.CreateMap<GoodsPartyDto, GoodsParty>();
            Mapper.CreateMap<GoodsParty, GoodsPartyDto>();

        }
    }
}