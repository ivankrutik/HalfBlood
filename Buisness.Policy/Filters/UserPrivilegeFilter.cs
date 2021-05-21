// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserPrivilegeFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the UserPrivilegeFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.InternalEntity.Filters
{
    using System.ComponentModel;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    public class UserPrivilegeFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public RoleFilter Role { get; set; }
        public SectionOfSystemFilter SectionOfSystem { get; set; }
        public UserPrivilegeFilter UserPrivilegePrn { get; set; }
        public UnitFunctionFilter UnitFunction { get; set; }
        public long RnAccessCatalog { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public static UserPrivilegeFilter Default
        {
            get { return new UserPrivilegeFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}