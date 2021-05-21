// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NomenclatureNumberFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the NomenclatureNumberFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModel.Entities.NomenclatorDomain;

    /// <summary>
    /// The nomenclature number filter strategy.
    /// </summary>
    [FilterForEntity(typeof(NomenclatureNumber))]
    public class NomenclatureNumberFilterStrategy : FilteringStrategyBase<NomenclatureNumber, NomenclatureNumberFilter>
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
        public override IQueryOver<NomenclatureNumber, NomenclatureNumber> Filtering(
            IQueryOver<NomenclatureNumber, NomenclatureNumber> query,
            NomenclatureNumberFilter filter)
        {
            query.FindByRn(filter.Rn);
            query.IsLike(x => x.NomenCode, filter.Code.ReplaceStar(string.Empty), MatchMode.Start);
            query.IsLike(x => x.NomenName, filter.Name.ReplaceStar(string.Empty), MatchMode.Start);

            return query;
        }
    }
}
