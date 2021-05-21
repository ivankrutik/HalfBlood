// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NomenclatorProfile.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the NomenclatorProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Mappings
{
    using AutoMapper;

    using Buisness.Entities.NomenclatorDomain;

    using Halfblood.Common.Mappers;

    using Entities.NomeclatorDomain;

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
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.RN))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Nomencode))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Nomenname))
                .ForMember(x => x.DicmuntUmeasAlt, o => o.MapFrom(x => x.DicmuntUmeasAlt))
                .ForMember(x => x.DicmuntUmeasMain, o => o.MapFrom(x => x.DicmuntUmeasMain));
            Mapper.CreateMap<NomenclatureNumberDto, NomenclatureNumber>()
                .ForMember(x => x.RN, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Nomencode, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Nomenname, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.DicmuntUmeasAlt, o => o.MapFrom(x => x.DicmuntUmeasAlt))
                .ForMember(x => x.DicmuntUmeasMain, o => o.MapFrom(x => x.DicmuntUmeasMain));
        }
        private static void CreateNomenclatureNumberModification()
        {
            Mapper.CreateMap<NomenclatureNumberModification, NomenclatureNumberModificationDto>();
            Mapper.CreateMap<NomenclatureNumberModificationDto, NomenclatureNumberModification>();
        }
    }
}
