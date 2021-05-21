// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the UserDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CommonDomain
{
    using Halfblood.Common;

    public class UserDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public bool IsWorker { get; set; }
        public string TableNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string OrganizationName { get; set; }
        public string NameShort { get; set; }
        public long Rn { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(Firstname))
            {
                return string.Format("{0} {1} ({2})", Firstname, Lastname, TableNumber);
            }
            return OrganizationName;
        }

        public override bool Equals(object obj)
        {
            if (obj is UserDto == false) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (ReferenceEquals(this, null) || ReferenceEquals(obj, null))
                return false;

            var user = obj as UserDto;

            return Rn == user.Rn;
        }

        public override int GetHashCode()
        {
            return Rn.GetHashCode();
        }
    }
}