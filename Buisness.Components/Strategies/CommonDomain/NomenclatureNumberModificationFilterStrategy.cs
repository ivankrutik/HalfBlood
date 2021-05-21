// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NomenclatureNumberModificationFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the NomenclatureNumberModificationFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModel.Entities.NomenclatorDomain;

    /// <summary>
    /// The nomenclature number modification filter strategy.
    /// </summary>
    [FilterForEntity(typeof(NomenclatureNumberModification))]
    public class NomenclatureNumberModificationFilterStrategy : FilteringStrategyBase<NomenclatureNumberModification, NomenclatureNumberModificationFilter>
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
        public override IQueryOver<NomenclatureNumberModification, NomenclatureNumberModification>
            Filtering(IQueryOver<NomenclatureNumberModification, NomenclatureNumberModification> query, NomenclatureNumberModificationFilter filter)
        {
            query.FindByRn(filter.Rn);
            query.IsLike(x => x.Code, filter.Code.ReplaceStar());
            query.IsLike(x => x.Name, filter.Name.ReplaceStar());

            return query;
        }
    }
}