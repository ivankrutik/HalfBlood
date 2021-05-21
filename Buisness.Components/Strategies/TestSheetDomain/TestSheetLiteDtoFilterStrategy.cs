namespace Buisness.Components.Strategies.TestSheetDomain
{
    using Buisness.Filters.TestSheetsDomain;
    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using ParusModel.Entities.TestSheetDomain;
    using ParusModelLite.TestSheetsDomain;

    /// <summary>
    /// The act selection of probe destination filter strategy.
    /// </summary>
    [FilterForEntity(typeof(TestSheetLiteDto))]
    public class TestSheetLiteDtoFilterStrategy : FilteringStrategyBase<TestSheetLiteDto, TestSheetFilter>
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
        public override IQueryOver<TestSheetLiteDto, TestSheetLiteDto>
            Filtering(IQueryOver<TestSheetLiteDto, TestSheetLiteDto> query, TestSheetFilter filter)
        {

            query.FindByRn(filter.Rn);
            query.IsBetween(x => x.CreationDate, filter.TestSheetCreationDate);

            return query;
        }
    }
}
