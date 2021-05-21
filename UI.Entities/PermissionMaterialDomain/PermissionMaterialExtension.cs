namespace UI.Entities.PermissionMaterialDomain
{
    using CommonDomain;
    using Halfblood.Common;
    using ReactiveUI;
    using System;

    public class PermissionMaterialExtension : EntityBase<PermissionMaterialExtension>
    {
        public PermissionMaterialExtension()
        {
            PermissionMaterial = new PermissionMaterial();
            PmeUsers = new ReactiveList<PermissionMaterialExtensionUser>();
        }

        public PermissionMaterialExtension(long rn)
            : this()
        {
            PermissionMaterial.Rn = rn;
        }

        public long Rn { get; set; }
        public Catalog Catalog { get; set; }
        public PermissionMaterial PermissionMaterial { get; set; }
        public User Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? AcceptToDate { get; set; }
        public User UserSetState { get; set; }
        public PermissionMaterialExtensionState State { get; set; }
        public DateTime? StateDate { get; set; }
        public ReactiveList<PermissionMaterialExtensionUser> PmeUsers { get; set; }
    }
}
