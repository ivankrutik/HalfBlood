using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.InternalEntity.Filters
{
    using Halfblood.Common;

    public class RoleFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string ROLENAME { get; set; }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public UserRoleFilter UserRoles { get; set; }

        public static RoleFilter Default
        {
            get { return new RoleFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}