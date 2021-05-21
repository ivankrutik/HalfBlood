// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The common profile.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Mappings
{
    using AutoMapper;

    using Buisness.Entities;
    using Buisness.Entities.CommonDomain;

    using Halfblood.Common.Mappers;

    using ParusModelLite.CommonDomain;

    using UI.Entities.CommonDomain;

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
            CreateCatalog();
            CreateTaxBand();
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
        private void CreateStoreGasStationOilDepot()
        {
            Mapper.CreateMap<StoreGasStationOilDepot, StoreGasStationOilDepotDto>()
                .ForMember(x => x.AzsName, o => o.MapFrom(x => x.AzsName))
                .ForMember(x => x.AzsNumber, o => o.MapFrom(x => x.AzsNumber))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<StoreGasStationOilDepotDto, StoreGasStationOilDepot>()
                .ForMember(x => x.AzsName, o => o.MapFrom(x => x.AzsName))
                .ForMember(x => x.AzsNumber, o => o.MapFrom(x => x.AzsNumber))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));

            Mapper.CreateMap<StoreGasStationOilDepot, StoreLiteDto>()
                .ForMember(x => x.AZSNAME, o => o.MapFrom(x => x.AzsName))
                .ForMember(x => x.AZSNUMBER, o => o.MapFrom(x => x.AzsNumber))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<StoreLiteDto, StoreGasStationOilDepot>()
                .ForMember(x => x.AzsName, o => o.MapFrom(x => x.AZSNAME))
                .ForMember(x => x.AzsNumber, o => o.MapFrom(x => x.AZSNUMBER))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }
        private void CreateTypeOfDocument()
        {
            Mapper.CreateMap<TypeOfDocument, TypeOfDocumentDto>()
                .ForMember(x => x.Code, o => o.MapFrom(x => x.DocCode))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.DocName))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<TypeOfDocumentDto, TypeOfDocument>()
                .ForMember(x => x.DocCode, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.DocName, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }
        private void CreateNameOfCurrency()
        {
            Mapper.CreateMap<NameOfCurrency, NameOfCurrencyDto>()
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<NameOfCurrencyDto, NameOfCurrency>()
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }
        private void CreateStaffingDivision()
        {
            Mapper.CreateMap<StaffingDivision, StaffingDivisionDto>();
            Mapper.CreateMap<StaffingDivisionDto, StaffingDivision>();
        }
        private void CreatePersonalAccount()
        {
            Mapper.CreateMap<PersonalAccount, PersonalAccountDto>()
                .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.StagesOfTheContract, o => o.MapFrom(x => x.StagesOfTheContract));
            Mapper.CreateMap<PersonalAccountDto, PersonalAccount>()
                .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.StagesOfTheContract, o => o.MapFrom(x => x.StagesOfTheContract));
        }
        private void CreateUnitOfMeasure()
        {
            Mapper.CreateMap<UnitOfMeasure, UnitOfMeasureDto>()
                .ForMember(x => x.Code, o => o.MapFrom(x => x.MEASMNEMO))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.MEASNAME))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<UnitOfMeasureDto, UnitOfMeasure>()
                .ForMember(x => x.MEASMNEMO, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.MEASNAME, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }
        private void CreateUser()
        {
            Mapper.CreateMap<User, UserDto>()
                .ForMember(x => x.Firstname, o => o.MapFrom(x => x.Firstname))
                .ForMember(x => x.Lastname, o => o.MapFrom(x => x.Lastname))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.TableNumber, o => o.MapFrom(x => x.TableNumber))
                .ForMember(x => x.NameShort, o => o.MapFrom(x => x.NameShort))
                .ForMember(x => x.OrganizationName, o => o.MapFrom(x => x.OrganizationName));
            Mapper.CreateMap<UserDto, User>()
                .ForMember(x => x.Firstname, o => o.MapFrom(x => x.Firstname))
                .ForMember(x => x.Lastname, o => o.MapFrom(x => x.Lastname))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.TableNumber, o => o.MapFrom(x => x.TableNumber))
                .ForMember(x => x.NameShort, o => o.MapFrom(x => x.NameShort))
                .ForMember(x => x.OrganizationName, o => o.MapFrom(x => x.OrganizationName));
        }
        private void CreateTaxBand()
        {
            Mapper.CreateMap<TaxBand, TaxBandDto>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.PlaneCertificates, o => o.MapFrom(x => x.PlaneCertificates))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<TaxBandDto, TaxBand>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.PlaneCertificates, o => o.MapFrom(x => x.PlaneCertificates))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));

            Mapper.CreateMap<TaxBandLiteDto, TaxBand>()
             .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
             .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
             .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));

            Mapper.CreateMap<TaxBand, TaxBandLiteDto>()
             .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
             .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
             .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }
    }
}
