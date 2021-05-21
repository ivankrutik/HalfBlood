// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificateQualityProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CertificateQualityProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Mapping.CertificateQualityDomain
{
    using AutoMapper;

    using Buisness.Entities.CertificateQualityDomain;

    using Halfblood.Common.Mappers;

    using ParusModel.Entities.CertificateQualityDomain;

    [AutoMapperProfile]
    public class CertificateQualityProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateDictionaryPass();
            this.CreateDictionaryChemicalIndicator();
            this.CreateDictionaryMechanicalIndicator();
        }

        private void CreateDictionaryChemicalIndicator()
        {
            Mapper.CreateMap<DictionaryChemicalIndicator, DictionaryChemicalIndicatorDto>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<DictionaryChemicalIndicatorDto, DictionaryChemicalIndicator>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }

        private void CreateDictionaryMechanicalIndicator()
        {
            Mapper.CreateMap<DictionaryMechanicalIndicator, DictionaryMechanicalIndicatorDto>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<DictionaryMechanicalIndicatorDto, DictionaryMechanicalIndicator>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }

        private void CreateDictionaryPass()
        {
            Mapper.CreateMap<DictionaryPass, DictionaryPassDto>();
            Mapper.CreateMap<DictionaryPassDto, DictionaryPass>()
                .IgnoreAllNonExisting();
        }
    }
}
