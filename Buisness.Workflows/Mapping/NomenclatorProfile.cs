// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NomenclatorProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the NomenclatorProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Mapping
{
    using AutoMapper;

    using Buisness.Entities.NomenclatorDomain;

    using Halfblood.Common.Mappers;

    using ParusModel.Entities.NomenclatorDomain;

    /// <summary>
    /// The nomenclator profile.
    /// </summary>
    [AutoMapperProfile]
    public class NomenclatorProfile : Profile
    {
        protected override void Configure()
        {
            CreateNomenclatureNumber();
            CreateNomenclatureNumberModification();
        }

        private static void CreateNomenclatureNumber()
        {
            Mapper.CreateMap<NomenclatureNumber, NomenclatureNumberDto>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.Code, o => o.MapFrom(x => x.NomenCode))
                  .ForMember(x => x.Name, o => o.MapFrom(x => x.NomenName))
                  .ForMember(x => x.DicmuntUmeasAlt, o => o.MapFrom(x => x.DicmuntUmeasAlt))
                  .ForMember(x => x.DicmuntUmeasMain, o => o.MapFrom(x => x.DicmuntUmeasMain));
            Mapper.CreateMap<NomenclatureNumberDto, NomenclatureNumber>()
               .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.NomenCode, o => o.MapFrom(x => x.Code))
                  .ForMember(x => x.NomenName, o => o.MapFrom(x => x.Name))
                  .ForMember(x => x.DicmuntUmeasAlt, o => o.MapFrom(x => x.DicmuntUmeasAlt))
                  .ForMember(x => x.DicmuntUmeasMain, o => o.MapFrom(x => x.DicmuntUmeasMain));
        }
        private static void CreateNomenclatureNumberModification()
        {
            Mapper.CreateMap<NomenclatureNumberModification, NomenclatureNumberModificationDto>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name));
            Mapper.CreateMap<NomenclatureNumberModificationDto, NomenclatureNumberModification>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name));
        }
    }
}