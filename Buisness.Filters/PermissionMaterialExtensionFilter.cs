namespace Buisness.Filters
{
    using Buisness.Entities.PermissionMaterialDomain;
    using Filtering.Infrastructure;
    using Halfblood.Common;
    using System;
    using System.ComponentModel;

    public class PermissionMaterialExtensionFilter : IUserFilter<long>
    {
        public PermissionMaterialExtensionFilter()
        {
            PermissionMaterial = new PermissionMaterialDto();
        }

        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public long? Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public PermissionMaterialDto PermissionMaterial { get; set; }
        public DateTime? AcceptToDate { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public static PermissionMaterialExtensionFilter Default
        {
            get { return new PermissionMaterialExtensionFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}