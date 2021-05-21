// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StagesOfTheContractFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the StagesOfTheContractFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;
    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.SqlCommand;
    using ParusModel.Entities.ContractDomain;
    using Halfblood.Common.Helpers;
    using ParusModel.Entities.NomenclatorDomain;
    using ParusModelLite.ContractDomain;


    /// <summary>
    /// The stages of the contract filter strategy.
    /// </summary>
    [FilterForEntity(typeof(PlanAndSpecificationLiteDto))]
    public class PlanAndSpecificationLiteFilterStrategy : FilteringStrategyBase<PlanAndSpecificationLiteDto, PlanAndSpecificationFilter>
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
        public override IQueryOver<PlanAndSpecificationLiteDto, PlanAndSpecificationLiteDto> Filtering(IQueryOver<PlanAndSpecificationLiteDto, PlanAndSpecificationLiteDto> query, PlanAndSpecificationFilter filter)
        {
            query.FindByRn(filter.Rn);

            query.IsBetween(x => x.BeginDate, filter.BeginDate);
            query.IsBetween(x => x.EndDate, filter.EndDate);
        
            if (filter.PersonalAccount != null)
            {
                query.Where(x => x.PersonalAccountRN == filter.PersonalAccount.Rn);
            }

            return query;
        }
    }
}
