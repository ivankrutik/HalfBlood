// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StagesOfTheContractFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the StagesOfTheContractFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.ContractDomain
{
    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.SqlCommand;

    using ParusModel.Entities.ContractDomain;

    /// <summary>
    /// The stages of the contract filter strategy.
    /// </summary>
    [FilterForEntity(typeof(PlanAndSpecification))]
    public class PlanAndSpecificationFilterStrategy : FilteringStrategyBase<PlanAndSpecification, PlanAndSpecificationFilter>
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
        public override IQueryOver<PlanAndSpecification, PlanAndSpecification> Filtering(IQueryOver<PlanAndSpecification, PlanAndSpecification> query, PlanAndSpecificationFilter filter)
        {
            query.FindByRn(filter.Rn);

            query.IsBetween(x => x.BeginDate, filter.BeginDate);
            query.IsBetween(x => x.EndDate, filter.EndDate);
            if (filter.ModificationNomenclature != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.ModificationNomenclature.Code))
                {
                    query.JoinQueryOver(x => x.ModificationNomenclature, JoinType.LeftOuterJoin);
                    //NomenclatureNumberModification nommodifAlias = null;
                    //query.JoinAlias((x) => filter.ModificationNomenclature, () => nommodifAlias, JoinType.LeftOuterJoin);
                    query.WhereRestrictionOn(x => x.ModificationNomenclature.Code)
                        .IsLike(filter.ModificationNomenclature.Code.ReplaceStar());
                }
            }

            if (filter.PersonalAccount != null)
            {
               // query.JoinQueryOver(x => x.PersonalAccount, JoinType.LeftOuterJoin);
                query.Where(x => x.PersonalAccount.Rn == filter.PersonalAccount.Rn);
            }

            return query;
        }
    }
}
