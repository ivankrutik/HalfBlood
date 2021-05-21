namespace UI.ProcessComponents.Mappings.CertificateQualityDomain.PermissionMaterialDomain
{
    using AutoMapper;
    using Buisness.Entities.PermissionMaterialDomain;
    using Entities.PermissionMaterialDomain;
    using Halfblood.Common.Mappers;
    using ParusModelLite.CertificateQualityDomain.PermissionMaterialDomain;

    [AutoMapperProfile]
    public class PermissionMaterialProfile : Profile
    {
        protected override void Configure()
        {
            CreatePermissionMaterial();
            CreatePermissionMaterialExtension();
            CreatePermissionMaterialUser();
            CreatePermissionMaterialExtensionUser();
        }

        private void CreatePermissionMaterialExtension()
        {
            Mapper.CreateMap<PermissionMaterialExtension, PermissionMaterialExtensionDto>();
            Mapper.CreateMap<PermissionMaterialExtensionDto, PermissionMaterialExtension>();
        }

        private void CreatePermissionMaterial()
        {
            Mapper.CreateMap<PermissionMaterial, PermissionMaterialDto>();
            Mapper.CreateMap<PermissionMaterialDto, PermissionMaterial>();
            Mapper.CreateMap<PermissionMaterial, PermissionMaterialLiteDto>()
               .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
               .ForMember(x => x.CRn, o => o.ResolveUsing(x => x.Catalog == null ? 0 : x.Catalog.Rn))
               .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
               .ForMember(x => x.Justification, o => o.MapFrom(x => x.Justification))
               .ForMember(x => x.RnCreator, o => o.ResolveUsing(x => x.Creator == null ? 0 : x.Creator.Rn))
               .ForMember(x => x.Creator, o => o.ResolveUsing(x => x.Creator == null ? null : x.Creator.ToString()))
               .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
               .ForMember(x => x.Obj, o => o.MapFrom(x => x.Obj))
               .ForMember(x => x.RnUserSetState, o => o.ResolveUsing(x => x.UserSetState == null ? 0 : x.UserSetState.Rn))
               .ForMember(x => x.UserSetState, o => o.ResolveUsing(x => x.UserSetState == null ? null : x.UserSetState.ToString()))
               .ForMember(x => x.State, o => o.MapFrom(x => x.State))
               .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
               .ForMember(x => x.Count, o => o.MapFrom(x => x.Count))
               .ForMember(x => x.AcceptToDate, o => o.MapFrom(x => x.AcceptToDate));
        }

        private void CreatePermissionMaterialUser()
        {
            Mapper.CreateMap<PermissionMaterialUser, PermissionMaterialUserDto>();
            Mapper.CreateMap<PermissionMaterialUserDto, PermissionMaterialUser>();
        }

        private void CreatePermissionMaterialExtensionUser()
        {
            Mapper.CreateMap<PermissionMaterialExtensionUser, PermissionMaterialExtensionUserDto>();
            Mapper.CreateMap<PermissionMaterialExtensionUserDto, PermissionMaterialExtensionUser>();
        }
    }
}