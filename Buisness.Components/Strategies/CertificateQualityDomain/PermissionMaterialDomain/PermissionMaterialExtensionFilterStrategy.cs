namespace Buisness.Components.Strategies.CertificateQualityDomain.PermissionMaterialDomain
{
    using Buisness.Filters;
    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.SqlCommand;
    using ParusModel.Entities.PermissionMaterialDomain;

    [FilterForEntity(typeof(PermissionMaterialExtension))]
    public class PermissionMaterialExtensionFilterStrategy : FilteringStrategyBase<PermissionMaterialExtension, PermissionMaterialExtensionFilter>
    {
        public override IQueryOver<PermissionMaterialExtension, PermissionMaterialExtension>
            Filtering(
            IQueryOver<PermissionMaterialExtension, PermissionMaterialExtension> query,
            PermissionMaterialExtensionFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.PermissionMaterial != null)
            {
                if (filter.PermissionMaterial.Rn > 0)
                {
                    query.JoinQueryOver(x => x.PermissionMaterial, JoinType.LeftOuterJoin)
                        .Where(x => x.Rn == filter.PermissionMaterial.Rn);
                }
            }

            return query.OrderBy(x => x.CreationDate).Desc();
        }
    }
}
