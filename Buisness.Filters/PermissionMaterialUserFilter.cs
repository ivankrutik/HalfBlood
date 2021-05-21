namespace Buisness.Filters
{
    using Buisness.Entities.PermissionMaterialDomain;
    using Filtering.Infrastructure;
    using Halfblood.Common;
    using System.ComponentModel;

    public class PermissionMaterialUserFilter : IUserFilter<long>
    {
        public PermissionMaterialUserFilter()
        {
            PermissionMaterial = new PermissionMaterialDto();
        }

        object IHasUid.Rn { get { return Rn; } }

        public long Rn { get; set; }
        public PermissionMaterialDto PermissionMaterial { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }
        public static PermissionMaterialUserFilter Default
        {
            get { return new PermissionMaterialUserFilter(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}