// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderLiteDtoFilterStrategy.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The plan receipt order lite dto filter strategy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies
{
    using Buisness.Filters;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModelLite.PlanReceiptOrderDomain;

    /// <summary>
    /// The plan receipt order lite DTO filter strategy.
    /// </summary>
    [FilterForEntity(typeof(PlanReceiptOrderLiteDto))]
    public class PlanReceiptOrderLiteDtoFilterStrategy : FilteringStrategyBase<PlanReceiptOrderLiteDto, PlanReceiptOrderFilter>
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
        public override IQueryOver<PlanReceiptOrderLiteDto, PlanReceiptOrderLiteDto>
            Filtering(IQueryOver<PlanReceiptOrderLiteDto, PlanReceiptOrderLiteDto> query, PlanReceiptOrderFilter filter)
        {
            query.FindByRn(filter.Rn);

            query.IsBetween(x => x.CreationDate, filter.CreationDate);
            query.IsBetween(x => x.GroundDocDate, filter.GroundDocumentDate);
            query.IsBetween(x => x.StateDate, filter.StateDate);

            query.IsLike(x => x.GroundDocNumb, filter.GroundDocumentNumb);
            query.IsLike(x => x.Note, filter.Note);
            query.IsLike(x => x.Pref, filter.Pref);

            if (filter.Numb != null)
            {
                query.Where(x => x.Numb == filter.Numb);
            }

            query.IsIn(x => x.State, filter.States);

            if (filter.StaffingDivision != null)
            {
                query.IsIn(x => x.Department, filter.StaffingDivision.Code);
            }

            if (filter.StoreGasStationOilDepot != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.StoreGasStationOilDepot.AzsNumber))
                {
                    query.Where(x => x.Store == filter.StoreGasStationOilDepot.AzsNumber);
                }
            }

            if (!string.IsNullOrWhiteSpace(filter.GroundTypeOfDocument.DocCode))
            {
                query.Where(x => x.GroundDocType == filter.GroundTypeOfDocument.DocCode);
            }

            return query;
        }
    }
}
