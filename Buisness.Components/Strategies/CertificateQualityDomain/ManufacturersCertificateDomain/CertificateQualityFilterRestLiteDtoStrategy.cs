// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificateQualityFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CertificateQualityFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    /// <summary>
    /// The certificate quality filter strategy.
    /// </summary>
    [FilterForEntity(typeof(CertificateQualityRestLiteDto))]
    public class CertificateQualityFilterRestLiteDtoStrategy : FilteringStrategyBase<CertificateQualityRestLiteDto, CertificateQualityFilter>
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
        public override IQueryOver<CertificateQualityRestLiteDto, CertificateQualityRestLiteDto> Filtering(
            IQueryOver<CertificateQualityRestLiteDto, CertificateQualityRestLiteDto> query, CertificateQualityFilter filter)
        {
            query.FindByRn(filter.Rn);

            query.IsBetween(x => x.CreationDate, filter.CreationDate);
            query.IsBetween(x => x.StorageDate, filter.StorageDate);
            query.IsBetween(x => x.MakingDate, filter.MakingDate);

            query.IsLike(x => x.StandardSize, filter.StandardSize.ReplaceStar());
            query.IsLike(x => x.NomerCertificate, filter.NomerCertificata.ReplaceStar());
            query.IsLike(x => x.Mix, filter.Mix.ReplaceStar());
            query.IsLike(x => x.Marka, filter.Marka.ReplaceStar());
            query.IsLike(x => x.GostMix, filter.GostMix.ReplaceStar());
            query.IsLike(x => x.GostMarka, filter.GostMarka.ReplaceStar());
            query.IsLike(x => x.FullRepresentation, filter.FullRepresentation.ReplaceStar());
            query.IsLike(x => x.Cast, filter.Cast.ReplaceStar());

            if (filter.UserCreator != null)
            {
                query.Where(x => x.RnUserCreator == filter.UserCreator.Rn);
            }

            if (!string.IsNullOrWhiteSpace(filter.Pref))
            {
                query.Where(x => x.Pref == filter.Pref);
            }

            if (filter.Numb != null)
            {
                query.Where(x => x.Numb == filter.Numb);
            }

            if (filter.CreatorFactory != null)
            {
                query.Where(x => x.RnCreatorFactory == filter.CreatorFactory.Rn);
            }

            return query;
        }
    }
}
