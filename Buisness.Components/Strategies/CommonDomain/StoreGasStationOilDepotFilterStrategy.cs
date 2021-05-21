// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoreGasStationOilDepotFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the StoreGasStationOilDepotFilterStrategy type.
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
    /// The store gas station oil depot filter strategy.
    /// </summary>
    [FilterForEntity(typeof(StoreGasStationOilDepot))]
    public class StoreGasStationOilDepotFilterStrategy 
        : FilteringStrategyBase<StoreGasStationOilDepot, StoreGasStationOilDepotFilter>
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
        public override IQueryOver<StoreGasStationOilDepot, StoreGasStationOilDepot> Filtering(
            IQueryOver<StoreGasStationOilDepot, StoreGasStationOilDepot> query, StoreGasStationOilDepotFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.AzsNumber != null)
            {
                query.WhereRestrictionOn(x => x.Number).IsLike(filter.AzsNumber.ReplaceStar());
            }

            if (filter.AzsName != null)
            {
                query.WhereRestrictionOn(x => x.Name).IsLike(filter.AzsName.ReplaceStar());
            }
         
            return query;
        }
    }
}