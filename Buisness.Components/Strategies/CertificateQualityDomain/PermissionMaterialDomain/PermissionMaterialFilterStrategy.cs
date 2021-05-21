namespace Buisness.Components.Strategies.CertificateQualityDomain.PermissionMaterialDomain
{
    using Buisness.Filters;
    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using ParusModelLite.CertificateQualityDomain.PermissionMaterialDomain;

    [FilterForEntity(typeof(PermissionMaterialLiteDto))]
    public class PermissionMaterialFilterStrategy : FilteringStrategyBase<PermissionMaterialLiteDto, PermissionMaterialFilter>
    {
        public override IQueryOver<PermissionMaterialLiteDto, PermissionMaterialLiteDto> Filtering(IQueryOver<PermissionMaterialLiteDto, PermissionMaterialLiteDto> query, PermissionMaterialFilter filter)
        {
            query.FindByRn(filter.Rn);
            if (filter.Rnf != null)
            {
                query.Where(x => x.Rn == filter.Rnf);
            }
            query.IsIn(x => x.State, filter.States);
            query.IsBetween(x => x.StateDate, filter.StateDate);
            query.IsBetween(x => x.AcceptToDate, filter.AcceptToDate);
            query.IsBetween(x => x.CreationDate, filter.CreationDate);

            return query.OrderBy(x => x.CreationDate).Desc();
        }
    }
}