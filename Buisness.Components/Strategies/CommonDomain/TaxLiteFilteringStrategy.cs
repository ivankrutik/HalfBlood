// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxFilteringStrategy.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the TaxFilteringStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;
    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModelLite.CommonDomain;

    [FilterForEntity(typeof(TaxLiteDto))]
    public class TaxLiteFilteringStrategy : FilteringStrategyBase<TaxLiteDto, TaxFilter>
    {
        public override IQueryOver<TaxLiteDto, TaxLiteDto> Filtering(IQueryOver<TaxLiteDto, TaxLiteDto> query, TaxFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.TaxBandRN > 0)
            {
                query.Where(x => x.TaxBandRN == filter.TaxBandRN);
            }

            return query;
        }
    }
}
