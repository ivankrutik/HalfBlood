// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMechanicalIndicatorFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the DictionaryMechanicalIndicatorFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CertificateQualityDomain
{
    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModel.Entities.CertificateQualityDomain;

    /// <summary>
    /// The dictionary mechanical indicator filter strategy.
    /// </summary>
    [FilterForEntity(typeof(DictionaryMechanicalIndicator))]
    public class DictionaryMechanicalIndicatorFilterStrategy : FilteringStrategyBase<DictionaryMechanicalIndicator, DictionaryMechanicalIndicatorFilter>
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
        public override IQueryOver<DictionaryMechanicalIndicator, DictionaryMechanicalIndicator> 
            Filtering(IQueryOver<DictionaryMechanicalIndicator, DictionaryMechanicalIndicator> query, DictionaryMechanicalIndicatorFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (!string.IsNullOrWhiteSpace(filter.Code))
            {
                query.WhereRestrictionOn(x => x.Code).IsLike(filter.Code.ReplaceStar());
            }

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query.WhereRestrictionOn(x => x.Name).IsLike(filter.Name.ReplaceStar());
            }

            return query;
        }
    }
}
