namespace Buisness.Filters
{
    using Buisness.Entities.PermissionMaterialDomain;
    using Filtering.Infrastructure;
    using Halfblood.Common;
    using System.ComponentModel;

    public class PermissionMaterialExtensionUserFilter : IUserFilter<long>
    {
        public PermissionMaterialExtensionUserFilter()
        {
            PermissionMaterialExtension = new PermissionMaterialExtensionDto();
        }

        object IHasUid.Rn { get { return Rn; } }

        public long Rn { get; set; }
        public PermissionMaterialExtensionDto PermissionMaterialExtension { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public static PermissionMaterialExtensionUserFilter Default
        {
            get { return new PermissionMaterialExtensionUserFilter(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}