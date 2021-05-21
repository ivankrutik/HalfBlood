namespace Buisness.Components.Strategies
{
    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModelLite;

    [FilterForEntity(typeof(DeficiencyLiteDto))]
    public class DeficiencyFilterStrategy : FilteringStrategyBase<DeficiencyLiteDto, DeficiencyFilter>
    {
        public override IQueryOver<DeficiencyLiteDto, DeficiencyLiteDto> Filtering(
            IQueryOver<DeficiencyLiteDto, DeficiencyLiteDto> query,
            DeficiencyFilter filter)
        {
            query.IsLike(x => x.DSE, filter.DSE.ReplaceStar(string.Empty));
            query.IsLike(x => x.ShopRecipient, filter.ShopRecipient.ReplaceStar(string.Empty));
            query.IsLike(x => x.Department, filter.ShopRecipient.ReplaceStar(string.Empty));

            return query;
        }
    }
}
