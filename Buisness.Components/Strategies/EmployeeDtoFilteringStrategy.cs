// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoreLiteDtoFilteringStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the filtering strategy type for EmployeeDto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies
{
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;
    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Helper.Filter;

    /// <summary>
    /// The store lite DTO filtering strategy.
    /// </summary>
    [FilterForEntity(typeof(EmployeeDto))]
    public class EmployeeDtoFilteringStrategy
        : FilteringStrategyBase<EmployeeDto, EmployeeFilter>
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
        public override IQueryOver<EmployeeDto, EmployeeDto> Filtering(
            IQueryOver<EmployeeDto, EmployeeDto> query, EmployeeFilter filter)
        {
            var tmp = filter.Fullname.Replace("*", "%").ToUpper();
            query.Where(Restrictions.Like(Projections.SqlFunction("upper", NHibernateUtil.String, Projections.Property<EmployeeDto>(x => x.Fullname)), tmp));

            query = query.Where(x => x.Iswork == 1)
                        .OrderBy(x => x.Fullname).Asc;

            return query;
        }
    }
}