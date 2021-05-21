// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoreLiteDtoFilteringStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the filtering strategy type for StoreLiteDto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies
{
    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModelLite.CommonDomain;

    /// <summary>
    /// The store lite DTO filtering strategy.
    /// </summary>
    [FilterForEntity(typeof(StoreLiteDto))]
    public class StoreLiteDtoFilteringStrategy
        : FilteringStrategyBase<StoreLiteDto, StoreGasStationOilDepotFilter>
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
        public override IQueryOver<StoreLiteDto, StoreLiteDto> Filtering(
            IQueryOver<StoreLiteDto, StoreLiteDto> query, StoreGasStationOilDepotFilter filter)
        {
            query.IsLike(x => x.AZSNUMBER, filter.AzsNumber.ReplaceStar());
            query.IsLike(x => x.AZSNAME, filter.AzsName.ReplaceStar());

            query = query.OrderBy(x => x.AZSNUMBER).Asc;

            return query;
        }
    }
}