namespace UI.Entities.PermissionMaterialDomain
{
    using Buisness.Entities;
    using Halfblood.Common;
    using System;

    public class PermissionMaterialExtensionUser : EntityBase<PermissionMaterialExtensionUser>
    {
        public long Rn { get; set; }
        public CatalogDto Catalog { get; set; }
        public PermissionMaterialExtension PermissionMaterialExtension { get; set; }
        public long RnUser { get; set; }
        public string Fullname { get; set; }
        public string UserPsdepName { get; set; }
        public string UserDept { get; set; }
        public PermissionMaterialUserState State { get; set; }
        public DateTime? StateDate { get; set; }
        public string Note { get; set; }
    }
}