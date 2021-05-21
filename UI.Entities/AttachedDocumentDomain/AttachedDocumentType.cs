// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocumentType.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AttachedDocumentType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.AttachedDocumentDomain
{
    using System.ComponentModel;

    using CommonDomain;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;

    public class AttachedDocumentType : IUiEntity
    {
        public AttachedDocumentType()
        {
        }

        public AttachedDocumentType(long rn)
        {
            this.Rn = rn;
        }
        public long Rn { get; set; }
        public Catalog Catalog { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        object IHasUid.Rn { get { return Rn; } }
        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return "{0} ({1})".StringFormat(Code, Name);
        }
    }
}
