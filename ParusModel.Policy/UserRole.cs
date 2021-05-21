// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRole.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the UserRole type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModel.Policy
{
    using System;

    public class UserRole
    {
        public virtual long RoleId { get; set; }
        public virtual string AuthId { get; set; }
        public virtual long Rn { get; set; }
        public virtual Role Role { get; set; }
        public virtual UserList UserList { get; set; }

        public override bool Equals(object obj)
        {

            if (obj is UserRole == false) return false;
            if (Object.ReferenceEquals(this, obj)) return true;

            if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
                return false;

            var userRole = obj as UserRole;

            return Rn == userRole.Rn;
        }

        public override int GetHashCode()
        {
            return Rn.GetHashCode();
        }
    }
}
