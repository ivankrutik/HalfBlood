using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.InternalEntity.Filters
{
    using Halfblood.Common;

    public class UserRoleFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Roleid { get; set; }
        public string Authid { get; set; }
        public long Rn { get; set; }
        public RoleFilter Role { get; set; }
        public UserListFilter UserList { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}