// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAttachedDocumentService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IAttachedDocumentService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceContracts.Facades
{
    using Buisness.Entities.AttachedDocumentDomain;

    /// <summary>
    /// The AttachedDocumentService interface.
    /// </summary>
    public interface IAttachedDocumentService
    {
        long Insert(AttachedDocumentDto document);
        byte[] GetContent(long rn);
    }
}
