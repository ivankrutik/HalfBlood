// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CommonProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.InternalService.Mapping
{
    using AutoMapper;

    using Buisness.Entities.CommonDomain;
    using Buisness.InternalEntity;

    using DataAccessLogic.Infrastructure;

    using Halfblood.Common.Mappers;

    using ParusModel.Policy;

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
            CreateUnitFunction();
        }
      
        private void CreateUnitFunction()
        {
            Mapper.CreateMap<UnitFunction, UnitFunctionDto>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Standard, o => o.MapFrom(x => x.Standard));
            Mapper.CreateMap<UnitFunctionDto, UnitFunction>().IgnoreAllNonExisting()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Standard, o => o.MapFrom(x => x.Standard));
        }
    }
          
}