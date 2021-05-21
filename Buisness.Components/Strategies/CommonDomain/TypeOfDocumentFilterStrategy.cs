// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeOfDocumentFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The type of document filter strategy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModel.Entities;

    /// <summary>
    /// The type of document filter strategy.
    /// </summary>
    [FilterForEntity(typeof(TypeOfDocument))]
    public class TypeOfDocumentFilterStrategy : FilteringStrategyBase<TypeOfDocument, TypeOfDocumentFilter>
    {
        /// <summary>
        /// The filtering.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryOver"/>.
        /// </returns>
        public override IQueryOver<TypeOfDocument, TypeOfDocument> Filtering(IQueryOver<TypeOfDocument, TypeOfDocument> query, TypeOfDocumentFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (!string.IsNullOrWhiteSpace(filter.DocCode))
            {
                query.WhereRestrictionOn(x => x.DocumentCode).IsLike(filter.DocCode.ReplaceStar());
            }

            if (!string.IsNullOrWhiteSpace(filter.DocName))
            {
                query.WhereRestrictionOn(x => x.DocumentName).IsLike(filter.DocName.ReplaceStar());
            }
            query = query.OrderBy(x => x.DocumentCode).Asc;

            return query;
        }
    }
}
