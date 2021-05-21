// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeAttachedDocumentService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeAttachedDocumentService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects
{
    using System.Collections.Generic;

    using Buisness.Entities;
    using Buisness.Entities.AttachedDocumentDomain;
    using Buisness.Filters;

    using ServiceContracts.Facades;

    /// <summary>
    /// The fake attached document service.
    /// </summary>
    public class FakeAttachedDocumentService : IAttachedDocumentService
    {
        public long Insert(AttachedDocumentDto document)
        {
            throw new System.NotImplementedException();
        }

        public IList<IAttachedDocument> GetDocuments(AttachedDocumentFilter filter)
        {
            throw new System.NotImplementedException();
        }

        public byte[] GetContent(long rn)
        {
            throw new System.NotImplementedException();
        }
    }
}
