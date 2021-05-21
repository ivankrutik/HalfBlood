namespace Buisness.Workflows.Mapping
{
    using AutoMapper;
    using Buisness.Entities.PermissionMaterialDomain;
    using Halfblood.Common.Mappers;
    using ParusModel.Entities.PermissionMaterialDomain;

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

        private void CreatePermissionMaterial()
        {
            Mapper.CreateMap<PermissionMaterial, PermissionMaterialDto>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Justification, o => o.MapFrom(x => x.Justification))
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.Creator))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Obj, o => o.MapFrom(x => x.Obj))
                .ForMember(x => x.UserSetState, o => o.MapFrom(x => x.UserSetState))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.Count, o => o.MapFrom(x => x.Count))
                .ForMember(x => x.AcceptToDate, o => o.MapFrom(x => x.AcceptToDate))
                .ForMember(x => x.PermissionMaterialExtensions, o => o.MapFrom(x => x.PermissionMaterialExtensions))
                .ForMember(x => x.PmUsers, o => o.MapFrom(x => x.PmUsers));
            Mapper.CreateMap<PermissionMaterialDto, PermissionMaterial>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Justification, o => o.MapFrom(x => x.Justification))
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.Creator))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Obj, o => o.MapFrom(x => x.Obj))
                .ForMember(x => x.UserSetState, o => o.MapFrom(x => x.UserSetState))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.Count, o => o.MapFrom(x => x.Count))
                .ForMember(x => x.AcceptToDate, o => o.MapFrom(x => x.AcceptToDate))
                .ForMember(x => x.PermissionMaterialExtensions, o => o.MapFrom(x => x.PermissionMaterialExtensions))
                .ForMember(x => x.PmUsers, o => o.MapFrom(x => x.PmUsers));
        }

        private void CreatePermissionMaterialExtension()
        {
            Mapper.CreateMap<PermissionMaterialExtension, PermissionMaterialExtensionDto>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.PermissionMaterial, o => o.MapFrom(x => x.PermissionMaterial))
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.Creator))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.AcceptToDate, o => o.MapFrom(x => x.AcceptToDate))
                .ForMember(x => x.UserSetState, o => o.MapFrom(x => x.UserSetState))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.PmeUsers, o => o.MapFrom(x => x.PmeUsers));
            Mapper.CreateMap<PermissionMaterialExtensionDto, PermissionMaterialExtension>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.PermissionMaterial, o => o.MapFrom(x => x.PermissionMaterial))
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.Creator))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.AcceptToDate, o => o.MapFrom(x => x.AcceptToDate))
                .ForMember(x => x.UserSetState, o => o.MapFrom(x => x.UserSetState))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.PmeUsers, o => o.MapFrom(x => x.PmeUsers));
        }

        private void CreatePermissionMaterialUser()
        {
            Mapper.CreateMap<PermissionMaterialUser, PermissionMaterialUserDto>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.PermissionMaterial, o => o.MapFrom(x => x.PermissionMaterial))
                .ForMember(x => x.RnUser, o => o.MapFrom(x => x.RnUser))
                .ForMember(x => x.Fullname, o => o.MapFrom(x => x.Fullname))
                .ForMember(x => x.UserPsdepName, o => o.MapFrom(x => x.UserPsdepName))
                .ForMember(x => x.UserDept, o => o.MapFrom(x => x.UserDept))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note));
            Mapper.CreateMap<PermissionMaterialUserDto, PermissionMaterialUser>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.PermissionMaterial, o => o.MapFrom(x => x.PermissionMaterial))
                .ForMember(x => x.RnUser, o => o.MapFrom(x => x.RnUser))
                .ForMember(x => x.Fullname, o => o.MapFrom(x => x.Fullname))
                .ForMember(x => x.UserPsdepName, o => o.MapFrom(x => x.UserPsdepName))
                .ForMember(x => x.UserDept, o => o.MapFrom(x => x.UserDept))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note));
        }

        private void CreatePermissionMaterialExtensionUser()
        {
            Mapper.CreateMap<PermissionMaterialExtensionUser, PermissionMaterialExtensionUserDto>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.PermissionMaterialExtension, o => o.MapFrom(x => x.PermissionMaterialExtension))
                .ForMember(x => x.RnUser, o => o.MapFrom(x => x.RnUser))
                .ForMember(x => x.Fullname, o => o.MapFrom(x => x.Fullname))
                .ForMember(x => x.UserPsdepName, o => o.MapFrom(x => x.UserPsdepName))
                .ForMember(x => x.UserDept, o => o.MapFrom(x => x.UserDept))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note));
            Mapper.CreateMap<PermissionMaterialExtensionUserDto, PermissionMaterialExtensionUser>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.PermissionMaterialExtension, o => o.MapFrom(x => x.PermissionMaterialExtension))
                .ForMember(x => x.RnUser, o => o.MapFrom(x => x.RnUser))
                .ForMember(x => x.Fullname, o => o.MapFrom(x => x.Fullname))
                .ForMember(x => x.UserPsdepName, o => o.MapFrom(x => x.UserPsdepName))
                .ForMember(x => x.UserDept, o => o.MapFrom(x => x.UserDept))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note));
        }
    }
}