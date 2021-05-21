namespace Buisness.Components.Strategies.CertificateQualityDomain.WarehouseQualityCertificateDomain
{
    using Buisness.Filters;
    using Halfblood.Common.Helpers;
    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using ParusModelLite.CertificateQualityDomain.WarehouseQualityCertificateDomain;

    [FilterForEntity(typeof(WarehouseQualityCertificateRestLiteDto))]
    public class WarehouseQualityCertificateLiteDtoFilterStrategy :
        FilteringStrategyBase<WarehouseQualityCertificateRestLiteDto, WarehouseQualityCertificateRestFilter>
    {
        public override IQueryOver<WarehouseQualityCertificateRestLiteDto, WarehouseQualityCertificateRestLiteDto> Filtering(
            IQueryOver<WarehouseQualityCertificateRestLiteDto, WarehouseQualityCertificateRestLiteDto> query,
            WarehouseQualityCertificateRestFilter filter)
        {
            query.FindByRn(filter.Rn);
            if (filter.RNCertificateQuality != 0)
            {
                query.Where(x => x.RNCertificateQuality == filter.RNCertificateQuality);
            }
            query.IsLike(x => x.Cast, filter.Cast.ReplaceStar(string.Empty));
            query.IsLike(x => x.FullRepresentation, filter.FullRepresentation.ReplaceStar(string.Empty));
            query.IsLike(x => x.GostMix, filter.GostMix.ReplaceStar(string.Empty));
            // query.IsLike(x => x.GostCast, filter.Cast.ReplaceStar(string.Empty));
            query.IsLike(x => x.Marka, filter.Marka.ReplaceStar(string.Empty));
            query.IsLike(x => x.Mix, filter.GostMix.ReplaceStar(string.Empty));

            query.IsBetween(x => x.CreationDate, filter.CreationDate);

            return query;
        }
    }
}
