// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcatalogFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AcatalogFilterStrategy type.
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
    [FilterForEntity(typeof(Acatalog))]
    public class AcatalogFilterStrategy : FilteringStrategyBase<Acatalog, AcatalogFilter>
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
        public override IQueryOver<Acatalog, Acatalog> Filtering(IQueryOver<Acatalog, Acatalog> query, AcatalogFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query.WhereRestrictionOn(x => x.Name).IsLike(filter.Name);
            }

            if (filter.SectionOfSystem != null && !string.IsNullOrWhiteSpace(filter.SectionOfSystem.UnitCode))
            {
                query.JoinQueryOver(x => x.SectionOfSystem, JoinType.LeftOuterJoin)
                    .Where(x => x.Rn == filter.SectionOfSystem.UnitCode);
            }

            if (filter.UserPrivilege != null)
            {
                UserPrivilege userPrivilegeALias = null;
                query.JoinAlias(x => x.UserPrivileges, () => userPrivilegeALias);
                query.JoinQueryOver(() => userPrivilegeALias.Role, JoinType.InnerJoin);
                if (filter.UserPrivilege.Role != null)
                {
                    if (filter.UserPrivilege.Role.Rn != 0)
                    {
                        query.Where(() => userPrivilegeALias.Role.Rn == filter.UserPrivilege.Role.Rn);
                    }

                    if (filter.UserPrivilege.Role.UserRoles != null)
                    {
                        UserRole userRoleAlias = null;
                        query.JoinAlias(() => userPrivilegeALias.Role.UserRoles, () => userRoleAlias)
                            .EqualsUser(x => userRoleAlias.UserList.AUTHID);

                        //                        var fil = Restrictions.EqProperty(
                        //                            Projections.SqlFunction("User", NHibernateUtil.String),
                        //                            Projections.Property<UserRole>(x => userRoleAlias.UserList.AUTHID));
                        //                        query.Where(fil);
                    }
                }

                if (filter.UserPrivilege.UnitFunction != null)
                {
                    UnitFunction unitfuncAlias = null;
                    query.JoinAlias(() => userPrivilegeALias.UnitFunctions, () => unitfuncAlias);
                    query.Where(x => unitfuncAlias.Standard == filter.UserPrivilege.UnitFunction.Standard);

                    if (filter.UserPrivilege.UnitFunction.SectionOfSystemUnitcode != null)
                    {
                        query.JoinQueryOver(() => unitfuncAlias.SectionOfSystemUnitcode, JoinType.InnerJoin);
                        if (!string.IsNullOrWhiteSpace(filter.UserPrivilege.UnitFunction.SectionOfSystemUnitcode.UnitCode))
                        {
                            query.Where(x => unitfuncAlias.SectionOfSystemUnitcode.Rn == filter.UserPrivilege.UnitFunction.SectionOfSystemUnitcode.UnitCode);
                        }
                    }
                }
            }

            return query;
        }
    }
}
