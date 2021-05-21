// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocumentFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AttachedDocumentFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CommonDomain
{
    using System.Collections;

    using Buisness.Filters;

    using DataAccessLogic.Infrastructure;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.Transform;

    using ParusModel.Entities.AttachedDocumentDomain;

    [FilterForEntity(typeof(AttachedDocument))]
    public class AttachedDocumentFilterStrategy
        : FilteringStrategyBase<AttachedDocument, AttachedDocumentFilter>
    {
        public override IQueryOver<AttachedDocument, AttachedDocument>
            Filtering(IQueryOver<AttachedDocument, AttachedDocument> query, AttachedDocumentFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.Document != 0)
            {
                query.Where(x => x.Document == filter.Document);
            }

            // Dirty hack - отказ от блоба
            //query.Fetch(x => x.AttachedDocumentType)
            //    .Eager
            //    .Select(
            //        x => x.AttachedDocumentType,
            //        x => x.Catalog,
            //        x => x.Code,
            //        x => x.Document,
            //        x => x.Note,
            //        x => x.Rn)
            //    .TransformUsing(new AttachedDocumentTransform());

            return query;
        }
    }
    
    internal class AttachedDocumentTransform : IResultTransformer
    {
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            return new AttachedDocument
            {
                AttachedDocumentType = (AttachedDocumentType)tuple[0],
                Catalog = (Catalog)tuple[1],
                Code = (string)tuple[2],
                Document = (long)tuple[3],
                Note = (string)tuple[4],
                Rn = (long)tuple[5]
            };
        }

        public IList TransformList(IList collection)
        {
            return collection;
        }
    }
}
