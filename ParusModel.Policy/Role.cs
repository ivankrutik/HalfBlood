// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Role.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the Role type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModel.Policy
{
    using System.Collections.Generic;

    public class Role
    {
        public virtual long Rn { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<UserPrivilege> UserPrivileges { get; set; }
        public virtual IList<UserRole> UserRoles { get; set; }
    }
}
