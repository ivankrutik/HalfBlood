// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitFunctionFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the UnitFunctionFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.InternalEntity.Filters
{
    using System.ComponentModel;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    public class UnitFunctionFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Code { get; set; }
        public string Name { get; set; }
        public long Numb { get; set; }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public SectionOfSystemFilter SectionOfSystemUnitcode { get; set; }
        public UserPrivilegeFilter UserPrivilegeFilter { get; set; }
        public TypeActionInSystem Standard { get; set; }
     
        public static UnitFunctionFilter Default
        {
            get { return new UnitFunctionFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}