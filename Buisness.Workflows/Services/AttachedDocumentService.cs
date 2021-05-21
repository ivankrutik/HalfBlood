// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocumentService.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The attached document service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Services
{
    using Buisness.Entities.AttachedDocumentDomain;

    using Halfblood.Common;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;

    using ParusModel.Entities.AttachedDocumentDomain;

    using ServiceContracts.Facades;

    [Register(typeof(IAttachedDocumentService))]
    public class AttachedDocumentService : ServiceBase, IAttachedDocumentService
    {
        public AttachedDocumentService(IRepositoryFactory repositoryFactory,
                                       IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }

        public long Insert(AttachedDocumentDto document)
        {
            return AddEntity<AttachedDocument, AttachedDocumentDto>(document).Rn;
        }
        public byte[] GetContent(long rn)
        {
            return this.GetEntity<AttachedDocument>(rn).BData;
        }
    }
}
