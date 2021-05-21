// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Acatalog.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the Acatalog type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModel.Policy
{
    using System.Collections.Generic;
    using DataAccessLogic.Infrastructure;

    using Halfblood.Common;

    public class Acatalog : IHasUid<long>
    {
        public virtual long Rn { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual Company Company { get; set; }
        public virtual Acatalog Parent { get; set; }
        public virtual SectionOfSystem SectionOfSystem { get; set; }
        public virtual Version Version { get; set; }
        public virtual IList<UserPrivilege> UserPrivileges { get; set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}
