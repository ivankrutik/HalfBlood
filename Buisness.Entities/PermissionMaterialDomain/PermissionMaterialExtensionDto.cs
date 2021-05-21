namespace Buisness.Entities.PermissionMaterialDomain
{
    using Buisness.Entities.CommonDomain;
    using Halfblood.Common;
    using System;
    using System.Collections.Generic;

    [RelationEntityToDto(NamesOfSectionSystem.PermissionMaterial)]
    public class PermissionMaterialExtensionDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public CatalogDto Catalog { get; set; }
        public PermissionMaterialDto PermissionMaterial { get; set; }
        public UserDto Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? AcceptToDate { get; set; }
        public UserDto UserSetState { get; set; }
        public PermissionMaterialExtensionState State { get; set; }
        public DateTime? StateDate { get; set; }
        public IList<PermissionMaterialExtensionUserDto> PmeUsers { get; set; }
    }
}