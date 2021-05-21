// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AgnlistFilteringStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AgnlistFilteringStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;
    using Halfblood.Common.Helpers;
    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.SqlCommand;

    using ParusModel.Entities.Common;

    [FilterForEntity(typeof(AdditionalDictionary))]
    public class AdditionalDictionaryFilterStrategy : FilteringStrategyBase<AdditionalDictionary, AdditionalDictionaryFilter>
    {
        public override IQueryOver<AdditionalDictionary, AdditionalDictionary> Filtering(
            IQueryOver<AdditionalDictionary, AdditionalDictionary> query,
            AdditionalDictionaryFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (!string.IsNullOrWhiteSpace(filter.Code))
            {
                query.IsLike(x => x.Code, filter.Code.ReplaceStar(string.Empty));
            }

            if (filter.AdditionalDictionaryValues != null)
            {

                AdditionalDictionaryValues additionalDictionaryValuesAlias = null;
                query.JoinAlias(
                    x => x.AdditionalDictionaryValues,
                    () => additionalDictionaryValuesAlias,
                    JoinType.LeftOuterJoin);

                if (!string.IsNullOrWhiteSpace(filter.AdditionalDictionaryValues.Note))
                {
                    query.Where(() => additionalDictionaryValuesAlias.Note == filter.AdditionalDictionaryValues.Note);
                }
            }

            return query;
        }
    }
}