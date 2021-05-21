// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryChemicalIndicatorFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the DictionaryChemicalIndicatorFilterStrategy type.
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
    /// The dictionary chemical indicator filter strategy.
    /// </summary>
    [FilterForEntity(typeof(DictionaryChemicalIndicator))]
    public class DictionaryChemicalIndicatorFilterStrategy : FilteringStrategyBase<DictionaryChemicalIndicator, DictionaryChemicalIndicatorFilter>
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
        public override IQueryOver<DictionaryChemicalIndicator, DictionaryChemicalIndicator>
            Filtering(IQueryOver<DictionaryChemicalIndicator, DictionaryChemicalIndicator> query, DictionaryChemicalIndicatorFilter filter)
        {
            query.FindByRn(filter.Rn);

            query.IsLike(x => x.Code, filter.Code.ReplaceStar());
            query.IsLike(x => x.Name, filter.Name.ReplaceStar());

            return query;
        }
    }
}
