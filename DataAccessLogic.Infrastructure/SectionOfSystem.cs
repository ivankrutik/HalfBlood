// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectionOfSystem.cs" company="VZ">
//   maraoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The section of system.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessLogic.Infrastructure
{
    using Halfblood.Common;

    /// <summary>
    /// The section of system.
    /// </summary>
    public class SectionOfSystem : IHasUid<string>
    {
        public virtual string Rn { get; set; }
        public virtual string UnitName { get; set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}