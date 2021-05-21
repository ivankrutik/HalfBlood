// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControlFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ActInputControlFilterStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CertificateQualityDomain
{
    using System.Linq;

    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using ParusModel.Entities;
    using ParusModel.Entities.CertificateQualityDomain.ActInputControlDomain;

    /// <summary>
    /// The act input control filter strategy.
    /// </summary>
    [FilterForEntity(typeof(ActInputControl))]
    public class ActInputControlFilterStrategy : FilteringStrategyBase<ActInputControl, ActInputControlFilter>
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
        public override IQueryOver<ActInputControl, ActInputControl> Filtering(
            IQueryOver<ActInputControl, ActInputControl> query, ActInputControlFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (filter.State != null)
            {
                query.WhereRestrictionOn(x => x.State).IsInG(filter.State);
            }

            if (!string.IsNullOrWhiteSpace(filter.Note))
            {
                query.WhereRestrictionOn(x => x.Note).IsLike(filter.Note, MatchMode.Start);
            }

            if (filter.Numb != null)
            {
                query.Where(x => x.Numb == filter.Numb);
            }

            if (!string.IsNullOrWhiteSpace(filter.ViewTareStamp))
            {
                query.WhereRestrictionOn(x => x.ViewTareStamp)
                     .IsLike(filter.ViewTareStamp.ReplaceStar());
            }

            query.IsBetween(x => x.OpenningTareDate, filter.OpenningTareDate);

            if ((filter.TheMoveActs != null) && (filter.TheMoveActs.Any()))
            {
                TheMoveAct theMoveActAlias = null;
                StaffingDivision staffingDivisionDepartmentReciverAlias = null;
                StaffingDivision staffingDivisionDepartmentCreatorAlias = null;
                query.JoinAlias(x => x.TheMoveActs, () => theMoveActAlias);
                query.JoinAlias(() => theMoveActAlias.DepartmentCreator, () => staffingDivisionDepartmentCreatorAlias);
                query.JoinAlias(() => theMoveActAlias.DepartmentReciver, () => staffingDivisionDepartmentReciverAlias);

                query.WhereRestrictionOn(x => staffingDivisionDepartmentCreatorAlias.Code)
                     .IsIn(
                         filter.TheMoveActs.Where(x => x.DepartmentCreator != null)
                               .Select(x => x.DepartmentCreator.Code)
                               .ToArray());

                query.WhereRestrictionOn(x => staffingDivisionDepartmentReciverAlias.Code)
                     .IsIn(
                         filter.TheMoveActs.Where(x => x.DepartmentReciver != null)
                               .Select(x => x.DepartmentReciver.Code)
                               .ToArray());
                query.WhereRestrictionOn(() => theMoveActAlias.UserCreator.Rn)
                     .IsIn(filter.TheMoveActs.Select(x => x.UserCreator.Rn).ToArray());

            }

            if ((filter.QualityStateControlOfTheMakes != null) && (filter.QualityStateControlOfTheMakes.Any()))
            {
                QualityStateControlOfTheMake qualityStateControlOfTheMakeAlias = null;
                query.JoinAlias(x => x.QualityStateControlOfTheMakes, () => qualityStateControlOfTheMakeAlias);
            }

            return query;
        }
    }
}
