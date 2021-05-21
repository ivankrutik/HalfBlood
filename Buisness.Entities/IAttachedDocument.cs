// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAttachedDocument.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IAttachedDocument type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities
{
    using Buisness.Entities.AttachedDocumentDomain;

    using Halfblood.Common;

    public interface IAttachedDocument : IDto<long>
    {
        long Document { get; set; }
        string Code { get; set; }
        string Note { get; set; }
        AttachedDocumentTypeDto DocumentType { get; set; }
    }
}
