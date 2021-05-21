// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocumentFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AttachedDocumentFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Filters
{
    using System.ComponentModel;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    public class AttachedDocumentFilter : IUserFilter<long>
    {
        public AttachedDocumentFilter()
        {
            AttachedDocumentType = AttachedDocumentTypeFilter.Default;
        }

        public string Code { get; set; }
        public string Note { get; set; }
        public AttachedDocumentTypeFilter AttachedDocumentType { get; set; }

        public static AttachedDocumentFilter Default
        {
            get { return new AttachedDocumentFilter(); }
        }
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public long Document { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}