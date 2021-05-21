// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxBandFilteringStrategy.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the TaxBandFilteringStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;
    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModelLite.CommonDomain;

    [FilterForEntity(typeof(TaxBandLiteDto))]
    class TaxBandFilteringStrategy : FilteringStrategyBase<TaxBandLiteDto, TaxBandFilter>
    {
        public override IQueryOver<TaxBandLiteDto, TaxBandLiteDto> Filtering(IQueryOver<TaxBandLiteDto, TaxBandLiteDto> query, TaxBandFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (!string.IsNullOrWhiteSpace(filter.Code))
            {
                query.Where(x => x.Code == filter.Code);
            }

            return query;
        }
    }
}
