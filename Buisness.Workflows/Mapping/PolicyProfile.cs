// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PolicyProfile.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the PolicyProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Mapping
{
    using AutoMapper;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common.Mappers;

    using ParusModel.Policy;

    /// <summary>
    /// The policy profile.
    /// </summary>
    [AutoMapperProfile]
    public class PolicyProfile : Profile
    {
        protected override void Configure()
        {
            UnitFunction();
        }

        private void UnitFunction()
        {
            Mapper.CreateMap<UnitFunctionDto, UnitFunction>()
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                .ForMember(x => x.Standard, o => o.MapFrom(x => x.Standard));
            Mapper.CreateMap<UnitFunction, UnitFunctionDto>()
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                .ForMember(x => x.Standard, o => o.MapFrom(x => x.Standard));
        }
    }
}
