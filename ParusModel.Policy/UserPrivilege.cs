// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserPrivilege.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the UserPrivileges type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModel.Policy
{
    using System.Collections.Generic;

    using DataAccessLogic.Infrastructure;

    using Halfblood.Common;

    public class UserPrivilege : IHasUid<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual IList<UnitFunction> UnitFunctions { get; set; }
        public virtual long Rn { get; set; }
        public virtual long? CTRLSIGN { get; set; }
        public virtual Acatalog Acatalog { get; set; }
        public virtual Company Company { get; set; }
        public virtual Role Role { get; set; }
        public virtual SectionOfSystem SectionOfSystem { get; set; }
        public virtual UserPrivilege Parent { get; set; }
        public virtual Version Version { get; set; }
        public virtual string NameSectionOfSystem { get; protected set; }
    }
}