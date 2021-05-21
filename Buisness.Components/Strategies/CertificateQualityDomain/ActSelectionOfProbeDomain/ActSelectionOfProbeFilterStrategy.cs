// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeDestinationFilterStrategy.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The act selection of probe destination filter strategy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.Strategies.CertificateQualityDomain.ActSelectionOfProbeDomain
{
    using Buisness.Filters;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.SqlCommand;

    using ParusModel.Entities;
    using ParusModel.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;

    /// <summary>
    /// The act selection of probe destination filter strategy.
    /// </summary>
    [FilterForEntity(typeof(ActSelectionOfProbe))]
    public class ActSelectionOfProbeFilterStrategy : FilteringStrategyBase<ActSelectionOfProbe, ActSelectionOfProbeFilter>
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
        public override IQueryOver<ActSelectionOfProbe, ActSelectionOfProbe> 
            Filtering(IQueryOver<ActSelectionOfProbe, ActSelectionOfProbe> query, ActSelectionOfProbeFilter filter)
        {
            query.FindByRn(filter.Rn);
            query.IsBetween(x => x.CreationDate, filter.CreationDate);
            //query.IsLike(x => x.Pref, filter.Pref, MatchMode.Start);
            //query.IsLike(x => x.Numb, filter.Number.ToString(), MatchMode.Start);

            //if (filter.IdDepartment > 0)
            //{
                
            //    query.JoinQueryOver(x => x.RnDepartmentCreator, JoinType.InnerJoin)
            //         .Where(x => x.Rn == filter.IdDepartment);
            //}

            if (filter.CertificateQualityFilter.Numb > 0)
            {
                //query.JoinQueryOver(x => x.CertificateQuality, JoinType.InnerJoin)
                //    .Where(x => x.Numb == filter.CertificateQualityFilter.Numb);
            }

            return query;
        }
    }
}
