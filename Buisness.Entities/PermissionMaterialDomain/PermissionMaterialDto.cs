namespace Buisness.Entities.PermissionMaterialDomain
{
    using Buisness.Entities.CommonDomain;
    using Halfblood.Common;
    using System;
    using System.Collections.Generic;

    [RelationEntityToDto(NamesOfSectionSystem.PermissionMaterial)]
    public class PermissionMaterialDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public CatalogDto Catalog { get; set; }
        public string Note { get; set; }
        public string Justification { get; set; }
        public UserDto Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Obj { get; set; }
        public UserDto UserSetState { get; set; }
        public PermissionMaterialState State { get; set; }
        public DateTime? StateDate { get; set; }
        public decimal? Count { get; set; }
        public DateTime? AcceptToDate { get; set; }
        public IList<PermissionMaterialExtensionDto> PermissionMaterialExtensions { get; set; }
        public IList<PermissionMaterialUserDto> PmUsers { get; set; }
    }
}