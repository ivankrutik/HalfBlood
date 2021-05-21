using ParusModelLite.CertificateQualityDomain.WarehouseQualityCertificateDomain;

namespace Buisness.Workflows.Mapping.CertificateQualityDomain.WarehouseQualityCertificateDomain
{
    using AutoMapper;
    using Buisness.Entities.CertificateQualityDomain.WarehouseQualityCertificateDomain;
    using Halfblood.Common.Mappers;

    [AutoMapperProfile]
    public class WarehouseQualityCertificateProfile : Profile
    {
        protected override void Configure()
        {
            CreateWarehouseQualityCertificate();
        }

        private void CreateWarehouseQualityCertificate()
        {
            Mapper.CreateMap<WarehouseQualityCertificateLiteDto, WarehouseQualityCertificateDto>()
               .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
               .ForMember(x => x.Cast, o => o.MapFrom(x => x.Cast))
               .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
               .ForMember(x => x.FullRepresentation, o => o.MapFrom(x => x.FullRepresentation))
               .ForMember(x => x.GostCast, o => o.MapFrom(x => x.GostMix))
               .ForMember(x => x.GostMix, o => o.MapFrom(x => x.GostCast))
               .ForMember(x => x.Marka, o => o.MapFrom(x => x.Marka))
               .ForMember(x => x.Mix, o => o.MapFrom(x => x.Mix))
               .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
               .ForMember(x => x.State, o => o.MapFrom(x => x.State))
               .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
               .ForMember(x => x.Storekeeper, o => o.MapFrom(x => x.Storekeeper))
               .ForMember(x => x.StorekeeperDate, o => o.MapFrom(x => x.StorekeeperDate))
               .ForMember(x => x.Customer, o => o.MapFrom(x => x.Customer))
               .ForMember(x => x.CustomerDate, o => o.MapFrom(x => x.CustomerDate))
               .ForMember(x => x.ControllerQuality, o => o.MapFrom(x => x.ControllerQuality))
               .ForMember(x => x.ControllerQualityDate, o => o.MapFrom(x => x.ControllerQualityDate))
               .ForMember(x => x.ControllerQualityDepartment, o => o.MapFrom(x => x.ControllerQualityDepartment))
               .ForMember(x => x.ControllerQualityDepartmentDate, o => o.MapFrom(x => x.ControllerQualityDepartmentDate))
               .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
               .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<WarehouseQualityCertificateDto, WarehouseQualityCertificateLiteDto>()
              .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
               .ForMember(x => x.Cast, o => o.MapFrom(x => x.Cast))
               .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
               .ForMember(x => x.FullRepresentation, o => o.MapFrom(x => x.FullRepresentation))
               .ForMember(x => x.GostMix, o => o.MapFrom(x => x.GostMix))
               .ForMember(x => x.GostCast, o => o.MapFrom(x => x.GostCast))
               .ForMember(x => x.Marka, o => o.MapFrom(x => x.Marka))
               .ForMember(x => x.Mix, o => o.MapFrom(x => x.Mix))
               .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
               .ForMember(x => x.State, o => o.MapFrom(x => x.State))
               .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
               .ForMember(x => x.Storekeeper, o => o.MapFrom(x => x.Storekeeper))
               .ForMember(x => x.StorekeeperDate, o => o.MapFrom(x => x.StorekeeperDate))
               .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
               .ForMember(x => x.Customer, o => o.MapFrom(x => x.Customer))
               .ForMember(x => x.CustomerDate, o => o.MapFrom(x => x.CustomerDate))
               .ForMember(x => x.ControllerQuality, o => o.MapFrom(x => x.ControllerQuality))
               .ForMember(x => x.ControllerQualityDate, o => o.MapFrom(x => x.ControllerQualityDate))
               .ForMember(x => x.ControllerQualityDepartment, o => o.MapFrom(x => x.ControllerQualityDepartment))
               .ForMember(x => x.ControllerQualityDepartmentDate, o => o.MapFrom(x => x.ControllerQualityDepartmentDate))
               .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }
    }
}
