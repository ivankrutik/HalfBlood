// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitFunctionFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The acatalog filter strategy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.InternalEntity.Strategies
{
    using Buisness.InternalEntity.Filters;

    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.SqlCommand;

    using ParusModel.Policy;

    /// <summary>
    /// The a catalog filter strategy.
    /// </summary>
    [FilterForEntity(typeof(UnitFunction))]
    public class UnitFunctionFilterStrategy : FilteringStrategyBase<UnitFunction, UnitFunctionFilter>
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
        public override IQueryOver<UnitFunction, UnitFunction> Filtering(IQueryOver<UnitFunction, UnitFunction> query, UnitFunctionFilter filter)
        {
            if (filter.SectionOfSystemUnitcode != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.SectionOfSystemUnitcode.UnitCode))
                {
                    query.JoinQueryOver(x => x.SectionOfSystemUnitcode, JoinType.InnerJoin)
                        .Where(x => x.Rn == filter.SectionOfSystemUnitcode.UnitCode);
                }
            }

            if (filter.UserPrivilegeFilter.RnAccessCatalog > 0)
            {
                IQueryOver<UnitFunction, UserPrivilege> joinPrivileges =
                    query.JoinQueryOver<UserPrivilege>(x => x.UserPrivileges);

                joinPrivileges.JoinQueryOver(x => x.Role, JoinType.InnerJoin)
                    .JoinQueryOver<UserRole>(x => x.UserRoles, JoinType.InnerJoin)
                    .EqualsUser(x => x.UserList.AUTHID);

                joinPrivileges.JoinQueryOver(x => x.Acatalog)
                    .Where(x => x.Rn == filter.UserPrivilegeFilter.RnAccessCatalog);
            }

            query.Where(x => x.Standard == filter.Standard);

            return query;
        }
    }
}