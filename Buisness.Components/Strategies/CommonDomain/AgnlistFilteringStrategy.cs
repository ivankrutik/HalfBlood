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
    using NHibernate.Criterion;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using ParusModel.Entities;

    [FilterForEntity(typeof(Contractor))]
    public class AgnlistFilteringStrategy : FilteringStrategyBase<Contractor, UserFilter>
    {
        public override IQueryOver<Contractor, Contractor> Filtering(
            IQueryOver<Contractor, Contractor> query,
            UserFilter filter)
        {
            query.FindByRn(filter.Rn);

            if (!string.IsNullOrWhiteSpace(filter.TableNumber))
            {
                query.IsLike(x => x.ClockNumber, filter.TableNumber.ReplaceStar(string.Empty));
            }

            if (filter.TypeCatalog > 0)
            {
                query.Where(x => x.Catalog.Rn == (long)filter.TypeCatalog);
            }

            if (filter.IsWorker)
            {
                query.Where(Restrictions.Eq(Projections.SqlFunction("length", NHibernateUtil.String, Projections.Property<Contractor>(x => x.ClockNumber)), 6));
            }

            query.IsLike(x => x.Family, filter.Lastname.ReplaceStar(string.Empty));
            query.IsLike(x => x.Firstname, filter.Firstname.ReplaceStar(string.Empty));
            query.IsLike(x => x.Name, filter.OrganizationName.ReplaceStar(string.Empty));
            query.IsLike(x => x.NameShort, filter.NameShort.ReplaceStar(string.Empty));

            return query;
        }
    }
}