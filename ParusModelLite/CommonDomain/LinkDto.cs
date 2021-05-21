// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationshipBetweenDocuments.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the RelationshipBetweenDocuments type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModelLite.CommonDomain
{
    using Halfblood.Common;

    public class LinkDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual string InUnitCode { get; set; }
        public virtual long InDocument { get; set; }
        public virtual string OutUnitCode { get; set; }
        public virtual long OutDocument { get; set; }
        public virtual string Level { get; set; }
        public virtual int IsLeaf { get; set; }
    }
}