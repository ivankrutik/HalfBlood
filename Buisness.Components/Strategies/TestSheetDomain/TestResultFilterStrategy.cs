// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeDestinationFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The act selection of probe destination filter strategy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using Buisness.Filters.TestSheetsDomain;
using NHibernate;
using NHibernate.Helper.Filter;
using NHibernate.Helper.Filter.Specification;
using NHibernate.SqlCommand;
using ParusModel.Entities.TestSheetDomain;

namespace Buisness.Components.Strategies.TestSheetDomain
{
    /// <summary>
    ///     The act selection of probe destination filter strategy.
    /// </summary>
    [FilterForEntity(typeof (TestResult))]
    public class TestResultFilterStrategy : FilteringStrategyBase<TestResult, TestResultFilter>
    {
        /// <summary>
        ///     The filtering.
        /// </summary>
        /// <param name="query">
        ///     The query.
        /// </param>
        /// <param name="filter">
        ///     The filter.
        /// </param>
        /// <returns>
        ///     The <see cref="IQueryOver" />.
        /// </returns>
        public override IQueryOver<TestResult, TestResult>
            Filtering(IQueryOver<TestResult, TestResult> query, TestResultFilter filter)
        {
            if (filter != null)
            {
                query.FindByRn(filter.Rn);
                
                query.JoinQueryOver(x => x.TestSheet, JoinType.InnerJoin)
                    .Where(x => x.Rn == filter.RnTestSheet);
            }

            return query;
        }
    }
}