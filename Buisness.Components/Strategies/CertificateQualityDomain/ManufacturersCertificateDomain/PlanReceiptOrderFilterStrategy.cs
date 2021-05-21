// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using System.Linq;

    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.SqlCommand;

    using ParusModel.Entities.NomenclatorDomain;
    using ParusModel.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The plan receipt order filter strategy.
    /// </summary>
    [FilterForEntity(typeof(PlanReceiptOrder))]
    public class PlanReceiptOrderFilterStrategy : FilteringStrategyBase<PlanReceiptOrder, PlanReceiptOrderFilter>
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
        public override IQueryOver<PlanReceiptOrder, PlanReceiptOrder> Filtering(
            IQueryOver<PlanReceiptOrder, PlanReceiptOrder> query, PlanReceiptOrderFilter filter)
        {
            query.FindByRn(filter.Rn);

            query.IsBetween(x => x.CreationDate, filter.CreationDate);
            query.IsBetween(x => x.GroundDocumentDate, filter.GroundDocumentDate);

            query.IsLike(x => x.GroundDocumentNumb, filter.GroundDocumentNumb, MatchMode.Start);
            query.IsLike(x => x.Note, filter.Note, MatchMode.Start);
            query.IsLike(x => x.Pref, filter.Pref, MatchMode.Start);
            query.IsBetween(x => x.StateDate, filter.StateDate);

            if (filter.Numb != null)
            {
                query.Where(x => x.Numb == filter.Numb);
            }

            if (filter.States.Any())
            {
                query.WhereRestrictionOn(x => x.State)
                 .IsIn(filter.States.ToArray());
            }

            if (filter.PlanCertificate != null)
            {
                if (filter.PlanCertificate.ModificationNomenclature != null)
                {
                    if (filter.PlanCertificate.ModificationNomenclature.NomenclatureNumber != null)
                    {
                        if (!string.IsNullOrWhiteSpace(filter.PlanCertificate.ModificationNomenclature.NomenclatureNumber.Code))
                        {
                            query.JoinQueryOver(x => x.PlanCertificates, JoinType.LeftOuterJoin);
                            NomenclatureNumberModification nommodifAlias = null;
                            query.JoinAlias((x) => filter.PlanCertificate.ModificationNomenclature, () => nommodifAlias, JoinType.LeftOuterJoin);

                            NomenclatureNumber nomenclatureNumberAlias = null;
                            query.JoinQueryOver(() => nommodifAlias.NomenclatureNumber, () => nomenclatureNumberAlias, JoinType.LeftOuterJoin);

                            query.WhereRestrictionOn(() => nomenclatureNumberAlias.NomenCode)
                                 .IsLike(
                                     filter.PlanCertificate.ModificationNomenclature.NomenclatureNumber.Code
                                           .ReplaceStar());
                        }
                    }
                }
            }

            if (filter.StaffingDivision != null)
            {
                if (filter.StaffingDivision.Code != null && filter.StaffingDivision.Code.Any())
                {
                    query.JoinQueryOver(x => x.StaffingDivision, JoinType.LeftOuterJoin)
                         .WhereRestrictionOn(x => x.Code)
                         .IsIn(filter.StaffingDivision.Code.ToArray());
                }
            }

            if (filter.StoreGasStationOilDepot != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.StoreGasStationOilDepot.AzsNumber))
                {
                    query.JoinQueryOver(x => x.StoreGasStationOilDepot, JoinType.LeftOuterJoin)
                         .Where(x => x.Number == filter.StoreGasStationOilDepot.AzsNumber);
                }
            }

            if (!string.IsNullOrWhiteSpace(filter.GroundTypeOfDocument.DocCode))
            {
                query.JoinQueryOver(x => x.GroundTypeOfDocument, JoinType.LeftOuterJoin)
                    .Where(x => x.DocumentCode == filter.GroundTypeOfDocument.DocCode);
            }

            return query;
        }
    }
}
