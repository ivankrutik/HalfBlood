// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcatalogFilter.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the AcatalogFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.InternalEntity.Filters
{
    using System.ComponentModel;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    public class AcatalogFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public string Name { get; set; }
        public UserPrivilegeFilter UserPrivilege { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public SectionOfSystemFilter SectionOfSystem { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}