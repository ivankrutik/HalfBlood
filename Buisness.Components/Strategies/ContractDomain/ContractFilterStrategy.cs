// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ContractFilterStrategy type.
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
    using ParusModel.Entities.ContractDomain;

    /// <summary>
    /// The contract filter strategy.
    /// </summary>
    [FilterForEntity(typeof(Contract))]
    public class ContractFilterStrategy : FilteringStrategyBase<Contract, ContractFilter>
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
        public override IQueryOver<Contract, Contract> Filtering(
            IQueryOver<Contract, Contract> query, ContractFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.Contaractor != null)
            {
                Contractor agnlist = null;
                query.JoinAlias(x => x.ContractorAgent, () => agnlist);
                if (!string.IsNullOrWhiteSpace(filter.Contaractor.Firstname))
                {
                    query.WhereRestrictionOn(() => agnlist.Family)
                         .IsLike(filter.Contaractor.Firstname.ReplaceStar());
                }
                if (!string.IsNullOrWhiteSpace(filter.Contaractor.TableNumber))
                {
                    query.WhereRestrictionOn(() => agnlist.ClockNumber)
                         .IsLike(filter.Contaractor.TableNumber.ReplaceStar());
                }
            }

            if (filter.StagesOfTheContract != null)
            {
                Stage stage = null;
                query.JoinAlias(x => x.Stages, () => stage);
                if (!string.IsNullOrWhiteSpace(filter.StagesOfTheContract.Numb))
                {
                    query.WhereRestrictionOn(() => stage.Numb)
                         .IsLike(filter.StagesOfTheContract.Numb.ReplaceStar());
                }

                if (filter.StagesOfTheContract.PersonalAccount != null)
                {
                    PersonalAccount personalAccount = null;
                    query.JoinAlias(() => stage.PersonalAccount, () => personalAccount);
                    if (!string.IsNullOrWhiteSpace(filter.StagesOfTheContract.PersonalAccount.Numb))
                    {
                        query.WhereRestrictionOn(() => personalAccount.Numb)
                             .IsLike(filter.StagesOfTheContract.PersonalAccount.Numb.ReplaceStar());
                    }
                }
            }

            return query;
        }
    }
}
