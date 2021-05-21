namespace Buisness.Entities.PermissionMaterialDomain
{
    using Halfblood.Common;
    using System;

    [RelationEntityToDto(NamesOfSectionSystem.PermissionMaterial)]
    public class PermissionMaterialExtensionUserDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public CatalogDto Catalog { get; set; }
        public PermissionMaterialExtensionDto PermissionMaterialExtension { get; set; }
        public long RnUser { get; set; }
        public string Fullname { get; set; }
        public string UserPsdepName { get; set; }
        public string UserDept { get; set; }
        public PermissionMaterialUserState State { get; set; }
        public DateTime? StateDate { get; set; }
        public string Note { get; set; }
    }
}