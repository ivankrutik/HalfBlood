// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryPassFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The dictionary pass filter strategy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CertificateQualityDomain
{
    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModelLite.CertificateQualityDomain;

    /// <summary>
    /// The dictionary pass filter strategy.
    /// </summary>
    [FilterForEntity(typeof(DictionaryPassLiteDto))]
    public class DictionaryPassLiteFilterStrategy : FilteringStrategyBase<DictionaryPassLiteDto, DictionaryPassFilter>
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
        public override IQueryOver<DictionaryPassLiteDto, DictionaryPassLiteDto> Filtering(
            IQueryOver<DictionaryPassLiteDto, DictionaryPassLiteDto> query, 
            DictionaryPassFilter filter)
        {
            query.FindByRn(filter.Rn);

            query.IsLike(x => x.MemoPass, filter.MemoPass.ReplaceStar());
            query.IsLike(x => x.Pass, filter.Pass.ReplaceStar());

            return query;
        }
    }
}
