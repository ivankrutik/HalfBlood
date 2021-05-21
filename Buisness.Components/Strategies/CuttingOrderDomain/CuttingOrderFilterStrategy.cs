// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderFilterStrategy.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the CuttingOrderFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CuttingOrderDomain
{
    using Buisness.Filters;

    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModel.Entities.CuttingOrderDomain;

    [FilterForEntity(typeof(CuttingOrder))]
    public class CuttingOrderFilterStrategy : FilteringStrategyBase<CuttingOrder, CuttingOrderFilter>
    {
        public override IQueryOver<CuttingOrder, CuttingOrder> Filtering(IQueryOver<CuttingOrder, CuttingOrder> query, CuttingOrderFilter filter)
        {
            query.FindByRn(filter.Rn);

            query.IsBetween(x => x.AssumeDate, filter.AssumeDate);
            query.IsBetween(x => x.CreationDate, filter.CreationDate);
            query.IsBetween(x => x.DateDocumentIntegration, filter.DateDocumentIntegration);

            if (!string.IsNullOrWhiteSpace(filter.Note))
            {
                query.WhereRestrictionOn(x => x.Note)
                     .IsLike(filter.Note, MatchMode.Start);
            }

            if (filter.Numb != null)
            {
                query.Where(x => x.Numb == filter.Numb);
            }

            if (!string.IsNullOrWhiteSpace(filter.Pref))
            {
                query.WhereRestrictionOn(x => x.Pref)
                     .IsLike(filter.Pref, MatchMode.Start);
            }

            return query;
        }
    }

}
