// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ContractFilterStrategy type.
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
    /// The contract filter strategy.
    /// </summary>
    [FilterForEntity(typeof(ContractLiteDto))]
    public class ContractLiteFilterStrategy : FilteringStrategyBase<ContractLiteDto, ContractFilter>
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
        public override IQueryOver<ContractLiteDto, ContractLiteDto> Filtering(
            IQueryOver<ContractLiteDto, ContractLiteDto> query, ContractFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.Contaractor != null)
            {
                query.Where(x => x.ContractorAgentMemo == filter.Contaractor.TableNumber);
            }

            query.Where(x => x.State == filter.State);

            return query;
        }
    }
}
