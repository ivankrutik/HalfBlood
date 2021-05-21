using System.Security.Cryptography.X509Certificates;
using Buisness.Entities.CommonDomain;
using NHibernate.Criterion;

namespace Buisness.Components.Strategies.CommonDomain
{
    using Buisness.Filters;

    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;


    [FilterForEntity(typeof(EmployeeDto))]
    public class EmployeeFilterStrategy : FilteringStrategyBase<EmployeeDto, EmployeeFilter>
    {

        public override IQueryOver<EmployeeDto, EmployeeDto> Filtering(IQueryOver<EmployeeDto, EmployeeDto> query, EmployeeFilter filter)
        {
            var tmp = filter.Fullname.Replace("*", "%").ToUpper();
            query.Where(Restrictions.Like(Projections.SqlFunction("upper", NHibernateUtil.String, Projections.Property<EmployeeDto>(x => x.Fullname)), tmp));

            return query;
        }
    }
}