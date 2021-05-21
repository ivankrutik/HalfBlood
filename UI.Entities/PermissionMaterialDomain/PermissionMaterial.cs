using ReactiveUI;

namespace UI.Entities.PermissionMaterialDomain
{
    using Halfblood.Common;
    using System;
    using UI.Entities.CommonDomain;

    public class PermissionMaterial : EntityBase<PermissionMaterial>
    {
        public PermissionMaterial()
        {
            PermissionMaterialExtensions = new ReactiveList<PermissionMaterialExtension>();
            PmUsers = new ReactiveList<PermissionMaterialUser>();
        }

        public long Rn { get; set; }
        public Catalog Catalog { get; set; }
        public string Note { get; set; }
        public string Justification { get; set; }
        public User Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Obj { get; set; }
        public User UserSetState { get; set; }
        public PermissionMaterialState State { get; set; }
        public DateTime? StateDate { get; set; }
        public decimal? Count { get; set; }
        public DateTime? AcceptToDate { get; set; }
        public ReactiveList<PermissionMaterialExtension> PermissionMaterialExtensions { get; set; }
        public ReactiveList<PermissionMaterialUser> PmUsers { get; set; }
    }
}