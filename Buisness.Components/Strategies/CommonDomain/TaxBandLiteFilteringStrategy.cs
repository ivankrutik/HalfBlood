// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxBandDilteringStrategy.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the TaxBandDilteringStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;
    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModel.Entities;

    [FilterForEntity(typeof(TaxBand))]
    class TaxBandDilteringStrategy : FilteringStrategyBase<TaxBand, TaxBandFilter>
    {
        public override IQueryOver<TaxBand, TaxBand> Filtering(IQueryOver<TaxBand, TaxBand> query, TaxBandFilter filter)
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
