// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StagesOfTheContractFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the StagesOfTheContractFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.ContractDomain
{
    using Buisness.Filters;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModelLite.ContractDomain;

    /// <summary>
    /// The stages of the contract filter strategy.
    /// </summary>
    [FilterForEntity(typeof(StagesOfTheContractLiteDto))]
    public class StagesOfTheContractLiteDtoFilterStrategy : FilteringStrategyBase<StagesOfTheContractLiteDto, StagesOfTheContractFilter>
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
        public override IQueryOver<StagesOfTheContractLiteDto, StagesOfTheContractLiteDto> Filtering(
            IQueryOver<StagesOfTheContractLiteDto, StagesOfTheContractLiteDto> query,
            StagesOfTheContractFilter filter)
        {
            if (filter != null)
            {
                query.FindByRn(filter.Rn);

                if (filter.RnContract != 0)
                {
                    query.Where(x => x.ContractRN == filter.RnContract);
                }

                query.Where(x => x.State == filter.State);
            }

            return query;
        }
    }
}
