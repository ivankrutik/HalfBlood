namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;
    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using ParusModel.Entities;
    using NHibernate.SqlCommand;
    using Halfblood.Common.Helpers;


    [FilterForEntity(typeof(GoodsManager))]
    public class GoodsManagerFilterStrategy : FilteringStrategyBase<GoodsManager, GoodsManagerFilter>
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
        public override IQueryOver<GoodsManager, GoodsManager> Filtering(IQueryOver<GoodsManager, GoodsManager> query, GoodsManagerFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.Contractor != null)
            {
                Contractor contractorAlias = null;
                query.JoinAlias(x => x.Contractor, () => contractorAlias, JoinType.LeftOuterJoin);

                if (!string.IsNullOrWhiteSpace(filter.Contractor.TableNumber))
                {
                    query.IsLike((x) => contractorAlias.ClockNumber, filter.Contractor.TableNumber.ReplaceStar(string.Empty));
                }
                if (!string.IsNullOrWhiteSpace(filter.Contractor.OrganizationName))
                {
                    query.IsLike(x => contractorAlias.Name, filter.Contractor.OrganizationName.ReplaceStar(string.Empty));
                }
            }
            return query;
        }
    }
}
