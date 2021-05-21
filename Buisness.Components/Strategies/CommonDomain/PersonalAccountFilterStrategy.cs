// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonalAccountFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PersonalAccountFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModel.Entities;

    /// <summary>
    /// The personal account filter strategy.
    /// </summary>
    [FilterForEntity(typeof(PersonalAccount))]
    public class PersonalAccountFilterStrategy : FilteringStrategyBase<PersonalAccount, PersonalAccountFilter>
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
        public override IQueryOver<PersonalAccount, PersonalAccount> Filtering(IQueryOver<PersonalAccount, PersonalAccount> query,
                                                               PersonalAccountFilter filter)
        {
            query.FindByRn(filter.Rn);
            if (!string.IsNullOrWhiteSpace(filter.Numb))
            {
                query.IsLike(x => x.Numb, filter.Numb.ReplaceStar());
            }

            return query;
        }
    }
}
