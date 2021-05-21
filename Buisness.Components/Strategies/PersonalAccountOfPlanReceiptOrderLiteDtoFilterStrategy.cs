// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonalAccountOfPlanReceiptOrderLiteDtoFilterStrategy.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the PersonalAccountOfPlanReceiptOrderLiteDtoFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies
{
    using Buisness.Filters;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModelLite.PlanReceiptOrderDomain;

    /// <summary>
    /// The personal account of plan receipt order lite DTO filter strategy.
    /// </summary>
    [FilterForEntity(typeof(PersonalAccountOfPlanReceiptOrderLiteDto))]
    public class PersonalAccountOfPlanReceiptOrderLiteDtoFilterStrategy 
        : FilteringStrategyBase<PersonalAccountOfPlanReceiptOrderLiteDto, PlanReceiptOrderPersonalAccountFilter>
    {
        public override IQueryOver<PersonalAccountOfPlanReceiptOrderLiteDto, PersonalAccountOfPlanReceiptOrderLiteDto> 
            Filtering(
            IQueryOver<PersonalAccountOfPlanReceiptOrderLiteDto, PersonalAccountOfPlanReceiptOrderLiteDto> query, 
            PlanReceiptOrderPersonalAccountFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.PlanCertificate.Rn > 0)
            {
                query.Where(x => x.PRn == filter.PlanCertificate.Rn);
            }

            query.IsLike(x => x.PersonalAccount, filter.PersonalAccount);

            return query;
        }
    }
}
