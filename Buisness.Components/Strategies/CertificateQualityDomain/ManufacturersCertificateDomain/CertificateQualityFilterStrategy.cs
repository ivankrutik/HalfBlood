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
    using NHibernate.SqlCommand;

    using NHibernate.Criterion;
    using ParusModel.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModel.Entities.NomenclatorDomain;

    [FilterForEntity(typeof(CertificateQuality))]
    public class CertificateQualityFilterStrategy : FilteringStrategyBase<CertificateQuality, CertificateQualityFilter>
    {
        public override IQueryOver<CertificateQuality, CertificateQuality> Filtering(
            IQueryOver<CertificateQuality, CertificateQuality> query, CertificateQualityFilter filter)
        {
            query.FindByRn(filter.Rn);

            query.IsBetween(x => x.CreationDate, filter.CreationDate);
            query.IsBetween(x => x.StorageDate, filter.StorageDate);
            query.IsBetween(x => x.MakingDate, filter.MakingDate);

            query.IsLike(x => x.StandardSize, filter.StandardSize.ReplaceStar());
            query.IsLike(x => x.NomerCertificata, filter.NomerCertificata.ReplaceStar());
            query.IsLike(x => x.ModeThermoTreatment, filter.ModeThermoTreatment.ReplaceStar());
            query.IsLike(x => x.Mix, filter.Mix.ReplaceStar());
            query.IsLike(x => x.Marka, filter.Marka.ReplaceStar());
            query.IsLike(x => x.GostMix, filter.GostMix.ReplaceStar());
            query.IsLike(x => x.GostMarka, filter.GostMarka.ReplaceStar());
            query.IsLike(x => x.FullRepresentation, filter.FullRepresentation.ReplaceStar());
            query.IsLike(x => x.DeliveryCondition, filter.DeliveryCondition.ReplaceStar());
            query.IsLike(x => x.Cast, filter.Cast.ReplaceStar());

            query.IsIn(x => x.State,filter.State);
            if (filter.UserCreator != null)
            {
                query.Where(x => x.UserCreator.Rn == filter.UserCreator.Rn);
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
                query.Where(x => x.CreatorFactory.Rn == filter.CreatorFactory.Rn);
            }

            if (filter.NomenclatureNumber != null)
            {
                query.JoinQueryOver(x => x.PlanCertificate, JoinType.LeftOuterJoin);
                NomenclatureNumberModification nommodifAlias = null;
                query.JoinAlias(x => x.PlanCertificate.ModificationNomenclature, () => nommodifAlias, JoinType.LeftOuterJoin);

                query.Where(x => nommodifAlias.Code == filter.NomenclatureNumber.Code);
            }

            return query;
        }
    }
}
