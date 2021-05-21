using Buisness.Entities.CommonDomain;

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
            query.FindByRn(filter.Rn);

            query.IsLike(x => x.Fullname, filter.Fullname.ReplaceStar(string.Empty));

            return query;
        }
    }
}