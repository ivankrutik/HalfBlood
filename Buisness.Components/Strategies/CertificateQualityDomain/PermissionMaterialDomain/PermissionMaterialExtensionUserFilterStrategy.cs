namespace Buisness.Components.Strategies.CertificateQualityDomain.PermissionMaterialDomain
{
    using Buisness.Filters;
    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using ParusModel.Entities.PermissionMaterialDomain;

    [FilterForEntity(typeof(PermissionMaterialExtensionUser))]
    public class PermissionMaterialExtensionUserFilterStrategy : FilteringStrategyBase<PermissionMaterialExtensionUser, PermissionMaterialExtensionUserFilter>
    {
        public override IQueryOver<PermissionMaterialExtensionUser, PermissionMaterialExtensionUser> Filtering
            (IQueryOver<PermissionMaterialExtensionUser, PermissionMaterialExtensionUser> query, PermissionMaterialExtensionUserFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.PermissionMaterialExtension.Rn > 0)
            {
                query.Where(x => x.PermissionMaterialExtension.Rn == filter.PermissionMaterialExtension.Rn);
            }

            return query.OrderBy(x => x.Fullname).Asc();
        }
    }
}
