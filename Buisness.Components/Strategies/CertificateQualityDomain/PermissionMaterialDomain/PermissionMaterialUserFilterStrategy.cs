namespace Buisness.Components.Strategies.CertificateQualityDomain.PermissionMaterialDomain
{
    using Buisness.Filters;
    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using ParusModel.Entities.PermissionMaterialDomain;

    [FilterForEntity(typeof(PermissionMaterialUser))]
    public class PermissionMaterialUserFilterStrategy : FilteringStrategyBase<PermissionMaterialUser, PermissionMaterialUserFilter>
    {
        public override IQueryOver<PermissionMaterialUser, PermissionMaterialUser> Filtering
            (IQueryOver<PermissionMaterialUser, PermissionMaterialUser> query, PermissionMaterialUserFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.PermissionMaterial.Rn > 0)
            {
                query.Where(x => x.PermissionMaterial.Rn == filter.PermissionMaterial.Rn);
            }

            return query.OrderBy(x => x.Fullname).Asc();
        }
    }
}